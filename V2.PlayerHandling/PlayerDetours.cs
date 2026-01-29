using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.Items;

namespace V2.PlayerHandling;

public static class PlayerDetours
{
	public static void Detour_UpdateLifeRegen(Player player)
	{
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Unknown result type (might be due to invalid IL or missing references)
		//IL_099d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Unknown result type (might be due to invalid IL or missing references)
		bool shinyStoneShouldEverFuckingWork = false;
		if (player.shinyStone && ((Vector2)(ref ((Entity)player).velocity)).Length() < 0.05f && player.itemAnimation == 0)
		{
			shinyStoneShouldEverFuckingWork = true;
		}
		player.AsV2Player().healthRegenTime += 1.0;
		foreach (HealthRegenEffect healthRegenEffect2 in player.AsV2Player().HealthRegenEffects)
		{
			healthRegenEffect2.modifyHealthRegenTimeMethod?.Invoke(player, ref player.AsV2Player().healthRegenTime);
		}
		double oneMinuteFrameCount = V2Utils.SensibleTime(0, 1);
		if (player.AsV2Player().healthRegenTime >= oneMinuteFrameCount)
		{
			player.AsV2Player().healthRegenTime = oneMinuteFrameCount;
		}
		player.AsV2Player().HealthRegenNatural.baseRegen = 0.0;
		player.AsV2Player().HealthRegenNatural.additiveRegenModifier = 1.0;
		player.AsV2Player().HealthRegenNatural.flatRegenBonus = 0.0;
		player.AsV2Player().HealthRegenArtificial.baseRegen = 0.0;
		player.AsV2Player().HealthRegenArtificial.additiveRegenModifier = 1.0;
		player.AsV2Player().HealthRegenArtificial.flatRegenBonus = 0.0;
		foreach (HealthRegenEffect healthRegenEffect in player.AsV2Player().HealthRegenEffects)
		{
			if (healthRegenEffect.natural)
			{
				player.AsV2Player().HealthRegenNatural.baseRegen += (float)healthRegenEffect.healthPerSecond(player);
			}
			else
			{
				player.AsV2Player().HealthRegenArtificial.baseRegen += (float)healthRegenEffect.healthPerSecond(player);
			}
		}
		foreach (HealthRegenEffect healthRegenEffect3 in player.AsV2Player().HealthRegenEffects)
		{
			healthRegenEffect3.modifyTotalHealthRegenMethod?.Invoke(player, ref player.AsV2Player().HealthRegenNatural.additiveRegenModifier, ref player.AsV2Player().HealthRegenNatural.multiplicativeRegenModifier, ref player.AsV2Player().HealthRegenArtificial.additiveRegenModifier, ref player.AsV2Player().HealthRegenArtificial.multiplicativeRegenModifier);
		}
		double naturalHealthRegenCount = player.AsV2Player().HealthRegenNatural.baseRegen * player.AsV2Player().HealthRegenNatural.additiveRegenModifier + player.AsV2Player().HealthRegenNatural.flatRegenBonus;
		double artificialHealthRegenCount = player.AsV2Player().HealthRegenArtificial.baseRegen * player.AsV2Player().HealthRegenArtificial.additiveRegenModifier + player.AsV2Player().HealthRegenArtificial.flatRegenBonus;
		player.AsV2Player().healthRegenCount += naturalHealthRegenCount + artificialHealthRegenCount;
		while (player.AsV2Player().healthRegenCount >= 60.0)
		{
			player.AsV2Player().healthRegenCount -= 60.0;
			if (player.statLife < player.statLifeMax2)
			{
				player.statLife++;
				foreach (HealthRegenEffect healthRegenEffect4 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect4.onHealthAdjustmentMethod?.Invoke(player, 1);
				}
			}
			if (player.statLife > player.statLifeMax2)
			{
				player.statLife = player.statLifeMax2;
			}
		}
		while (player.AsV2Player().healthRegenCount <= -60.0)
		{
			if (player.AsV2Player().healthRegenCount <= -240.0)
			{
				player.AsV2Player().healthRegenCount += 240.0;
				player.statLife -= 4;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 4, false, true);
				foreach (HealthRegenEffect healthRegenEffect5 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect5.onHealthAdjustmentMethod?.Invoke(player, -4);
				}
			}
			else if (player.AsV2Player().healthRegenCount <= -180.0)
			{
				player.AsV2Player().healthRegenCount += 180.0;
				player.statLife -= 3;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 3, false, true);
				foreach (HealthRegenEffect healthRegenEffect6 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect6.onHealthAdjustmentMethod?.Invoke(player, -3);
				}
			}
			else if (player.AsV2Player().healthRegenCount <= -120.0)
			{
				player.AsV2Player().healthRegenCount += 120.0;
				player.statLife -= 2;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 2, false, true);
				foreach (HealthRegenEffect healthRegenEffect7 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect7.onHealthAdjustmentMethod?.Invoke(player, -2);
				}
			}
			else
			{
				player.AsV2Player().healthRegenCount += 60.0;
				player.statLife--;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 1, false, true);
				foreach (HealthRegenEffect healthRegenEffect8 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect8.onHealthAdjustmentMethod?.Invoke(player, -1);
				}
			}
			if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
			{
				if (player.poisoned || player.venom)
				{
					player.KillMe(PlayerDeathReason.ByOther(9, -1), 10.0, 0, false);
				}
				else if (player.electrified)
				{
					player.KillMe(PlayerDeathReason.ByOther(10, -1), 10.0, 0, false);
				}
				else
				{
					player.KillMe(PlayerDeathReason.ByOther(8, -1), 10.0, 0, false);
				}
				return;
			}
		}
		PlayerLoader.UpdateBadLifeRegen(player);
		player.lifeRegenTime += 1f;
		if (player.lifeRegenTime >= 3600f)
		{
			player.lifeRegenTime = 3600f;
		}
		PlayerLoader.UpdateLifeRegen(player);
		float num5 = 0f;
		PlayerLoader.NaturalLifeRegen(player, ref num5);
		float num7 = (float)player.statLifeMax2 / 400f * 0.85f + 0.15f;
		num5 *= num7;
		player.lifeRegen += (int)Math.Round(num5);
		player.lifeRegenCount += player.lifeRegen;
		if (shinyStoneShouldEverFuckingWork && player.lifeRegen > 0 && player.statLife < player.statLifeMax2)
		{
			player.lifeRegenCount++;
			if (shinyStoneShouldEverFuckingWork && ((float)Main.rand.Next(30000) < player.lifeRegenTime || Utils.NextBool(Main.rand, 30)))
			{
				int num8 = Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 55, 0f, 0f, 200, default(Color), 0.5f);
				Main.dust[num8].noGravity = true;
				Dust obj = Main.dust[num8];
				obj.velocity *= 0.75f;
				Main.dust[num8].fadeIn = 1.3f;
				Vector2 vector = default(Vector2);
				((Vector2)(ref vector))._002Ector((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
				((Vector2)(ref vector)).Normalize();
				vector *= (float)Main.rand.Next(50, 100) * 0.04f;
				Main.dust[num8].velocity = vector;
				((Vector2)(ref vector)).Normalize();
				vector *= 34f;
				Main.dust[num8].position = ((Entity)player).Center - vector;
			}
		}
		while (player.lifeRegenCount >= 120)
		{
			player.lifeRegenCount -= 120;
			if (player.statLife < player.statLifeMax2)
			{
				player.statLife++;
				if (player.crimsonRegen)
				{
					for (int i = 0; i < 10; i++)
					{
						int num9 = Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 5, 0f, 0f, 175, default(Color), 1.75f);
						Main.dust[num9].noGravity = true;
						Dust obj2 = Main.dust[num9];
						obj2.velocity *= 0.75f;
						int num10 = Main.rand.Next(-40, 41);
						int num11 = Main.rand.Next(-40, 41);
						Main.dust[num9].position.X += num10;
						Main.dust[num9].position.Y += num11;
						Main.dust[num9].velocity.X = (float)(-num10) * 0.075f;
						Main.dust[num9].velocity.Y = (float)(-num11) * 0.075f;
					}
				}
			}
			if (player.statLife > player.statLifeMax2)
			{
				player.statLife = player.statLifeMax2;
			}
		}
		if (player.burned || player.suffocating || (player.tongued && Main.expertMode))
		{
			while (player.lifeRegenCount <= -600)
			{
				player.lifeRegenCount += 600;
				player.statLife -= 5;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 5, false, true);
				if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					if (player.suffocating)
					{
						player.KillMe(PlayerDeathReason.ByOther(7, -1), 10.0, 0, false);
					}
					else
					{
						player.KillMe(PlayerDeathReason.ByOther(8, -1), 10.0, 0, false);
					}
				}
			}
			return;
		}
		if (player.starving)
		{
			int num12 = player.statLifeMax2 / 50;
			if (num12 < 2)
			{
				num12 = 2;
			}
			int num13 = ((player.ZoneDesert || player.ZoneSnow) ? (num12 * 2) : num12);
			int num14 = 120 * num12;
			while (player.lifeRegenCount <= -num14)
			{
				player.lifeRegenCount += num14;
				player.statLife -= num13;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, num13, false, true);
				if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					player.KillMe(PlayerDeathReason.ByOther(18, -1), 10.0, 0, false);
				}
			}
			return;
		}
		while (player.lifeRegenCount <= -120)
		{
			if (player.lifeRegenCount <= -480)
			{
				player.lifeRegenCount += 480;
				player.statLife -= 4;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 4, false, true);
			}
			else if (player.lifeRegenCount <= -360)
			{
				player.lifeRegenCount += 360;
				player.statLife -= 3;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 3, false, true);
			}
			else if (player.lifeRegenCount <= -240)
			{
				player.lifeRegenCount += 240;
				player.statLife -= 2;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 2, false, true);
			}
			else
			{
				player.lifeRegenCount += 120;
				player.statLife--;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 1, false, true);
			}
			if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
			{
				if (player.poisoned || player.venom)
				{
					player.KillMe(PlayerDeathReason.ByOther(9, -1), 10.0, 0, false);
				}
				else if (player.electrified)
				{
					player.KillMe(PlayerDeathReason.ByOther(10, -1), 10.0, 0, false);
				}
				else
				{
					player.KillMe(PlayerDeathReason.ByOther(8, -1), 10.0, 0, false);
				}
			}
		}
	}

	public static void Detour_UpdateBuffs(Player player)
	{
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_123a: Unknown result type (might be due to invalid IL or missing references)
		//IL_124c: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e16: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_4427: Unknown result type (might be due to invalid IL or missing references)
		//IL_442c: Unknown result type (might be due to invalid IL or missing references)
		//IL_441a: Unknown result type (might be due to invalid IL or missing references)
		//IL_441f: Unknown result type (might be due to invalid IL or missing references)
		//IL_44b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_44bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_44c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_45cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_45d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_45dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_45f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_45fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4602: Unknown result type (might be due to invalid IL or missing references)
		//IL_4633: Unknown result type (might be due to invalid IL or missing references)
		//IL_4639: Unknown result type (might be due to invalid IL or missing references)
		//IL_463e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4663: Unknown result type (might be due to invalid IL or missing references)
		//IL_466d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4672: Unknown result type (might be due to invalid IL or missing references)
		//IL_46a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_46ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_46b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_46d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_46e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_46e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_470c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4716: Unknown result type (might be due to invalid IL or missing references)
		//IL_471b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4554: Unknown result type (might be due to invalid IL or missing references)
		//IL_455e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4563: Unknown result type (might be due to invalid IL or missing references)
		//IL_457e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4584: Unknown result type (might be due to invalid IL or missing references)
		//IL_4589: Unknown result type (might be due to invalid IL or missing references)
		//IL_4764: Unknown result type (might be due to invalid IL or missing references)
		//IL_476a: Unknown result type (might be due to invalid IL or missing references)
		//IL_476f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4794: Unknown result type (might be due to invalid IL or missing references)
		//IL_479e: Unknown result type (might be due to invalid IL or missing references)
		//IL_47a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_47c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_47d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_47d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_4820: Unknown result type (might be due to invalid IL or missing references)
		//IL_4826: Unknown result type (might be due to invalid IL or missing references)
		//IL_482b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4850: Unknown result type (might be due to invalid IL or missing references)
		//IL_485a: Unknown result type (might be due to invalid IL or missing references)
		//IL_485f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4884: Unknown result type (might be due to invalid IL or missing references)
		//IL_488e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4893: Unknown result type (might be due to invalid IL or missing references)
		//IL_48dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_48e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_48e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_490c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4916: Unknown result type (might be due to invalid IL or missing references)
		//IL_491b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4940: Unknown result type (might be due to invalid IL or missing references)
		//IL_494a: Unknown result type (might be due to invalid IL or missing references)
		//IL_494f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4986: Unknown result type (might be due to invalid IL or missing references)
		//IL_498c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4991: Unknown result type (might be due to invalid IL or missing references)
		//IL_49b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_49c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_49c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_49ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_49f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_49f9: Unknown result type (might be due to invalid IL or missing references)
		if (player.soulDrain > 0 && ((Entity)player).whoAmI == Main.myPlayer)
		{
			player.AddBuff(151, 2, true, false);
		}
		if (Main.dontStarveWorld)
		{
			player.UpdateStarvingState(true);
		}
		for (int j = 0; j < Player.MaxBuffs; j++)
		{
			if (player.buffType[j] <= 0 || player.buffTime[j] <= 0)
			{
				continue;
			}
			if (((Entity)player).whoAmI == Main.myPlayer && !Sets.TimeLeftDoesNotDecrease[player.buffType[j]])
			{
				player.buffTime[j]--;
			}
			if (V2.ModifiedStatusEffects.ContainsKey(player.buffType[j]))
			{
				V2.ModifiedStatusEffects[player.buffType[j]].Update(player.buffType[j], player, ref j);
				continue;
			}
			int originalIndex = j;
			if (player.buffType[j] == 1)
			{
				player.lavaImmune = true;
				player.fireWalk = true;
				player.buffImmune[24] = true;
			}
			else if (Sets.BasicMountData[player.buffType[j]] != null)
			{
				BuffMountData buffMountData = Sets.BasicMountData[player.buffType[j]];
				player.mount.SetMount(buffMountData.mountID, player, buffMountData.faceLeft);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 158)
			{
				player.manaRegenDelayBonus += 0.5f;
				player.manaRegenBonus += 10;
			}
			else if (player.buffType[j] == 159)
			{
				player.GetArmorPenetration(DamageClass.Melee) += 12f;
			}
			else if (player.buffType[j] == 192)
			{
				player.pickSpeed -= 0.2f;
				player.moveSpeed += 0.2f;
			}
			else if (player.buffType[j] == 321)
			{
				player.GetCritChance(DamageClass.Generic) += 10f;
				ref StatModifier damage = ref player.GetDamage(DamageClass.Summon);
				damage += 0.1f;
			}
			else if (player.buffType[j] == 3)
			{
				player.moveSpeed += 0.25f;
			}
			else if (player.buffType[j] == 4)
			{
				player.gills = true;
			}
			else if (player.buffType[j] == 5)
			{
				player.statDefense += 8;
			}
			else if (player.buffType[j] == 6)
			{
				player.manaRegenBuff = true;
			}
			else if (player.buffType[j] == 7)
			{
				ref StatModifier damage2 = ref player.GetDamage(DamageClass.Magic);
				damage2 += 0.2f;
			}
			else if (player.buffType[j] == 8)
			{
				player.slowFall = true;
			}
			else if (player.buffType[j] == 9)
			{
				player.findTreasure = true;
			}
			else if (player.buffType[j] == 343)
			{
				player.biomeSight = true;
			}
			else if (player.buffType[j] == 10)
			{
				player.invis = true;
			}
			else if (player.buffType[j] == 11)
			{
				Lighting.AddLight((int)(((Entity)player).position.X + (float)(((Entity)player).width / 2)) / 16, (int)(((Entity)player).position.Y + (float)(((Entity)player).height / 2)) / 16, 0.8f, 0.95f, 1f);
			}
			else if (player.buffType[j] == 12)
			{
				player.nightVision = true;
			}
			else if (player.buffType[j] == 13)
			{
				player.enemySpawns = true;
			}
			else if (player.buffType[j] == 14)
			{
				if (player.thorns < 1f)
				{
					player.thorns = 1f;
				}
			}
			else if (player.buffType[j] == 15)
			{
				player.waterWalk = true;
			}
			else if (player.buffType[j] == 16)
			{
				player.archery = true;
				player.arrowDamage *= 1.1f;
			}
			else if (player.buffType[j] == 17)
			{
				player.detectCreature = true;
			}
			else if (player.buffType[j] == 18)
			{
				player.gravControl = true;
			}
			else if (player.buffType[j] == 30)
			{
				player.bleed = true;
			}
			else if (player.buffType[j] == 31)
			{
				player.confused = true;
			}
			else if (player.buffType[j] == 32)
			{
				player.slow = true;
			}
			else if (player.buffType[j] == 35)
			{
				player.silence = true;
			}
			else if (player.buffType[j] == 160)
			{
				player.dazed = true;
			}
			else if (player.buffType[j] == 46)
			{
				player.chilled = true;
			}
			else if (player.buffType[j] == 47)
			{
				player.frozen = true;
			}
			else if (player.buffType[j] == 156)
			{
				player.stoned = true;
			}
			else if (player.buffType[j] == 69)
			{
				player.ichor = true;
				player.statDefense -= 15;
			}
			else if (player.buffType[j] == 36)
			{
				player.brokenArmor = true;
			}
			else if (player.buffType[j] == 48)
			{
				player.honey = true;
			}
			else if (player.buffType[j] == 59)
			{
				player.shadowDodge = true;
			}
			else if (player.buffType[j] == 93)
			{
				player.ammoBox = true;
			}
			else if (player.buffType[j] == 58)
			{
				player.palladiumRegen = true;
			}
			else if (player.buffType[j] == 306)
			{
				player.hasTitaniumStormBuff = true;
			}
			else if (player.buffType[j] == 88)
			{
				player.chaosState = true;
			}
			else if (player.buffType[j] == 215)
			{
				player.statDefense += 5;
			}
			else if (player.buffType[j] == 311)
			{
				player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.35f;
			}
			else if (player.buffType[j] == 308)
			{
				player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.25f;
			}
			else if (player.buffType[j] == 314)
			{
				player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.12f;
			}
			else if (player.buffType[j] == 312)
			{
				player.coolWhipBuff = true;
			}
			else if (player.buffType[j] == 63)
			{
				player.moveSpeed += 1f;
			}
			else if (player.buffType[j] == 104)
			{
				player.pickSpeed -= 0.25f;
			}
			else if (player.buffType[j] == 105)
			{
				player.lifeMagnet = true;
			}
			else if (player.buffType[j] == 106)
			{
				player.calmed = true;
			}
			else if (player.buffType[j] == 121)
			{
				player.fishingSkill += 15;
			}
			else if (player.buffType[j] == 122)
			{
				player.sonarPotion = true;
			}
			else if (player.buffType[j] == 123)
			{
				player.cratePotion = true;
			}
			else if (player.buffType[j] == 107)
			{
				player.tileSpeed += 0.25f;
				player.wallSpeed += 0.25f;
				player.blockRange++;
			}
			else if (player.buffType[j] == 108)
			{
				player.kbBuff = true;
			}
			else if (player.buffType[j] == 109)
			{
				player.ignoreWater = true;
				player.accFlipper = true;
			}
			else if (player.buffType[j] == 110)
			{
				player.maxMinions++;
			}
			else if (player.buffType[j] == 150)
			{
				player.maxMinions++;
			}
			else if (player.buffType[j] == 348)
			{
				player.maxTurrets++;
			}
			else if (player.buffType[j] == 111)
			{
				player.dangerSense = true;
			}
			else if (player.buffType[j] == 112)
			{
				player.ammoPotion = true;
			}
			else if (player.buffType[j] == 113)
			{
				player.lifeForce = true;
				player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
			}
			else if (player.buffType[j] == 114)
			{
				player.endurance += 0.1f;
			}
			else if (player.buffType[j] == 115)
			{
				player.GetCritChance(DamageClass.Generic) += 10f;
			}
			else if (player.buffType[j] == 116)
			{
				player.inferno = true;
				Lighting.AddLight((int)(((Entity)player).Center.X / 16f), (int)(((Entity)player).Center.Y / 16f), 0.65f, 0.4f, 0.1f);
				int num2 = 323;
				float num3 = 200f;
				bool flag = player.infernoCounter % 60 == 0;
				int damage3 = 20;
				if (((Entity)player).whoAmI != Main.myPlayer)
				{
					continue;
				}
				for (int k = 0; k < 200; k++)
				{
					NPC nPC = Main.npc[k];
					if (((Entity)nPC).active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num2] && player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC, (Projectile)null) && Vector2.Distance(((Entity)player).Center, ((Entity)nPC).Center) <= num3)
					{
						if (nPC.FindBuffIndex(num2) == -1)
						{
							nPC.AddBuff(num2, 120, false);
						}
						if (flag)
						{
							player.ApplyDamageToNPC(nPC, damage3, 0f, 0, false, (DamageClass)null, false);
						}
					}
				}
				if (!player.hostile)
				{
					continue;
				}
				for (int l = 0; l < 255; l++)
				{
					Player otherPlayer = Main.player[l];
					if (otherPlayer != player && ((Entity)otherPlayer).active && !otherPlayer.dead && otherPlayer.hostile && !otherPlayer.buffImmune[num2] && (otherPlayer.team != player.team || otherPlayer.team == 0) && Vector2.Distance(((Entity)player).Center, ((Entity)otherPlayer).Center) <= num3)
					{
						if (otherPlayer.FindBuffIndex(num2) == -1)
						{
							otherPlayer.AddBuff(num2, 120, true, false);
						}
						if (flag)
						{
							PlayerDeathReason reason = PlayerDeathReason.ByOther(16, ((Entity)otherPlayer).whoAmI);
							otherPlayer.Hurt(reason, damage3, 0, true, false, -1, true, 0f, 0f, 4.5f);
						}
					}
				}
			}
			else if (player.buffType[j] == 117)
			{
				ref StatModifier damage4 = ref player.GetDamage(DamageClass.Generic);
				damage4 += 0.1f;
			}
			else if (player.buffType[j] == 119)
			{
				player.loveStruck = true;
			}
			else if (player.buffType[j] == 120)
			{
				player.stinky = true;
			}
			else if (player.buffType[j] == 124)
			{
				player.resistCold = true;
			}
			else if (player.buffType[j] == 257)
			{
				if (Main.myPlayer == ((Entity)player).whoAmI)
				{
					if (player.buffTime[j] > 36000)
					{
						player.luckPotion = 3;
					}
					else if (player.buffTime[j] > 18000)
					{
						player.luckPotion = 2;
					}
					else
					{
						player.luckPotion = 1;
					}
				}
			}
			else if (player.buffType[j] == 144)
			{
				player.electrified = true;
				Lighting.AddLight((int)((Entity)player).Center.X / 16, (int)((Entity)player).Center.Y / 16, 0.3f, 0.8f, 1.1f);
			}
			else if (player.buffType[j] == 94)
			{
				player.manaSick = true;
				player.manaSickReduction = Player.manaSickLessDmg * ((float)player.buffTime[j] / (float)Player.manaSickTime);
			}
			else if (player.buffType[j] >= 95 && player.buffType[j] <= 97)
			{
				player.buffTime[j] = 5;
				int num4 = (byte)(1 + player.buffType[j] - 95);
				if (player.beetleOrbs > 0 && player.beetleOrbs != num4)
				{
					if (player.beetleOrbs > num4)
					{
						player.DelBuff(j);
						j--;
					}
					else
					{
						for (int m = 0; m < Player.MaxBuffs; m++)
						{
							if (player.buffType[m] >= 95 && player.buffType[m] <= 95 + num4 - 1)
							{
								player.DelBuff(m);
								m--;
							}
						}
					}
				}
				player.beetleOrbs = num4;
				if (!player.beetleDefense)
				{
					player.beetleOrbs = 0;
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.beetleBuff = true;
				}
			}
			else if (player.buffType[j] >= 170 && player.buffType[j] <= 172)
			{
				player.buffTime[j] = 5;
				int num5 = (byte)(1 + player.buffType[j] - 170);
				if (player.solarShields > 0 && player.solarShields != num5)
				{
					if (player.solarShields > num5)
					{
						player.DelBuff(j);
						j--;
					}
					else
					{
						for (int n = 0; n < Player.MaxBuffs; n++)
						{
							if (player.buffType[n] >= 170 && player.buffType[n] <= 170 + num5 - 1)
							{
								player.DelBuff(n);
								n--;
							}
						}
					}
				}
				player.solarShields = num5;
				if (!player.setSolar)
				{
					player.solarShields = 0;
					player.DelBuff(j);
					j--;
				}
			}
			else if (player.buffType[j] >= 98 && player.buffType[j] <= 100)
			{
				int num6 = (byte)(1 + player.buffType[j] - 98);
				if (player.beetleOrbs > 0 && player.beetleOrbs != num6)
				{
					if (player.beetleOrbs > num6)
					{
						player.DelBuff(j);
						j--;
					}
					else
					{
						for (int i = 0; i < Player.MaxBuffs; i++)
						{
							if (player.buffType[i] >= 98 && player.buffType[i] <= 98 + num6 - 1)
							{
								player.DelBuff(i);
								i--;
							}
						}
					}
				}
				player.beetleOrbs = num6;
				ref StatModifier damage5 = ref player.GetDamage(DamageClass.Melee);
				damage5 += 0.1f * (float)player.beetleOrbs;
				player.GetAttackSpeed(DamageClass.Melee) += 0.1f * (float)player.beetleOrbs;
				if (!player.beetleOffense)
				{
					player.beetleOrbs = 0;
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.beetleBuff = true;
				}
			}
			else if (player.buffType[j] >= 176 && player.buffType[j] <= 178)
			{
				int num8 = player.nebulaLevelMana;
				int num9 = (byte)(1 + player.buffType[j] - 176);
				if (num8 > 0 && num8 != num9)
				{
					if (num8 > num9)
					{
						player.DelBuff(j);
						j--;
					}
					else
					{
						for (int num10 = 0; num10 < Player.MaxBuffs; num10++)
						{
							if (player.buffType[num10] >= 176 && player.buffType[num10] <= 178 + num9 - 1)
							{
								player.DelBuff(num10);
								num10--;
							}
						}
					}
				}
				player.nebulaLevelMana = num9;
				if (player.buffTime[j] == 2 && player.nebulaLevelMana > 1)
				{
					player.nebulaLevelMana--;
					player.buffType[j]--;
					player.buffTime[j] = 480;
				}
			}
			else if (player.buffType[j] >= 173 && player.buffType[j] <= 175)
			{
				int num11 = player.nebulaLevelLife;
				int num12 = (byte)(1 + player.buffType[j] - 173);
				if (num11 > 0 && num11 != num12)
				{
					if (num11 > num12)
					{
						player.DelBuff(j);
						j--;
					}
					else
					{
						for (int num13 = 0; num13 < Player.MaxBuffs; num13++)
						{
							if (player.buffType[num13] >= 173 && player.buffType[num13] <= 175 + num12 - 1)
							{
								player.DelBuff(num13);
								num13--;
							}
						}
					}
				}
				player.nebulaLevelLife = num12;
				if (player.buffTime[j] == 2 && player.nebulaLevelLife > 1)
				{
					player.nebulaLevelLife--;
					player.buffType[j]--;
					player.buffTime[j] = 480;
				}
				player.AddHealthRegenEffect(3 * player.nebulaLevelLife);
			}
			else if (player.buffType[j] >= 179 && player.buffType[j] <= 181)
			{
				int num14 = player.nebulaLevelDamage;
				int num15 = (byte)(1 + player.buffType[j] - 179);
				if (num14 > 0 && num14 != num15)
				{
					if (num14 > num15)
					{
						player.DelBuff(j);
						j--;
					}
					else
					{
						for (int num16 = 0; num16 < Player.MaxBuffs; num16++)
						{
							if (player.buffType[num16] >= 179 && player.buffType[num16] <= 181 + num15 - 1)
							{
								player.DelBuff(num16);
								num16--;
							}
						}
					}
				}
				player.nebulaLevelDamage = num15;
				if (player.buffTime[j] == 2 && player.nebulaLevelDamage > 1)
				{
					player.nebulaLevelDamage--;
					player.buffType[j]--;
					player.buffTime[j] = 480;
				}
				ref StatModifier damage6 = ref player.GetDamage(DamageClass.Generic);
				damage6 += 0.15f * (float)player.nebulaLevelDamage;
			}
			else if (player.buffType[j] == 62)
			{
				if ((double)player.statLife <= (double)player.statLifeMax2 * 0.5)
				{
					Lighting.AddLight((int)(((Entity)player).Center.X / 16f), (int)(((Entity)player).Center.Y / 16f), 0.1f, 0.2f, 0.45f);
					player.iceBarrier = true;
					player.endurance += 0.25f;
					player.iceBarrierFrameCounter++;
					if (player.iceBarrierFrameCounter > 2)
					{
						player.iceBarrierFrameCounter = 0;
						player.iceBarrierFrame++;
						if (player.iceBarrierFrame >= 12)
						{
							player.iceBarrierFrame = 0;
						}
					}
				}
				else
				{
					player.DelBuff(j);
					j--;
				}
			}
			else if (player.buffType[j] == 49)
			{
				for (int num17 = 191; num17 <= 194; num17++)
				{
					if (player.ownedProjectileCounts[num17] > 0)
					{
						player.pygmy = true;
					}
				}
				if (!player.pygmy)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 83)
			{
				if (player.ownedProjectileCounts[317] > 0)
				{
					player.raven = true;
				}
				if (!player.raven)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 64)
			{
				if (player.ownedProjectileCounts[266] > 0)
				{
					player.slime = true;
				}
				if (!player.slime)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 125)
			{
				if (player.ownedProjectileCounts[373] > 0)
				{
					player.hornetMinion = true;
				}
				if (!player.hornetMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 126)
			{
				if (player.ownedProjectileCounts[375] > 0)
				{
					player.impMinion = true;
				}
				if (!player.impMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 133)
			{
				if (player.ownedProjectileCounts[390] > 0 || player.ownedProjectileCounts[391] > 0 || player.ownedProjectileCounts[392] > 0)
				{
					player.spiderMinion = true;
				}
				if (!player.spiderMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 134)
			{
				if (player.ownedProjectileCounts[387] > 0 || player.ownedProjectileCounts[388] > 0)
				{
					player.twinsMinion = true;
				}
				if (!player.twinsMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 135)
			{
				if (player.ownedProjectileCounts[393] > 0 || player.ownedProjectileCounts[394] > 0 || player.ownedProjectileCounts[395] > 0)
				{
					player.pirateMinion = true;
				}
				if (!player.pirateMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 214)
			{
				if (player.ownedProjectileCounts[758] > 0)
				{
					player.vampireFrog = true;
				}
				if (!player.vampireFrog)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 139)
			{
				if (player.ownedProjectileCounts[407] > 0)
				{
					player.sharknadoMinion = true;
				}
				if (!player.sharknadoMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 140)
			{
				if (player.ownedProjectileCounts[423] > 0)
				{
					player.UFOMinion = true;
				}
				if (!player.UFOMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 182)
			{
				if (player.ownedProjectileCounts[613] > 0)
				{
					player.stardustMinion = true;
				}
				if (!player.stardustMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 213)
			{
				if (player.ownedProjectileCounts[755] > 0)
				{
					player.batsOfLight = true;
				}
				if (!player.batsOfLight)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 216)
			{
				bool flag2 = true;
				if (player.ownedProjectileCounts[759] > 0)
				{
					player.babyBird = true;
				}
				else if (((Entity)player).whoAmI == Main.myPlayer)
				{
					if (player.numMinions < player.maxMinions)
					{
						int num19 = player.FindItem(4281);
						if (num19 != -1)
						{
							Item item = player.inventory[num19];
							int num20 = Projectile.NewProjectile(player.GetSource_ItemUse(item, (string)null), ((Entity)player).Top, Vector2.Zero, item.shoot, item.damage, item.knockBack, ((Entity)player).whoAmI, 0f, 0f, 0f);
							Main.projectile[num20].originalDamage = item.damage;
							player.babyBird = true;
						}
					}
					if (!player.babyBird)
					{
						player.DelBuff(j);
						j--;
						flag2 = false;
					}
				}
				if (flag2)
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 325)
			{
				if (player.ownedProjectileCounts[951] > 0)
				{
					player.flinxMinion = true;
				}
				if (!player.flinxMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 335)
			{
				if (player.ownedProjectileCounts[970] > 0)
				{
					player.abigailMinion = true;
				}
				if (!player.abigailMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
				if (((Entity)player).whoAmI == Main.myPlayer)
				{
					UpdateAbigailStatus(player);
				}
			}
			else if (player.buffType[j] == 263)
			{
				if (player.ownedProjectileCounts[831] > 0)
				{
					player.stormTiger = true;
				}
				if (!player.stormTiger)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
				if (((Entity)player).whoAmI == Main.myPlayer)
				{
					UpdateStormTigerStatus(player);
				}
			}
			else if (player.buffType[j] == 271)
			{
				if (player.ownedProjectileCounts[864] > 0)
				{
					player.smolstar = true;
				}
				if (!player.smolstar)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 322)
			{
				if (player.ownedProjectileCounts[946] > 0)
				{
					player.empressBlade = true;
				}
				if (!player.empressBlade)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 187)
			{
				if (player.ownedProjectileCounts[623] > 0)
				{
					player.stardustGuardian = true;
				}
				if (!player.stardustGuardian)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 188)
			{
				if (player.ownedProjectileCounts[625] > 0)
				{
					player.stardustDragon = true;
				}
				if (!player.stardustDragon)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 161)
			{
				if (player.ownedProjectileCounts[533] > 0)
				{
					player.DeadlySphereMinion = true;
				}
				if (!player.DeadlySphereMinion)
				{
					player.DelBuff(j);
					j--;
				}
				else
				{
					player.buffTime[j] = 18000;
				}
			}
			else if (player.buffType[j] == 90)
			{
				player.mount.SetMount(0, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 128)
			{
				player.mount.SetMount(1, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 129)
			{
				player.mount.SetMount(2, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 130)
			{
				player.mount.SetMount(3, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 131)
			{
				player.ignoreWater = true;
				player.accFlipper = true;
				player.mount.SetMount(4, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 132)
			{
				player.mount.SetMount(5, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 168)
			{
				player.ignoreWater = true;
				player.accFlipper = true;
				player.mount.SetMount(12, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 141)
			{
				player.mount.SetMount(7, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 142)
			{
				player.mount.SetMount(8, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 143)
			{
				player.mount.SetMount(9, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 162)
			{
				player.mount.SetMount(10, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 193)
			{
				player.mount.SetMount(14, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 212)
			{
				player.mount.SetMount(17, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 230)
			{
				player.mount.SetMount(23, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 265)
			{
				player.canFloatInWater = true;
				player.accFlipper = true;
				player.mount.SetMount(37, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 275)
			{
				player.mount.SetMount(40, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 276)
			{
				player.mount.SetMount(41, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 277)
			{
				player.mount.SetMount(42, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 278)
			{
				player.mount.SetMount(43, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 279)
			{
				player.ignoreWater = true;
				player.accFlipper = true;
				player.mount.SetMount(44, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 280)
			{
				player.mount.SetMount(45, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 281)
			{
				player.mount.SetMount(46, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 282)
			{
				player.mount.SetMount(47, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 283)
			{
				player.mount.SetMount(48, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 305)
			{
				player.ignoreWater = true;
				player.accFlipper = true;
				player.lavaImmune = true;
				player.mount.SetMount(49, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 318)
			{
				player.mount.SetMount(50, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 342)
			{
				player.mount.SetMount(52, player, false);
				player.buffTime[j] = 10;
			}
			else if (player.buffType[j] == 37)
			{
				if (Main.wofNPCIndex >= 0 && Main.npc[Main.wofNPCIndex].type == 113)
				{
					player.gross = true;
					player.buffTime[j] = 10;
				}
				else
				{
					player.DelBuff(j);
					j--;
				}
			}
			else if (player.buffType[j] == 38)
			{
				player.buffTime[j] = 10;
				player.tongued = true;
			}
			else if (player.buffType[j] == 146)
			{
				player.moveSpeed += 0.1f;
				player.moveSpeed *= 1.1f;
				player.sunflower = true;
			}
			else if (player.buffType[j] == 19)
			{
				player.buffTime[j] = 18000;
				player.lightOrb = true;
				bool flag3 = true;
				if (player.ownedProjectileCounts[18] > 0)
				{
					flag3 = false;
				}
				if (flag3 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 18, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 155)
			{
				player.buffTime[j] = 18000;
				player.crimsonHeart = true;
				bool flag4 = true;
				if (player.ownedProjectileCounts[500] > 0)
				{
					flag4 = false;
				}
				if (flag4 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 500, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 191)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.companionCube, 653, 18000);
			}
			else if (player.buffType[j] == 202)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDD2Dragon, 701, 18000);
			}
			else if (player.buffType[j] == 217)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagUpbeatStar, 764, 18000);
			}
			else if (player.buffType[j] == 219)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBabyShark, 774, 18000);
			}
			else if (player.buffType[j] == 258)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagLilHarpy, 815, 18000);
			}
			else if (player.buffType[j] == 259)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagFennecFox, 816, 18000);
			}
			else if (player.buffType[j] == 260)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagGlitteryButterfly, 817, 18000);
			}
			else if (player.buffType[j] == 261)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBabyImp, 821, 18000);
			}
			else if (player.buffType[j] == 262)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBabyRedPanda, 825, 18000);
			}
			else if (player.buffType[j] == 264)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagPlantero, 854, 18000);
			}
			else if (player.buffType[j] == 266)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDynamiteKitten, 858, 18000);
			}
			else if (player.buffType[j] == 267)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBabyWerewolf, 859, 18000);
			}
			else if (player.buffType[j] == 268)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagShadowMimic, 860, 18000);
			}
			else if (player.buffType[j] == 274)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagVoltBunny, 875, 18000);
			}
			else if (player.buffType[j] == 284)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagKingSlimePet, 881, 18000);
			}
			else if (player.buffType[j] == 285)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagEyeOfCthulhuPet, 882, 18000);
			}
			else if (player.buffType[j] == 286)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagEaterOfWorldsPet, 883, 18000);
			}
			else if (player.buffType[j] == 287)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBrainOfCthulhuPet, 884, 18000);
			}
			else if (player.buffType[j] == 288)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagSkeletronPet, 885, 18000);
			}
			else if (player.buffType[j] == 289)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagQueenBeePet, 886, 18000);
			}
			else if (player.buffType[j] == 290)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDestroyerPet, 887, 18000);
			}
			else if (player.buffType[j] == 291)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagTwinsPet, 888, 18000);
			}
			else if (player.buffType[j] == 292)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagSkeletronPrimePet, 889, 18000);
			}
			else if (player.buffType[j] == 293)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagPlanteraPet, 890, 18000);
			}
			else if (player.buffType[j] == 294)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagGolemPet, 891, 18000);
			}
			else if (player.buffType[j] == 295)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDukeFishronPet, 892, 18000);
			}
			else if (player.buffType[j] == 296)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagLunaticCultistPet, 893, 18000);
			}
			else if (player.buffType[j] == 297)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagMoonLordPet, 894, 18000);
			}
			else if (player.buffType[j] == 298)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagFairyQueenPet, 895, 18000);
			}
			else if (player.buffType[j] == 299)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagPumpkingPet, 896, 18000);
			}
			else if (player.buffType[j] == 300)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagEverscreamPet, 897, 18000);
			}
			else if (player.buffType[j] == 301)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagIceQueenPet, 898, 18000);
			}
			else if (player.buffType[j] == 302)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagMartianPet, 899, 18000);
			}
			else if (player.buffType[j] == 303)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDD2OgrePet, 900, 18000);
			}
			else if (player.buffType[j] == 304)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDD2BetsyPet, 901, 18000);
			}
			else if (player.buffType[j] == 317)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagQueenSlimePet, 934, 18000);
			}
			else if (player.buffType[j] == 327)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBerniePet, 956, 18000);
			}
			else if (player.buffType[j] == 328)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagGlommerPet, 957, 18000);
			}
			else if (player.buffType[j] == 329)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDeerclopsPet, 958, 18000);
			}
			else if (player.buffType[j] == 330)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagPigPet, 959, 18000);
			}
			else if (player.buffType[j] == 331)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagChesterPet, 960, 18000);
			}
			else if (player.buffType[j] == 341)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagKingSlimePet, 881, 18000);
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagQueenSlimePet, 934, 18000);
			}
			else if (player.buffType[j] == 345)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagJunimoPet, 994, 18000);
			}
			else if (player.buffType[j] == 349)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagBlueChickenPet, 998, 18000);
			}
			else if (player.buffType[j] == 351)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagSpiffo, 1003, 18000);
			}
			else if (player.buffType[j] == 352)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagCaveling, 1004, 18000);
			}
			else if (player.buffType[j] == 354)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDirtiestBlock, 1018, 18000);
			}
			else if (player.buffType[j] == 200)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDD2Gato, 703, 18000);
			}
			else if (player.buffType[j] == 201)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagDD2Ghost, 702, 18000);
			}
			else if (player.buffType[j] == 218)
			{
				player.BuffHandle_SpawnPetIfNeededAndSetTime(j, ref player.petFlagSugarGlider, 765, 18000);
			}
			else if (player.buffType[j] == 190)
			{
				player.buffTime[j] = 18000;
				player.suspiciouslookingTentacle = true;
				bool flag5 = true;
				if (player.ownedProjectileCounts[650] > 0)
				{
					flag5 = false;
				}
				if (flag5 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 650, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 27 || player.buffType[j] == 101 || player.buffType[j] == 102)
			{
				player.buffTime[j] = 18000;
				bool flag6 = true;
				int num21 = 72;
				if (player.buffType[j] == 27)
				{
					player.blueFairy = true;
				}
				if (player.buffType[j] == 101)
				{
					num21 = 86;
					player.redFairy = true;
				}
				if (player.buffType[j] == 102)
				{
					num21 = 87;
					player.greenFairy = true;
				}
				if (player.head == 45 && player.body == 26 && player.legs == 25)
				{
					num21 = 72;
				}
				if (player.ownedProjectileCounts[num21] > 0)
				{
					flag6 = false;
				}
				if (flag6 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, num21, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 40)
			{
				player.buffTime[j] = 18000;
				player.bunny = true;
				bool flag7 = true;
				if (player.ownedProjectileCounts[111] > 0)
				{
					flag7 = false;
				}
				if (flag7 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 111, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 148)
			{
				player.rabid = true;
				if (Utils.NextBool(Main.rand, 1200))
				{
					int num22 = Main.rand.Next(6);
					float num23 = (float)Main.rand.Next(60, 100) * 0.01f;
					switch (num22)
					{
					case 0:
						player.AddBuff(22, (int)(60f * num23 * 3f), true, false);
						break;
					case 1:
						player.AddBuff(23, (int)(60f * num23 * 0.75f), true, false);
						break;
					case 2:
						player.AddBuff(31, (int)(60f * num23 * 1.5f), true, false);
						break;
					case 3:
						player.AddBuff(32, (int)(60f * num23 * 3.5f), true, false);
						break;
					case 4:
						player.AddBuff(33, (int)(60f * num23 * 5f), true, false);
						break;
					case 5:
						player.AddBuff(35, (int)(60f * num23 * 1f), true, false);
						break;
					}
				}
				ref StatModifier damage7 = ref player.GetDamage(DamageClass.Generic);
				damage7 += 0.2f;
			}
			else if (player.buffType[j] == 41)
			{
				player.buffTime[j] = 18000;
				player.penguin = true;
				bool flag8 = true;
				if (player.ownedProjectileCounts[112] > 0)
				{
					flag8 = false;
				}
				if (flag8 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 112, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 152)
			{
				player.buffTime[j] = 18000;
				player.magicLantern = true;
				if (player.ownedProjectileCounts[492] == 0 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 492, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 91)
			{
				player.buffTime[j] = 18000;
				player.puppy = true;
				bool flag9 = true;
				if (player.ownedProjectileCounts[334] > 0)
				{
					flag9 = false;
				}
				if (flag9 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 334, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 92)
			{
				player.buffTime[j] = 18000;
				player.grinch = true;
				bool flag10 = true;
				if (player.ownedProjectileCounts[353] > 0)
				{
					flag10 = false;
				}
				if (flag10 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 353, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 84)
			{
				player.buffTime[j] = 18000;
				player.blackCat = true;
				bool flag11 = true;
				if (player.ownedProjectileCounts[319] > 0)
				{
					flag11 = false;
				}
				if (flag11 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 319, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 61)
			{
				player.buffTime[j] = 18000;
				player.dino = true;
				bool flag12 = true;
				if (player.ownedProjectileCounts[236] > 0)
				{
					flag12 = false;
				}
				if (flag12 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 236, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 154)
			{
				player.buffTime[j] = 18000;
				player.babyFaceMonster = true;
				bool flag13 = true;
				if (player.ownedProjectileCounts[499] > 0)
				{
					flag13 = false;
				}
				if (flag13 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 499, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 65)
			{
				player.buffTime[j] = 18000;
				player.eyeSpring = true;
				bool flag14 = true;
				if (player.ownedProjectileCounts[268] > 0)
				{
					flag14 = false;
				}
				if (flag14 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 268, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 66)
			{
				player.buffTime[j] = 18000;
				player.snowman = true;
				bool flag15 = true;
				if (player.ownedProjectileCounts[269] > 0)
				{
					flag15 = false;
				}
				if (flag15 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 269, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 42)
			{
				player.buffTime[j] = 18000;
				player.turtle = true;
				bool flag16 = true;
				if (player.ownedProjectileCounts[127] > 0)
				{
					flag16 = false;
				}
				if (flag16 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 127, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 45)
			{
				player.buffTime[j] = 18000;
				player.eater = true;
				bool flag17 = true;
				if (player.ownedProjectileCounts[175] > 0)
				{
					flag17 = false;
				}
				if (flag17 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 175, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 50)
			{
				player.buffTime[j] = 18000;
				player.skeletron = true;
				bool flag18 = true;
				if (player.ownedProjectileCounts[197] > 0)
				{
					flag18 = false;
				}
				if (flag18 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 197, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 51)
			{
				player.buffTime[j] = 18000;
				player.hornet = true;
				bool flag19 = true;
				if (player.ownedProjectileCounts[198] > 0)
				{
					flag19 = false;
				}
				if (flag19 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 198, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 52)
			{
				player.buffTime[j] = 18000;
				player.tiki = true;
				bool flag20 = true;
				if (player.ownedProjectileCounts[199] > 0)
				{
					flag20 = false;
				}
				if (flag20 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 199, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 53)
			{
				player.buffTime[j] = 18000;
				player.lizard = true;
				bool flag21 = true;
				if (player.ownedProjectileCounts[200] > 0)
				{
					flag21 = false;
				}
				if (flag21 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 200, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 54)
			{
				player.buffTime[j] = 18000;
				player.parrot = true;
				bool flag22 = true;
				if (player.ownedProjectileCounts[208] > 0)
				{
					flag22 = false;
				}
				if (flag22 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 208, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 55)
			{
				player.buffTime[j] = 18000;
				player.truffle = true;
				bool flag23 = true;
				if (player.ownedProjectileCounts[209] > 0)
				{
					flag23 = false;
				}
				if (flag23 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 209, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 56)
			{
				player.buffTime[j] = 18000;
				player.sapling = true;
				bool flag24 = true;
				if (player.ownedProjectileCounts[210] > 0)
				{
					flag24 = false;
				}
				if (flag24 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 210, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 85)
			{
				player.buffTime[j] = 18000;
				player.cSapling = true;
				bool flag25 = true;
				if (player.ownedProjectileCounts[324] > 0)
				{
					flag25 = false;
				}
				if (flag25 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 324, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 81)
			{
				player.buffTime[j] = 18000;
				player.spider = true;
				bool flag26 = true;
				if (player.ownedProjectileCounts[313] > 0)
				{
					flag26 = false;
				}
				if (flag26 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 313, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 82)
			{
				player.buffTime[j] = 18000;
				player.squashling = true;
				bool flag27 = true;
				if (player.ownedProjectileCounts[314] > 0)
				{
					flag27 = false;
				}
				if (flag27 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 314, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 57)
			{
				player.buffTime[j] = 18000;
				player.wisp = true;
				bool flag28 = true;
				if (player.ownedProjectileCounts[211] > 0)
				{
					flag28 = false;
				}
				if (flag28 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 211, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 60)
			{
				player.buffTime[j] = 18000;
				player.crystalLeaf = true;
				bool flag29 = true;
				for (int num24 = 0; num24 < 1000; num24++)
				{
					if (((Entity)Main.projectile[num24]).active && Main.projectile[num24].owner == ((Entity)player).whoAmI && Main.projectile[num24].type == 226)
					{
						if (!flag29)
						{
							Main.projectile[num24].Kill();
						}
						flag29 = false;
					}
				}
				if (flag29 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 226, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 127)
			{
				player.buffTime[j] = 18000;
				player.zephyrfish = true;
				bool flag30 = true;
				if (player.ownedProjectileCounts[380] > 0)
				{
					flag30 = false;
				}
				if (flag30 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 380, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 136)
			{
				player.buffTime[j] = 18000;
				player.miniMinotaur = true;
				bool flag31 = true;
				if (player.ownedProjectileCounts[398] > 0)
				{
					flag31 = false;
				}
				if (flag31 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(player.GetSource_Buff(j), ((Entity)player).position.X + (float)(((Entity)player).width / 2), ((Entity)player).position.Y + (float)(((Entity)player).height / 2), 0f, 0f, 398, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
				}
			}
			else if (player.buffType[j] == 70)
			{
				player.venom = true;
			}
			else if (player.buffType[j] == 20)
			{
				player.poisoned = true;
			}
			else if (player.buffType[j] == 21)
			{
				player.potionDelay = player.buffTime[j];
			}
			else if (player.buffType[j] == 22)
			{
				player.blind = true;
			}
			else if (player.buffType[j] == 80)
			{
				player.blackout = true;
			}
			else if (player.buffType[j] == 23)
			{
				player.noItems = true;
				player.cursed = true;
			}
			else if (player.buffType[j] == 24)
			{
				player.onFire = true;
			}
			else if (player.buffType[j] == 103)
			{
				player.dripping = true;
			}
			else if (player.buffType[j] == 137)
			{
				player.drippingSlime = true;
			}
			else if (player.buffType[j] == 320)
			{
				player.drippingSparkleSlime = true;
			}
			else if (player.buffType[j] == 67)
			{
				player.burned = true;
			}
			else if (player.buffType[j] == 68)
			{
				player.suffocating = true;
			}
			else if (player.buffType[j] == 39)
			{
				player.onFire2 = true;
			}
			else if (player.buffType[j] == 323)
			{
				player.onFire3 = true;
			}
			else if (player.buffType[j] == 44)
			{
				player.onFrostBurn = true;
			}
			else if (player.buffType[j] == 324)
			{
				player.onFrostBurn2 = true;
			}
			else if (player.buffType[j] == 353)
			{
				player.shimmering = true;
				player.frozen = true;
				player.fallStart = (int)(((Entity)player).position.Y / 16f);
				if (Main.myPlayer != ((Entity)player).whoAmI)
				{
					continue;
				}
				if (((Entity)player).position.Y / 16f > (float)Main.UnderworldLayer)
				{
					if (Main.myPlayer == ((Entity)player).whoAmI)
					{
						player.DelBuff(j);
					}
					continue;
				}
				if (((Entity)player).shimmerWet)
				{
					player.buffTime[j] = 60;
					continue;
				}
				bool flag32 = false;
				for (int num25 = (int)(((Entity)player).position.X / 16f); (float)num25 <= (((Entity)player).position.X + (float)((Entity)player).width) / 16f; num25++)
				{
					for (int num26 = (int)(((Entity)player).position.Y / 16f); (float)num26 <= (((Entity)player).position.Y + (float)((Entity)player).height) / 16f; num26++)
					{
						if (WorldGen.SolidTile3(num25, num26))
						{
							flag32 = true;
						}
					}
				}
				if (flag32)
				{
					player.buffTime[j] = 6;
				}
				else
				{
					player.DelBuff(j);
				}
			}
			else if (player.buffType[j] == 163)
			{
				player.headcovered = true;
				player.bleed = true;
			}
			else if (player.buffType[j] == 164)
			{
				player.vortexDebuff = true;
			}
			else if (player.buffType[j] == 194)
			{
				player.windPushed = true;
			}
			else if (player.buffType[j] == 195)
			{
				player.witheredArmor = true;
			}
			else if (player.buffType[j] == 205)
			{
				player.ballistaPanic = true;
			}
			else if (player.buffType[j] == 196)
			{
				player.witheredWeapon = true;
			}
			else if (player.buffType[j] == 197)
			{
				player.slowOgreSpit = true;
			}
			else if (player.buffType[j] == 198)
			{
				player.parryDamageBuff = true;
			}
			else if (player.buffType[j] == 145)
			{
				player.moonLeech = true;
			}
			else if (player.buffType[j] == 149)
			{
				player.webbed = true;
				if (((Entity)player).velocity.Y != 0f)
				{
					((Entity)player).velocity = new Vector2(0f, 1E-06f);
				}
				else
				{
					((Entity)player).velocity = Vector2.Zero;
				}
				Player.jumpHeight = 0;
				player.gravity = 0f;
				player.moveSpeed = 0f;
				player.dash = 0;
				player.dashType = 0;
				player.noKnockback = true;
				player.RemoveAllGrapplingHooks();
			}
			else if (player.buffType[j] == 43)
			{
				player.defendedByPaladin = true;
			}
			else if (player.buffType[j] == 29)
			{
				player.GetCritChance(DamageClass.Magic) += 2f;
				ref StatModifier damage8 = ref player.GetDamage(DamageClass.Magic);
				damage8 += 0.05f;
				player.statManaMax2 += 20;
				player.manaCost -= 0.02f;
			}
			else if (player.buffType[j] == 28)
			{
				if (!Main.dayTime && player.wolfAcc && !player.merman)
				{
					player.AddHealthRegenEffect(0.5);
					player.wereWolf = true;
					player.GetCritChance(DamageClass.Melee) += 2f;
					ref StatModifier damage9 = ref player.GetDamage(DamageClass.Melee);
					damage9 += 0.051f;
					player.GetAttackSpeed(DamageClass.Melee) += 0.051f;
					player.statDefense += 3;
					player.moveSpeed += 0.05f;
				}
				else
				{
					player.DelBuff(j);
					j--;
				}
			}
			else if (player.buffType[j] == 33)
			{
				ref StatModifier damage10 = ref player.GetDamage(DamageClass.Melee);
				damage10 -= 0.051f;
				player.GetAttackSpeed(DamageClass.Melee) -= 0.051f;
				player.statDefense -= 4;
				player.moveSpeed -= 0.1f;
			}
			else if (player.buffType[j] == 25)
			{
				player.tipsy = true;
				player.statDefense -= 4;
				player.GetCritChance(DamageClass.Melee) += 2f;
				ref StatModifier damage11 = ref player.GetDamage(DamageClass.Melee);
				damage11 += 0.1f;
				player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
			}
			else if (player.buffType[j] == 26)
			{
				player.wellFed = true;
				player.statDefense += 2;
				player.GetCritChance(DamageClass.Generic) += 2f;
				ref StatModifier damage12 = ref player.GetDamage(DamageClass.Generic);
				damage12 += 0.05f;
				player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
				ref StatModifier knockback = ref player.GetKnockback(DamageClass.Summon);
				knockback += 0.5f;
				player.moveSpeed += 0.2f;
				player.pickSpeed -= 0.05f;
			}
			else if (player.buffType[j] == 206)
			{
				player.wellFed = true;
				player.statDefense += 3;
				player.GetCritChance(DamageClass.Generic) += 3f;
				ref StatModifier damage13 = ref player.GetDamage(DamageClass.Generic);
				damage13 += 0.075f;
				player.GetAttackSpeed(DamageClass.Melee) += 0.075f;
				ref StatModifier knockback2 = ref player.GetKnockback(DamageClass.Summon);
				knockback2 += 0.75f;
				player.moveSpeed += 0.3f;
				player.pickSpeed -= 0.1f;
			}
			else if (player.buffType[j] == 207)
			{
				player.wellFed = true;
				player.statDefense += 4;
				player.GetCritChance(DamageClass.Generic) += 4f;
				ref StatModifier damage14 = ref player.GetDamage(DamageClass.Generic);
				damage14 += 0.1f;
				player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
				ref StatModifier knockback3 = ref player.GetKnockback(DamageClass.Summon);
				knockback3 += 1f;
				player.moveSpeed += 0.4f;
				player.pickSpeed -= 0.15f;
			}
			else if (player.buffType[j] == 333)
			{
				player.hungry = true;
				player.statDefense -= 2;
				player.GetCritChance(DamageClass.Generic) -= 2f;
				ref StatModifier damage15 = ref player.GetDamage(DamageClass.Generic);
				damage15 -= 0.05f;
				player.GetAttackSpeed(DamageClass.Melee) -= 0.05f;
				ref StatModifier knockback4 = ref player.GetKnockback(DamageClass.Summon);
				knockback4 -= 0.5f;
				player.pickSpeed += 0.05f;
			}
			else if (player.buffType[j] == 334)
			{
				player.starving = true;
				player.statDefense -= 4;
				player.GetCritChance(DamageClass.Generic) -= 4f;
				ref StatModifier damage16 = ref player.GetDamage(DamageClass.Generic);
				damage16 -= 0.1f;
				player.GetAttackSpeed(DamageClass.Melee) -= 0.1f;
				ref StatModifier knockback5 = ref player.GetKnockback(DamageClass.Summon);
				knockback5 -= 1f;
				player.pickSpeed += 0.15f;
			}
			else if (player.buffType[j] == 336)
			{
				player.heartyMeal = true;
			}
			else if (player.buffType[j] == 71)
			{
				player.meleeEnchant = 1;
			}
			else if (player.buffType[j] == 73)
			{
				player.meleeEnchant = 2;
			}
			else if (player.buffType[j] == 74)
			{
				player.meleeEnchant = 3;
			}
			else if (player.buffType[j] == 75)
			{
				player.meleeEnchant = 4;
			}
			else if (player.buffType[j] == 76)
			{
				player.meleeEnchant = 5;
			}
			else if (player.buffType[j] == 77)
			{
				player.meleeEnchant = 6;
			}
			else if (player.buffType[j] == 78)
			{
				player.meleeEnchant = 7;
			}
			else if (player.buffType[j] == 79)
			{
				player.meleeEnchant = 8;
			}
			if (j == originalIndex)
			{
				BuffLoader.Update(player.buffType[j], player, ref j);
			}
		}
		player.UpdateHungerBuffs();
		if (((Entity)player).whoAmI == Main.myPlayer && player.luckPotion != player.oldLuckPotion)
		{
			player.luckNeedsSync = true;
			player.oldLuckPotion = player.luckPotion;
		}
	}

	private static void UpdateAbigailStatus(Player player)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		int num = 963;
		if (player.ownedProjectileCounts[970] < 1)
		{
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (((Entity)projectile).active && projectile.owner == ((Entity)player).whoAmI && projectile.type == num)
				{
					projectile.Kill();
				}
			}
		}
		else if (player.ownedProjectileCounts[num] < 1)
		{
			Projectile.NewProjectile(((Entity)player).GetSource_Misc("AbigailTierSwap"), ((Entity)player).Center, Vector2.Zero, num, 0, 0f, ((Entity)player).whoAmI, 0f, 0f, 0f);
		}
	}

	private static void UpdateStormTigerStatus(Player player)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		int num = GetDesiredStormTigerMinionRank(player) switch
		{
			1 => 833, 
			2 => 834, 
			3 => 835, 
			_ => -1, 
		};
		bool flag = false;
		if (num == -1)
		{
			flag = true;
		}
		for (int i = 0; i < Sets.StormTigerIds.Length; i++)
		{
			int num2 = Sets.StormTigerIds[i];
			if (num2 != num && player.ownedProjectileCounts[num2] >= 1)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			for (int j = 0; j < 1000; j++)
			{
				Projectile projectile = Main.projectile[j];
				if (((Entity)projectile).active && projectile.owner == ((Entity)player).whoAmI && projectile.type != num && Sets.StormTiger[projectile.type])
				{
					projectile.Kill();
				}
			}
		}
		else if (player.ownedProjectileCounts[num] < 1)
		{
			int num3 = Projectile.NewProjectile(((Entity)player).GetSource_Misc("StormTigerTierSwap"), ((Entity)player).Center, Vector2.Zero, num, 0, 0f, ((Entity)player).whoAmI, 0f, 1f, 0f);
			Main.projectile[num3].localAI[0] = 60f;
		}
	}

	private static int GetDesiredStormTigerMinionRank(Player player)
	{
		int result = 0;
		int num = player.ownedProjectileCounts[831];
		if (num > 0)
		{
			result = 1;
		}
		if (num > 3)
		{
			result = 2;
		}
		if (num > 6)
		{
			result = 3;
		}
		return result;
	}

	public static void ItemCheck_ReleaseCritter(Player player, Item sItem)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		if (sItem.makeNPC == 614)
		{
			player.ApplyItemTime(sItem, 1f, (bool?)null);
			int releasedCritterIndex = NPC.ReleaseNPC((int)((Entity)player).Center.X, (int)((Entity)player).Bottom.Y, sItem.makeNPC, sItem.placeStyle, ((Entity)player).whoAmI);
			NPC releasedCritter = Main.npc[releasedCritterIndex];
			if (sItem.AsFood().MaxHealth != 0 && sItem.AsFood().MaxHealth == releasedCritter.lifeMax)
			{
				releasedCritter.life = sItem.AsFood().Health;
			}
			if (Main.myPlayer == ((Entity)player).whoAmI && V2.SwallowHotkey.Current && PredPlayer.CanSwallow(player, (Entity)(object)releasedCritter))
			{
				PredPlayer.Swallow(player, (Entity)(object)releasedCritter);
			}
		}
		else
		{
			if (!(((Entity)player).position.X / 16f - (float)Player.tileRangeX - (float)sItem.tileBoost <= (float)Player.tileTargetX) || !((((Entity)player).position.X + (float)((Entity)player).width) / 16f + (float)Player.tileRangeX + (float)sItem.tileBoost - 1f >= (float)Player.tileTargetX) || !(((Entity)player).position.Y / 16f - (float)Player.tileRangeY - (float)sItem.tileBoost <= (float)Player.tileTargetY) || !((((Entity)player).position.Y + (float)((Entity)player).height) / 16f + (float)Player.tileRangeY + (float)sItem.tileBoost - 2f >= (float)Player.tileTargetY))
			{
				return;
			}
			int num = Main.mouseX + (int)Main.screenPosition.X;
			int num2 = Main.mouseY + (int)Main.screenPosition.Y;
			int num3 = num / 16;
			int j = num2 / 16;
			if (!WorldGen.SolidTile(num3, j, false))
			{
				player.ApplyItemTime(sItem, 1f, (bool?)null);
				int releasedCritterIndex2 = NPC.ReleaseNPC(num, num2, sItem.makeNPC, sItem.placeStyle, ((Entity)player).whoAmI);
				NPC releasedCritter2 = Main.npc[releasedCritterIndex2];
				if (sItem.AsAnItem().ReleasedNPCNetID < 0)
				{
					releasedCritter2.SetDefaults(sItem.AsAnItem().ReleasedNPCNetID, default(NPCSpawnParams));
				}
				if (sItem.AsFood().MaxHealth != 0 && sItem.AsFood().MaxHealth == releasedCritter2.lifeMax)
				{
					releasedCritter2.life = sItem.AsFood().Health;
				}
				if (Main.myPlayer == ((Entity)player).whoAmI && V2.SwallowHotkey.Current && PredPlayer.CanSwallow(player, (Entity)(object)releasedCritter2))
				{
					PredPlayer.Swallow(player, (Entity)(object)releasedCritter2);
				}
			}
		}
	}

	public static void KillMe(Player player, PlayerDeathReason damageSource, double dmg, int hitDirection, bool pvp = false)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		if (player.creativeGodMode || player.dead)
		{
			return;
		}
		player.StopVanityActions(true);
		bool playSound = true;
		bool genGore = true;
		if (!PlayerLoader.PreKill(player, dmg, hitDirection, pvp, ref playSound, ref genGore, ref damageSource))
		{
			return;
		}
		if (pvp)
		{
			player.pvpDeath = true;
		}
		if (player.trapDebuffSource)
		{
			AchievementsHelper.HandleSpecialEvent(player, 4);
		}
		if (Main.myPlayer == ((Entity)player).whoAmI)
		{
			if (player._framesLeftEligibleForDeadmansChestDeathAchievement > 0)
			{
				AchievementsHelper.HandleSpecialEvent(player, 23);
			}
			Main.NotifyOfEvent((GameNotificationType)2);
		}
		player.lastDeathPostion = ((Entity)player).Center;
		player.lastDeathTime = DateTime.Now;
		player.showLastDeath = true;
		bool overFlowing = default(bool);
		int coinsOwned = (int)Utils.CoinsCount(ref overFlowing, player.inventory, Array.Empty<int>());
		if (Main.myPlayer == ((Entity)player).whoAmI)
		{
			player.lostCoins = coinsOwned;
			player.lostCoinString = Main.ValueToCoins(player.lostCoins);
			((object)player).GetType().GetMethod("EndOngoingTorchGodEvent", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(player, null);
			Main.mapFullscreen = false;
			player.trashItem.SetDefaults(0);
			if (player.difficulty == 0 || player.difficulty == 3)
			{
				for (int i = 0; i < 59; i++)
				{
					if (player.inventory[i].stack > 0 && ((player.inventory[i].type >= 1522 && player.inventory[i].type <= 1527) || player.inventory[i].type == 3643))
					{
						int num = Item.NewItem(((Entity)player).GetSource_Death((string)null), (int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height, player.inventory[i].type, 1, false, 0, false, false);
						Main.item[num].netDefaults(player.inventory[i].netID);
						Main.item[num].Prefix(player.inventory[i].prefix);
						Main.item[num].stack = player.inventory[i].stack;
						((Entity)Main.item[num]).velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						((Entity)Main.item[num]).velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num].noGrabDelay = 100;
						Main.item[num].favorited = false;
						Main.item[num].newAndShiny = false;
						if (((Entity)(object)player).CurrentCaptor() != null)
						{
							((Entity)(object)player).CurrentCaptor().QueueNewPrey(PreyData.NewData((Entity)(object)Main.item[num], ((Entity)(object)player).CurrentCaptor()));
						}
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, (NetworkText)null, num, 0f, 0f, 0f, 0, 0, 0);
						}
						player.inventory[i].SetDefaults(0);
					}
				}
			}
			else if (player.difficulty == 1)
			{
				player.DropItems();
			}
			else if (player.difficulty == 2)
			{
				player.DropItems();
				player.KillMeForGood();
			}
		}
		if (playSound)
		{
			SoundEngine.PlaySound(ref SoundID.PlayerKilled, (Vector2?)((Entity)player).Center, (SoundUpdateCallback)null);
		}
		player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
		player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
		player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
		player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
		player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
		player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
		if (player.stoned || !genGore || player.AsFood().Digested)
		{
			player.headPosition = Vector2.Zero;
			player.bodyPosition = Vector2.Zero;
			player.legPosition = Vector2.Zero;
		}
		if (genGore && !player.AsFood().Digested)
		{
			for (int j = 0; j < 100; j++)
			{
				if (player.stoned)
				{
					Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 1, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
				else if (player.frostArmor)
				{
					int num2 = Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 135, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
					Main.dust[num2].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
				}
				else if (player.boneArmor)
				{
					int num3 = Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
					Main.dust[num3].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
				}
				else
				{
					Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
			}
		}
		player.mount.Dismount(player);
		player.dead = true;
		player.respawnTimer = 600;
		bool flag = false;
		if (Main.netMode != 0 && !pvp)
		{
			for (int k = 0; k < 200; k++)
			{
				if (((Entity)Main.npc[k]).active && (Main.npc[k].boss || Main.npc[k].type == 13 || Main.npc[k].type == 14 || Main.npc[k].type == 15) && Math.Abs(((Entity)player).Center.X - ((Entity)Main.npc[k]).Center.X) + Math.Abs(((Entity)player).Center.Y - ((Entity)Main.npc[k]).Center.Y) < 4000f)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			player.respawnTimer += 600;
		}
		if (Main.expertMode)
		{
			player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
		}
		PlayerLoader.Kill(player, dmg, hitDirection, pvp, damageSource);
		player.immuneAlpha = 0;
		if (!ChildSafety.Disabled)
		{
			player.immuneAlpha = 255;
		}
		player.palladiumRegen = false;
		player.iceBarrier = false;
		player.crystalLeaf = false;
		NetworkText deathText = damageSource.GetDeathText(player.name);
		if (Main.netMode == 2)
		{
			ChatHelper.BroadcastChatMessage(deathText, new Color(225, 25, 25), -1);
		}
		else if (Main.netMode == 0)
		{
			Main.NewText(((object)deathText).ToString(), (byte)225, (byte)25, (byte)25);
		}
		if (Main.netMode == 1 && ((Entity)player).whoAmI == Main.myPlayer)
		{
			NetMessage.SendPlayerDeath(((Entity)player).whoAmI, damageSource, (int)dmg, hitDirection, pvp, -1, -1);
		}
		if (((Entity)player).whoAmI == Main.myPlayer && (player.difficulty == 0 || player.difficulty == 3))
		{
			if (!pvp)
			{
				player.DropCoins();
			}
			else
			{
				player.lostCoins = 0L;
				player.lostCoinString = Main.ValueToCoins(player.lostCoins);
			}
		}
		if (!player.AsFood().Digested)
		{
			player.DropTombstone((long)coinsOwned, deathText, hitDirection);
		}
		if (((Entity)player).whoAmI != Main.myPlayer)
		{
			return;
		}
		try
		{
			WorldGen.saveToonWhilePlaying();
		}
		catch
		{
		}
	}
}
