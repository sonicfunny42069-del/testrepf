using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.NPCs;

public static class NPCDetours
{
	public static void CheckDead(NPC npc)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		if (!((Entity)npc).active || (npc.realLife >= 0 && npc.realLife != ((Entity)npc).whoAmI) || npc.life > 0)
		{
			return;
		}
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			npc.AsFood().Digested = true;
		}
		if (npc.type == 604 || npc.type == 605)
		{
			NPC.LadyBugKilled(((Entity)npc).Center, npc.type == 605);
		}
		if (npc.type == 397 || npc.type == 396)
		{
			if (npc.ai[0] != -2f)
			{
				npc.ai[0] = -2f;
				npc.life = npc.lifeMax;
				npc.netUpdate = true;
				npc.dontTakeDamage = true;
				if (Main.netMode != 1)
				{
					NPC obj = NPC.NewNPCDirect(((Entity)npc).GetSource_FromAI((string)null), (int)((Entity)npc).Center.X, (int)((Entity)npc).Center.Y, 400, 0, 0f, 0f, 0f, 0f, 255);
					obj.ai[3] = npc.ai[3];
					obj.netUpdate = true;
				}
			}
		}
		else if (npc.type == 398 && npc.ai[0] != 2f)
		{
			npc.ai[0] = 2f;
			npc.life = npc.lifeMax;
			npc.netUpdate = true;
			npc.dontTakeDamage = true;
		}
		else if ((npc.type == 517 || npc.type == 422 || npc.type == 507 || npc.type == 493) && npc.ai[2] != 1f)
		{
			npc.ai[2] = 1f;
			npc.ai[1] = 0f;
			npc.life = npc.lifeMax;
			npc.dontTakeDamage = true;
			npc.netUpdate = true;
		}
		else if (npc.type == 548 && npc.ai[1] != 1f)
		{
			npc.ai[1] = 1f;
			npc.ai[0] = 0f;
			npc.life = npc.lifeMax;
			npc.dontTakeDamageFromHostiles = true;
			npc.netUpdate = true;
		}
		else
		{
			if (!NPCLoader.CheckDead(npc))
			{
				return;
			}
			typeof(NPC).GetField("noSpawnCycle", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, true);
			if (npc.townNPC && npc.type != 37 && npc.type != 453)
			{
				if (Main.netMode != 2)
				{
					if (npc.type == 22)
					{
						if (Main.LocalPlayer.ladyBugLuckTimeLeft >= 0.0 && ((Entity)Main.LocalPlayer).active && !Main.LocalPlayer.dead)
						{
							int goodLuckTime = NPC.ladyBugGoodLuckTime / 3;
							if ((double)goodLuckTime > Main.LocalPlayer.ladyBugLuckTimeLeft)
							{
								Main.LocalPlayer.ladyBugLuckTimeLeft = goodLuckTime;
								Main.LocalPlayer.luckNeedsSync = true;
							}
						}
					}
					else if (npc.type != 54 && ((Entity)Main.LocalPlayer).active && !Main.LocalPlayer.dead)
					{
						int badLuckTime = NPC.ladyBugBadLuckTime / 3;
						if ((double)badLuckTime < Main.LocalPlayer.ladyBugLuckTimeLeft)
						{
							Main.LocalPlayer.ladyBugLuckTimeLeft = badLuckTime;
							Main.LocalPlayer.luckNeedsSync = true;
						}
					}
				}
				bool shouldDropTombstone = !npc.AsFood().Digested;
				NetworkText fullNetName = npc.GetFullNetName();
				int num2 = 19;
				if (npc.type == 369 || npc.type == 663 || Sets.IsTownPet[npc.type])
				{
					num2 = 36;
					shouldDropTombstone = false;
				}
				NetworkText networkText = NetworkText.FromKey(Lang.misc[num2].Key, new object[1] { fullNetName });
				if (npc.AsFood().Digested)
				{
					networkText = NetworkText.FromKey("Mods.V2.Death.DigestedTownNPC", new object[1] { fullNetName });
				}
				if (shouldDropTombstone)
				{
					for (int i = 0; i < 255; i++)
					{
						Player player = Main.player[i];
						if (player != null && ((Entity)player).active && player.difficulty != 2)
						{
							shouldDropTombstone = false;
							break;
						}
					}
				}
				if (shouldDropTombstone)
				{
					npc.DropTombstoneTownNPC(networkText);
				}
				if (Main.netMode == 0)
				{
					Main.NewText(((object)networkText).ToString(), byte.MaxValue, (byte)25, (byte)25);
				}
				else if (Main.netMode == 2)
				{
					ChatHelper.BroadcastChatMessage(networkText, new Color(255, 25, 25), -1);
				}
			}
			if (Main.netMode != 1 && !Main.dayTime && npc.type == 54 && !NPC.AnyNPCs(35))
			{
				for (int j = 0; j < 255; j++)
				{
					if (((Entity)Main.player[j]).active && !Main.player[j].dead && Main.player[j].killClothier)
					{
						NPC.SpawnSkeletron(j);
						break;
					}
				}
			}
			if (npc.townNPC && Main.netMode != 1 && npc.homeless && WorldGen.prioritizedTownNPCType == npc.type)
			{
				WorldGen.prioritizedTownNPCType = 0;
			}
			if (npc.AsFood().Digested)
			{
				if (npc.AsFood().DigestedDeathSound.HasValue)
				{
					SoundEngine.PlaySound(ref npc.AsFood().DigestedDeathSound, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				Entity predator = ((Entity)(object)npc).CurrentCaptor().Predator;
				Player hungryPlayer = (Player)(object)((predator is Player) ? predator : null);
				if (hungryPlayer != null)
				{
					if (!npc.AnyInteractions() && npc.IsNPCValidForBestiaryKillCredit())
					{
						Main.BestiaryTracker.Kills.RegisterKill(npc);
					}
					PredPlayer.CountDigestionKillForBannersAndDropThem(hungryPlayer, npc);
				}
				npc.AsFood().OnDigestedBy(npc, ((Entity)(object)npc).CurrentCaptor().Predator);
				npc.NPCLoot();
			}
			else
			{
				if (npc.DeathSound.HasValue)
				{
					SoundEngine.PlaySound(ref npc.DeathSound, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if (!NPCLoader.SpecialOnKill(npc))
				{
					if (npc.type == 13 || npc.type == 14 || npc.type == 15)
					{
						DropEoWLoot();
					}
					else if (npc.type == 134)
					{
						Vector2 position = ((Entity)npc).position;
						Vector2 center = ((Entity)Main.player[npc.target]).Center;
						float num3 = 100000000f;
						Vector2 position2 = ((Entity)npc).position;
						for (int k = 0; k < 200; k++)
						{
							if (((Entity)Main.npc[k]).active && (Main.npc[k].type == 134 || Main.npc[k].type == 135 || Main.npc[k].type == 136))
							{
								float num4 = Math.Abs(((Entity)Main.npc[k]).Center.X - center.X) + Math.Abs(((Entity)Main.npc[k]).Center.Y - center.Y);
								if (num4 < num3)
								{
									num3 = num4;
									position2 = ((Entity)Main.npc[k]).position;
								}
							}
						}
						((Entity)npc).position = position2;
						npc.NPCLoot();
						((Entity)npc).position = position;
					}
					else
					{
						npc.NPCLoot();
					}
				}
			}
			((Entity)npc).active = false;
			DD2Event.CheckProgress(npc.type);
			CheckProgressFrostMoon();
			CheckProgressPumpkinMoon();
			int nPCInvasionGroup = NPC.GetNPCInvasionGroup(npc.type);
			if (nPCInvasionGroup <= 0 || nPCInvasionGroup != Main.invasionType)
			{
				return;
			}
			int num5 = 1;
			switch (npc.type)
			{
			case 216:
				num5 = 5;
				break;
			case 395:
				num5 = 10;
				break;
			case 491:
				num5 = 10;
				break;
			case 471:
				num5 = 10;
				break;
			case 472:
				num5 = 0;
				break;
			case 387:
				num5 = 0;
				break;
			}
			if (num5 > 0)
			{
				Main.invasionSize -= num5;
				if (Main.invasionSize < 0)
				{
					Main.invasionSize = 0;
				}
				if (Main.netMode != 1)
				{
					Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, nPCInvasionGroup + 3, 0);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(78, -1, -1, (NetworkText)null, Main.invasionProgress, (float)Main.invasionProgressMax, (float)Main.invasionProgressIcon, 0f, 0, 0, 0);
				}
			}
		}
		void CheckProgressFrostMoon()
		{
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			if (Main.snowMoon)
			{
				NetworkText networkText2 = NetworkText.Empty;
				int[] neededScorePerWave = new int[21]
				{
					0, 25, 15, 10, 30, 100, 160, 180, 200, 250,
					300, 375, 450, 525, 675, 850, 1025, 1325, 1550, 2000,
					0
				};
				int neededScore = neededScorePerWave[NPC.waveNumber];
				switch (NPC.waveNumber)
				{
				case 1:
					networkText2 = Lang.GetInvasionWaveText(2, new short[2] { 338, 350 });
					break;
				case 2:
					networkText2 = Lang.GetInvasionWaveText(3, new short[4] { 338, 350, 342, 348 });
					break;
				case 3:
					networkText2 = Lang.GetInvasionWaveText(4, new short[4] { 344, 338, 350, 342 });
					break;
				case 4:
					networkText2 = Lang.GetInvasionWaveText(5, new short[4] { 344, 338, 350, 348 });
					break;
				case 5:
					networkText2 = Lang.GetInvasionWaveText(6, new short[4] { 344, 350, 348, 347 });
					break;
				case 6:
					networkText2 = Lang.GetInvasionWaveText(7, new short[4] { 346, 342, 350, 338 });
					break;
				case 7:
					networkText2 = Lang.GetInvasionWaveText(8, new short[5] { 346, 347, 350, 348, 351 });
					break;
				case 8:
					networkText2 = Lang.GetInvasionWaveText(9, new short[5] { 346, 344, 348, 347, 342 });
					break;
				case 9:
					networkText2 = Lang.GetInvasionWaveText(10, new short[5] { 346, 344, 351, 338, 347 });
					break;
				case 10:
					networkText2 = Lang.GetInvasionWaveText(11, new short[4] { 345, 352, 338, 342 });
					break;
				case 11:
					networkText2 = Lang.GetInvasionWaveText(12, new short[5] { 345, 344, 342, 343, 338 });
					break;
				case 12:
					networkText2 = Lang.GetInvasionWaveText(13, new short[6] { 345, 346, 342, 352, 343, 347 });
					break;
				case 13:
					networkText2 = Lang.GetInvasionWaveText(14, new short[5] { 345, 346, 344, 343, 351 });
					break;
				case 14:
					networkText2 = Lang.GetInvasionWaveText(15, new short[5] { 345, 346, 344, 343, 347 });
					break;
				case 15:
					networkText2 = Lang.GetInvasionWaveText(16, new short[5] { 345, 346, 344, 343, 352 });
					break;
				case 16:
					networkText2 = Lang.GetInvasionWaveText(17, new short[6] { 345, 346, 344, 343, 351, 347 });
					break;
				case 17:
					networkText2 = Lang.GetInvasionWaveText(18, new short[6] { 345, 346, 344, 343, 348, 351 });
					break;
				case 18:
					networkText2 = Lang.GetInvasionWaveText(19, new short[4] { 345, 346, 344, 343 });
					break;
				case 19:
					networkText2 = Lang.GetInvasionWaveText(-1, new short[3] { 345, 346, 344 });
					break;
				}
				float pointsFromKill = 0f;
				switch (npc.type)
				{
				case 338:
				case 339:
				case 340:
					pointsFromKill = 1f;
					break;
				case 341:
					pointsFromKill = 20f;
					break;
				case 342:
					pointsFromKill = 2f;
					break;
				case 343:
					pointsFromKill = 18f;
					break;
				case 344:
					pointsFromKill = 50f;
					break;
				case 345:
					pointsFromKill = 150f;
					break;
				case 346:
					pointsFromKill = 100f;
					break;
				case 347:
					pointsFromKill = 8f;
					break;
				case 348:
				case 349:
					pointsFromKill = 4f;
					break;
				case 350:
					pointsFromKill = 3f;
					break;
				}
				if (Main.expertMode)
				{
					pointsFromKill *= 2f;
				}
				float num6 = NPC.waveKills;
				NPC.waveKills += pointsFromKill;
				if (NPC.waveKills >= (float)neededScore && neededScore != 0)
				{
					NPC.waveKills = 0f;
					NPC.waveNumber++;
					neededScore = neededScorePerWave[NPC.waveNumber];
					if (networkText2 != NetworkText.Empty)
					{
						if (Main.netMode == 0)
						{
							Main.NewText(((object)networkText2).ToString(), (byte)175, (byte)75, byte.MaxValue);
						}
						else if (Main.netMode == 2)
						{
							ChatHelper.BroadcastChatMessage(networkText2, new Color(175, 75, 255), -1);
						}
						if (NPC.waveNumber == 15)
						{
							AchievementsHelper.NotifyProgressionEvent(14);
						}
					}
				}
				if (NPC.waveKills != num6 && pointsFromKill != 0f)
				{
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress((int)NPC.waveKills, neededScore, 1, NPC.waveNumber);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, (NetworkText)null, Main.invasionProgress, (float)Main.invasionProgressMax, 1f, (float)NPC.waveNumber, 0, 0, 0);
					}
				}
			}
		}
		void CheckProgressPumpkinMoon()
		{
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			if (Main.pumpkinMoon)
			{
				NetworkText networkText2 = NetworkText.Empty;
				int[] neededScorePerWave = new int[16]
				{
					0, 25, 40, 50, 80, 100, 160, 180, 200, 250,
					300, 375, 450, 525, 675, 0
				};
				int neededScore = neededScorePerWave[NPC.waveNumber];
				switch (NPC.waveNumber)
				{
				case 1:
					networkText2 = Lang.GetInvasionWaveText(2, new short[2] { 305, 326 });
					break;
				case 2:
					networkText2 = Lang.GetInvasionWaveText(3, new short[3] { 305, 326, 329 });
					break;
				case 3:
					networkText2 = Lang.GetInvasionWaveText(4, new short[4] { 305, 326, 329, 325 });
					break;
				case 4:
					networkText2 = Lang.GetInvasionWaveText(5, new short[5] { 305, 326, 329, 330, 325 });
					break;
				case 5:
					networkText2 = Lang.GetInvasionWaveText(6, new short[4] { 326, 329, 330, 325 });
					break;
				case 6:
					networkText2 = Lang.GetInvasionWaveText(7, new short[4] { 305, 329, 330, 327 });
					break;
				case 7:
					networkText2 = Lang.GetInvasionWaveText(8, new short[4] { 326, 329, 330, 327 });
					break;
				case 8:
					networkText2 = Lang.GetInvasionWaveText(9, new short[4] { 305, 315, 325, 327 });
					break;
				case 9:
					networkText2 = Lang.GetInvasionWaveText(10, new short[6] { 326, 329, 330, 315, 325, 327 });
					break;
				case 10:
					networkText2 = Lang.GetInvasionWaveText(11, new short[7] { 305, 326, 329, 330, 315, 325, 327 });
					break;
				case 11:
					networkText2 = Lang.GetInvasionWaveText(12, new short[6] { 326, 329, 330, 315, 325, 327 });
					break;
				case 12:
					networkText2 = Lang.GetInvasionWaveText(13, new short[5] { 329, 330, 315, 325, 327 });
					break;
				case 13:
					networkText2 = Lang.GetInvasionWaveText(14, new short[3] { 315, 325, 327 });
					break;
				case 14:
					networkText2 = Lang.GetInvasionWaveText(-1, new short[2] { 325, 327 });
					break;
				}
				float num6 = 0f;
				switch (npc.type)
				{
				case 305:
				case 306:
				case 307:
				case 308:
				case 309:
				case 310:
				case 311:
				case 312:
				case 313:
				case 314:
					num6 = 1f;
					break;
				case 315:
					num6 = 25f;
					break;
				case 325:
					num6 = 75f;
					break;
				case 326:
					num6 = 2f;
					break;
				case 327:
					num6 = 150f;
					break;
				case 329:
					num6 = 4f;
					break;
				case 330:
					num6 = 8f;
					break;
				}
				if (Main.expertMode)
				{
					num6 *= 2f;
				}
				float num7 = NPC.waveKills;
				NPC.waveKills += num6;
				if (NPC.waveKills >= (float)neededScore && neededScore != 0)
				{
					NPC.waveKills = 0f;
					NPC.waveNumber++;
					neededScore = neededScorePerWave[NPC.waveNumber];
					if (networkText2 != NetworkText.Empty)
					{
						if (Main.netMode == 0)
						{
							Main.NewText(((object)networkText2).ToString(), (byte)175, (byte)75, byte.MaxValue);
						}
						else if (Main.netMode == 2)
						{
							ChatHelper.BroadcastChatMessage(networkText2, new Color(175, 75, 255), -1);
						}
						if (NPC.waveNumber == 15)
						{
							AchievementsHelper.NotifyProgressionEvent(15);
						}
					}
				}
				if (NPC.waveKills != num7 && num6 != 0f)
				{
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress((int)NPC.waveKills, neededScore, 2, NPC.waveNumber);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, (NetworkText)null, Main.invasionProgress, (float)Main.invasionProgressMax, 2f, (float)NPC.waveNumber, 0, 0, 0);
					}
				}
			}
		}
		void DropEoWLoot()
		{
			bool lastSegment = true;
			for (int l = 0; l < 200; l++)
			{
				NPC otherNPC = Main.npc[l];
				bool isEoWSegment = otherNPC.type == 13 || otherNPC.type == 14 || otherNPC.type == 15;
				if (((Entity)otherNPC).whoAmI != ((Entity)npc).whoAmI && ((Entity)otherNPC).active && isEoWSegment)
				{
					lastSegment = false;
					break;
				}
			}
			if (lastSegment)
			{
				npc.boss = true;
				npc.NPCLoot();
			}
			else
			{
				npc.NPCLoot();
			}
		}
	}

	public static void DoDeathEvents_CelebrateBossDeath(NPC npc, string typeName)
	{
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		if (npc.AsFood().Digested)
		{
			string localName = "";
			Entity pred = ((Entity)(object)npc).CurrentCaptor().Predator;
			NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
			if (predNPC != null)
			{
				localName = predNPC.FullName;
			}
			else
			{
				Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
				if (predPlayer != null)
				{
					localName = predPlayer.name;
				}
				else
				{
					Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
					if (predProjectile != null)
					{
						localName = predProjectile.Name;
					}
				}
			}
			NetworkText networkName = NetworkText.FromLiteral(localName);
			string text;
			switch (npc.type)
			{
			case 50:
				text = "KS";
				break;
			case 4:
				text = "EoC";
				break;
			case 13:
			case 14:
			case 15:
				text = "EoW";
				break;
			case 266:
				text = "BoC";
				break;
			case 222:
				text = "QB";
				break;
			case 35:
				text = "Skele";
				break;
			case 668:
				text = "Deerclops";
				break;
			case 113:
			case 114:
				text = "WoF";
				break;
			case 657:
				text = "QS";
				break;
			case 125:
			case 126:
				text = "Twins";
				break;
			case 134:
			case 135:
			case 136:
				text = "Destro";
				break;
			case 127:
				text = "SkelePrime";
				break;
			case 262:
				text = "Plantera";
				break;
			case 245:
				text = "Golem";
				break;
			case 636:
				text = "LightSnack";
				break;
			case 370:
				text = "Fishron";
				break;
			case 439:
				text = "Cultist";
				break;
			case 517:
				text = "SolarPillar";
				break;
			case 422:
				text = "VortexPillar";
				break;
			case 507:
				text = "NebulaPillar";
				break;
			case 493:
				text = "StardustPillar";
				break;
			case 398:
				text = "MoonLord";
				break;
			default:
				text = "Default";
				break;
			}
			string gurgledBossKey = text;
			if (Main.netMode == 0)
			{
				Main.NewText(Language.GetTextValueWith("Mods.V2.Death.DigestedBoss." + gurgledBossKey, (object)new
				{
					Pred = localName,
					BossName = npc.TypeName
				}), (byte)175, (byte)75, byte.MaxValue);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.V2.Death.DigestedBoss." + gurgledBossKey, new object[1]
				{
					new
					{
						Pred = networkName,
						BossName = npc.TypeName
					}
				}), new Color(175, 75, 255), -1);
			}
		}
		else if (npc.type == 125 || npc.type == 126)
		{
			if (Main.netMode == 0)
			{
				Main.NewText(Language.GetTextValue("Announcement.HasBeenDefeated_Plural", (object)Language.GetTextValue("Enemies.TheTwins")), (byte)175, (byte)75, byte.MaxValue);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasBeenDefeated_Plural", new object[1] { NetworkText.FromKey("Enemies.TheTwins", Array.Empty<object>()) }), new Color(175, 75, 255), -1);
			}
		}
		else if (npc.type == 398)
		{
			if (Main.netMode == 0)
			{
				Main.NewText(Language.GetTextValue("Announcement.HasBeenDefeated_Single", (object)Language.GetTextValue("Enemies.MoonLord")), (byte)175, (byte)75, byte.MaxValue);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasBeenDefeated_Single", new object[1] { NetworkText.FromKey("Enemies.MoonLord", Array.Empty<object>()) }), new Color(175, 75, 255), -1);
			}
		}
		else if (Main.netMode == 0)
		{
			Main.NewText(Language.GetTextValue("Announcement.HasBeenDefeated_Single", (object)typeName), (byte)175, (byte)75, byte.MaxValue);
		}
		else if (Main.netMode == 2)
		{
			ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasBeenDefeated_Single", new object[1] { npc.GetTypeNetName() }), new Color(175, 75, 255), -1);
		}
	}
}
