using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.Items;
using V2.NPCs.Vanilla.TownNPCs.Nurse;
using V2.PlayerHandling;
using V2.Projectiles;
using V2.Sounds.Vore;
using V2.StatusEffects.Voraria.Debuffs;

namespace V2.NPCs;

public class PredNPC : GlobalNPC
{
	public delegate bool DelegateCanBeForceFed(NPC npc);

	public delegate void DelegateOnForceFed(NPC npc, Player player);

	public delegate double DelegateGetDigestionTickRate(NPC npc, PreyData prey);

	public delegate double DelegateGetDigestionTickDamage(NPC npc, PreyData prey);

	public delegate void DelegateOnDigestionKill(NPC npc, PreyData digestedPrey);

	public delegate void DelegateGetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathMessageKeyList);

	public delegate double DelegateGetPreyAbsorptionRate(NPC npc);

	public delegate int DelegateGetVisualBellySize(NPC npc);

	public delegate int DelegateGetVisualWeightStage(NPC npc);

	private double _stomachache;

	public StatModifier StomachacheMeterCapacityModifier;

	public EntityGender Gender { get; set; }

	public EntityDigestionType DigestionType { get; set; }

	public double MaxStomachCapacity { get; set; }

	public float MaxSwallowRange { get; set; }

	public double ExtraWeight { get; set; }

	public double WeightGainRatio { get; set; }

	public bool CanSwallowBosses { get; set; }

	public Vector2 MouthSoundRawOffset { get; set; }

	public bool AteFriendly { get; set; }

	public SoundStyle? SmallGulps { get; set; }

	public double SmallGulpThreshold { get; set; }

	public SoundStyle? BigGulps { get; set; }

	public SoundStyle? SmallBurps { get; set; }

	public double SmallBurpThreshold { get; set; }

	public SoundStyle? StandardBurps { get; set; }

	public double BigBurpThreshold { get; set; }

	public SoundStyle? BigBurps { get; set; }

	public bool NonPreferenceBypass { get; set; }

	public DelegateCanBeForceFed CanBeForceFed { get; set; }

	public DelegateOnForceFed OnForceFed { get; set; }

	public DelegateGetDigestionTickRate GetDigestionTickRate { get; set; }

	public DelegateGetDigestionTickDamage GetDigestionTickDamage { get; set; }

	public double Stomachache
	{
		get
		{
			return _stomachache;
		}
		set
		{
			_stomachache = Math.Max(0.0, value);
		}
	}

	public double BaseStomachacheMeterCapacity { get; set; }

	public double StomachacheMeterCapacity
	{
		get
		{
			double baseStomachacheMeterCapacity = BaseStomachacheMeterCapacity;
			return ((StatModifier)(ref StomachacheMeterCapacityModifier)).ApplyTo((float)baseStomachacheMeterCapacity);
		}
	}

	public int CounterStruggleEffectiveness { get; set; }

	public DelegateOnDigestionKill OnDigestionKill { get; set; }

	public DelegateGetDigestedPlayerAdditionalDeathMessages GetAdditionalDigestedPlayerMessages { get; set; }

	public DelegateGetPreyAbsorptionRate GetPreyAbsorptionRate { get; set; }

	public DelegateGetVisualBellySize GetVisualBellySize { get; set; }

	public DelegateGetVisualWeightStage GetVisualWeightStage { get; set; }

	public int FloorBreakCounter { get; set; }

	public SlotId ActiveStomachNoises { get; set; }

	public override bool InstancePerEntity => true;

	public static VoreTracker GetStomachTracker(NPC npc)
	{
		if (Main.gameMenu)
		{
			return null;
		}
		return ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault(delegate(VoreTracker x)
		{
			Entity predator = x.Predator;
			NPC val = (NPC)(object)((predator is NPC) ? predator : null);
			return val != null && ((Entity)val).whoAmI == ((Entity)npc).whoAmI;
		});
	}

	public static Vector2 MouthSoundOffset(NPC npc)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Vector2 happyBurpyOffsetDirectionized = npc.AsPred().MouthSoundRawOffset;
		if (((Entity)npc).direction != 0)
		{
			happyBurpyOffsetDirectionized.X *= ((Entity)npc).direction;
		}
		return happyBurpyOffsetDirectionized;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return true;
	}

	public PredNPC()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		MaxStomachCapacity = 1.0;
		MaxSwallowRange = 36f;
		ExtraWeight = 0.0;
		WeightGainRatio = 0.0;
		CanSwallowBosses = false;
		AteFriendly = false;
		GetDigestionTickRate = null;
		GetDigestionTickDamage = null;
		GetPreyAbsorptionRate = null;
		NonPreferenceBypass = false;
		CanBeForceFed = (NPC npc) => false;
		OnForceFed = null;
		Stomachache = 0.0;
		BaseStomachacheMeterCapacity = 100.0;
		CounterStruggleEffectiveness = 5;
		MouthSoundRawOffset = Vector2.Zero;
		SmallGulps = Gulps.Short;
		SmallGulpThreshold = 0.2;
		BigGulps = Gulps.Standard;
		SmallBurps = null;
		SmallBurpThreshold = 0.2;
		StandardBurps = null;
		BigBurpThreshold = 2.0;
		BigBurps = null;
		OnDigestionKill = null;
		GetVisualBellySize = null;
		GetVisualWeightStage = null;
		FloorBreakCounter = 0;
	}

	public override void ResetEffects(NPC npc)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		double stomachacheQuellPerTick = StomachacheMeterCapacity * (0.05 / (double)V2Utils.SensibleTime(0, 0, 1));
		if (GetStomachTracker(npc) != null && AnyPreyStillAlive(npc))
		{
			stomachacheQuellPerTick *= 0.1;
		}
		Stomachache -= stomachacheQuellPerTick;
		StomachacheMeterCapacityModifier = StatModifier.Default;
	}

	public static bool CanSwallow(NPC pred, Entity prey, bool skipCaptorCheck = false)
	{
		if (V2.VoreNPCBlacklist != null && V2.VoreNPCBlacklist.Count > 0 && V2.VoreNPCBlacklist.Contains(pred.type))
		{
			return false;
		}
		if (!pred.AsPred().NonPreferenceBypass)
		{
			switch (ModContent.GetInstance<V2ServerConfig>().GenderBlacklist)
			{
			case "No Male":
				if (pred.AsV2NPC().Gender == EntityGender.Male)
				{
					return false;
				}
				break;
			case "No Female":
				if (pred.AsV2NPC().Gender == EntityGender.Female)
				{
					return false;
				}
				break;
			case "No M or F...but why?":
				if (pred.AsV2NPC().Gender != EntityGender.Other)
				{
					return false;
				}
				break;
			}
		}
		if (!skipCaptorCheck && prey.CurrentCaptor() != null)
		{
			return false;
		}
		Player preyPlayer = (Player)(object)((prey is Player) ? prey : null);
		if (preyPlayer != null)
		{
			if (preyPlayer.AsFood().PerfectMeal)
			{
				return true;
			}
		}
		else
		{
			NPC preyNPC = (NPC)(object)((prey is NPC) ? prey : null);
			if (preyNPC != null)
			{
				if (preyNPC.AsFood().CannotBeEatenDueToShenanigans)
				{
					return false;
				}
				if (V2.VoreNPCBlacklist != null && V2.VoreNPCBlacklist.Count > 0 && V2.VoreNPCBlacklist.Contains(preyNPC.type))
				{
					return false;
				}
				if (preyNPC.type == 636 && ModContent.GetInstance<V2ServerConfig>().EasilyEdibleEmpress)
				{
					return ((Entity)(object)preyNPC).CurrentCaptor() == null;
				}
				bool isThePreyAFuckingBoss = preyNPC.boss || (preyNPC.type >= 13 && preyNPC.type <= 15);
				bool isThePredAFuckingBoss = pred.boss || (pred.type >= 13 && pred.type <= 15);
				if (!pred.AsPred().CanSwallowBosses && isThePreyAFuckingBoss && !isThePredAFuckingBoss)
				{
					return false;
				}
			}
			else
			{
				Projectile preyProjectile = (Projectile)(object)((prey is Projectile) ? prey : null);
				if (preyProjectile != null)
				{
					if (preyProjectile.AsFood().CannotBeEatenDueToShenanigans)
					{
						return false;
					}
					if (V2.VoreNPCBlacklist != null && V2.VoreProjectileBlacklist.Count > 0 && V2.VoreProjectileBlacklist.Contains(preyProjectile.type))
					{
						return false;
					}
					if (preyProjectile.AsFood().MaxHealth == -1.0)
					{
						return false;
					}
				}
				else
				{
					Item preyItem = (Item)(object)((prey is Item) ? prey : null);
					if (preyItem != null)
					{
						if (preyItem.AsFood().MaxHealth == -1)
						{
							return false;
						}
						if (preyItem.favorited)
						{
							return false;
						}
					}
				}
			}
		}
		if (GetCurrentBellyWeight(pred) >= pred.AsPred().MaxStomachCapacity)
		{
			return false;
		}
		if (pred.AsPred().MaxStomachCapacity != -1.0 && PreyData.GetPreySize(prey) > pred.AsPred().MaxStomachCapacity - GetCurrentBellyWeight(pred))
		{
			return false;
		}
		if (pred.AsPred().Stomachache >= pred.AsPred().StomachacheMeterCapacity)
		{
			return false;
		}
		return true;
	}

	public static void SwallowWithTextIfApplicable(NPC pred, Player prey, string chatboxText)
	{
		if (CanSwallow(pred, (Entity)(object)prey))
		{
			Swallow(pred, (Entity)(object)prey);
			SetChatboxText(pred, prey, chatboxText);
		}
	}

	public static void Swallow(NPC pred, Entity prey, int MPstate = 0, int MPwhoAmI = -1, bool playSound = true)
	{
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		if (!CanSwallow(pred, prey))
		{
			return;
		}
		if (MPstate == 0 && Main.netMode == 1)
		{
			MPstate = 1;
			MPwhoAmI = Main.myPlayer;
		}
		PreyData food = PreyData.NewData(prey);
		AddNewPrey(pred, food);
		if (playSound)
		{
			PlaySwallowGulp(pred, food);
		}
		switch (food.Type)
		{
		case PreyType.Player:
			((Player)(object)((prey is Player) ? prey : null)).AsFood().TotalTimesSwallowed++;
			break;
		case PreyType.NPC:
		{
			NPC npc = (NPC)(object)((prey is NPC) ? prey : null);
			npc.AsFood().OnSwallowedBy?.Invoke(npc, (Entity)(object)pred);
			break;
		}
		case PreyType.Projectile:
		{
			Projectile projectile = (Projectile)(object)((prey is Projectile) ? prey : null);
			if (projectile.AsFood().MaxHealth == -1.0)
			{
				food = PreyData.NewData(PreyType.Projectile, projectile.type, projectile.Name, PreyData.GetPreySize((Entity)(object)projectile));
				((Entity)projectile).active = false;
			}
			else
			{
				projectile.AsFood().OnSwallowedBy?.Invoke(projectile, (Entity)(object)pred);
			}
			break;
		}
		case PreyType.Item:
		{
			Item item = (Item)(object)((prey is Item) ? prey : null);
			item.AsFood().OnSwallow?.Invoke(item, (Entity)(object)pred);
			if (item.AsFood().OnSwallowDamage > 0)
			{
				HitInfo val = default(HitInfo);
				((HitInfo)(ref val))._002Ector();
				((HitInfo)(ref val)).SourceDamage = item.AsFood().OnSwallowDamage;
				val.DamageType = DamageClass.Default;
				val.Crit = false;
				val.HideCombatText = true;
				pred.StrikeNPC(val, false, false);
			}
			if (item.AsFood().OnSwallowSoreThroatTime > 0)
			{
				pred.AddBuff(ModContent.BuffType<SoreThroat>(), item.AsFood().OnSwallowSoreThroatTime, false);
			}
			break;
		}
		}
		pred.netUpdate = true;
		switch (MPstate)
		{
		case 1:
		{
			ModPacket packet2 = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet2).Write((byte)1);
			((BinaryWriter)(object)packet2).Write((byte)1);
			((BinaryWriter)(object)packet2).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet2).Write((byte)food.Type);
			((BinaryWriter)(object)packet2).Write(prey.whoAmI);
			((BinaryWriter)(object)packet2).Write(MPwhoAmI);
			packet2.Send(-1, -1);
			break;
		}
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)2);
			((BinaryWriter)(object)packet).Write((byte)1);
			((BinaryWriter)(object)packet).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet).Write((byte)food.Type);
			((BinaryWriter)(object)packet).Write(prey.whoAmI);
			((BinaryWriter)(object)packet).Write(MPwhoAmI);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
	}

	public static void Regurgitate(NPC pred, int index = -1, int MPstate = 0, int MPwhoAmI = -1)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		if (MPstate == 0 && Main.netMode == 1)
		{
			MPstate = 1;
			MPwhoAmI = Main.myPlayer;
		}
		double totalRegurgiweight = 0.0;
		if (index == -1)
		{
			foreach (PreyData prey in GetStomachTracker(pred).Prey)
			{
				Regurgitate_Inner(pred, prey);
			}
			GetStomachTracker(pred).Prey.Clear();
			GetStomachTracker(pred).RefreshStruggleChartList();
		}
		else
		{
			PreyData prey2 = GetStomachTracker(pred).Prey[index];
			Regurgitate_Inner(pred, prey2);
			GetStomachTracker(pred).Prey.Remove(prey2);
		}
		SoundStyle? val = ((totalRegurgiweight <= 0.3) ? pred.AsPred().SmallBurps : pred.AsPred().StandardBurps);
		SoundEngine.PlaySound(ref val, (Vector2?)(((Entity)(object)pred).TrueCenter() + new Vector2((float)((Entity)pred).direction * 8f, -14f)), (SoundUpdateCallback)null);
		switch (MPstate)
		{
		case 1:
		{
			ModPacket packet2 = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet2).Write((byte)8);
			((BinaryWriter)(object)packet2).Write((byte)1);
			((BinaryWriter)(object)packet2).Write(Main.myPlayer);
			((BinaryWriter)(object)packet2).Write(index);
			((BinaryWriter)(object)packet2).Write(Main.myPlayer);
			packet2.Send(-1, -1);
			break;
		}
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)9);
			((BinaryWriter)(object)packet).Write((byte)1);
			((BinaryWriter)(object)packet).Write(Main.myPlayer);
			((BinaryWriter)(object)packet).Write(index);
			((BinaryWriter)(object)packet).Write(Main.myPlayer);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
		void Regurgitate_Inner(NPC val3, PreyData preyData)
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			Entity val2;
			switch (preyData.Type)
			{
			case PreyType.Player:
			{
				Entity instance4 = preyData.Instance;
				val2 = ((instance4 is Player) ? instance4 : null);
				break;
			}
			case PreyType.NPC:
			{
				Entity instance3 = preyData.Instance;
				val2 = ((instance3 is NPC) ? instance3 : null);
				break;
			}
			case PreyType.Projectile:
			{
				Entity instance2 = preyData.Instance;
				val2 = ((instance2 is Projectile) ? instance2 : null);
				break;
			}
			case PreyType.Item:
			{
				Entity instance = preyData.Instance;
				val2 = ((instance is Item) ? instance : null);
				break;
			}
			case PreyType.Custom:
				val2 = null;
				break;
			default:
				throw new NotImplementedException();
			}
			Entity realPrey = val2;
			realPrey.position = ((Entity)(object)val3).TrueCenter() + new Vector2((float)((Entity)val3).direction * 8f, -14f);
			realPrey.velocity = new Vector2((float)((Entity)val3).direction * 10f, -2.5f);
			NPC realPreyNPC = (NPC)(object)((realPrey is NPC) ? realPrey : null);
			if (realPreyNPC != null)
			{
				realPreyNPC.AsFood().EatenSafetyFrames = 20;
			}
			else if (!(realPrey is Projectile) && !(realPrey is Player))
			{
				Item realPreyItem = (Item)(object)((realPrey is Item) ? realPrey : null);
				if (realPreyItem != null)
				{
					realPreyItem.noGrabDelay = 60;
				}
			}
			totalRegurgiweight += preyData.WeightLeftToDigest;
		}
	}

	public static void SetChatboxText(NPC pred, Player prey, string chatText)
	{
		Main.CancelHairWindow();
		Main.SetNPCShopIndex(0);
		Main.InGuideCraftMenu = false;
		prey.dropItemCheck();
		Main.npcChatCornerItem = 0;
		prey.sign = -1;
		Main.editSign = false;
		prey.SetTalkNPC(((Entity)pred).whoAmI, false);
		Main.playerInventory = false;
		prey.chest = -1;
		Recipe.FindRecipes(false);
		Main.npcChatText = chatText;
	}

	public static void UpdatePrey(NPC pred)
	{
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		if (pred.AsPred().StomachacheMeterCapacity > 0.0 && pred.AsPred().Stomachache >= pred.AsPred().StomachacheMeterCapacity)
		{
			Regurgitate(pred, -1, (Main.netMode != 0) ? 2 : 0);
			return;
		}
		foreach (PreyData prey in GetStomachTracker(pred).Prey)
		{
			if (!prey.NoHealth)
			{
				prey.UpdateInStomach?.Invoke(prey.Instance, (Entity)(object)pred, dead: false);
				switch (prey.Type)
				{
				case PreyType.Player:
				{
					Entity instance3 = prey.Instance;
					Player preyPlayer = (Player)(object)((instance3 is Player) ? instance3 : null);
					if (preyPlayer == null || !((Entity)preyPlayer).active || preyPlayer.dead)
					{
						continue;
					}
					((Entity)preyPlayer).velocity = Vector2.Zero;
					((Entity)preyPlayer).position = ((Entity)pred).position;
					break;
				}
				case PreyType.NPC:
				{
					Entity instance2 = prey.Instance;
					NPC preyNPC = (NPC)(object)((instance2 is NPC) ? instance2 : null);
					if (preyNPC == null || !((Entity)preyNPC).active)
					{
						continue;
					}
					((Entity)preyNPC).velocity = Vector2.Zero;
					((Entity)preyNPC).position = ((Entity)pred).position;
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance4 = prey.Instance;
					Projectile preyProjectile = (Projectile)(object)((instance4 is Projectile) ? instance4 : null);
					if (preyProjectile == null || !((Entity)preyProjectile).active)
					{
						continue;
					}
					((Entity)preyProjectile).velocity = Vector2.Zero;
					((Entity)preyProjectile).position = ((Entity)pred).position;
					break;
				}
				case PreyType.Item:
				{
					Entity instance = prey.Instance;
					Item preyItem = (Item)(object)((instance is Item) ? instance : null);
					if (preyItem == null || !((Entity)preyItem).active)
					{
						continue;
					}
					((Entity)preyItem).velocity = Vector2.Zero;
					((Entity)preyItem).position = ((Entity)pred).position;
					break;
				}
				}
				if (prey.Type == PreyType.Player && pred.type == 18 && pred.AsNurse().healPlayerIndex != -1)
				{
					int healPlayerIndex = pred.AsNurse().healPlayerIndex;
					Entity instance5 = prey.Instance;
					if (healPlayerIndex == ((instance5 is Player) ? instance5 : null).whoAmI && !pred.AsNurse().digestScamPatient)
					{
						Entity instance6 = prey.Instance;
						Player healingPreyPlayer = (Player)(object)((instance6 is Player) ? instance6 : null);
						if (healingPreyPlayer.statLife >= healingPreyPlayer.statLifeMax2)
						{
							pred.AsNurse().healOvertime++;
						}
					}
				}
				if (pred.AsPred().GetDigestionTickRate == null || pred.AsPred().GetDigestionTickDamage == null)
				{
					if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText(pred.FullName + " has invalid digestion damage/tick rate methods!", byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					break;
				}
				double digestionDamage = pred.AsPred().GetDigestionTickDamage(pred, prey);
				double digestionTickRate = pred.AsPred().GetDigestionTickRate(pred, prey);
				int digestionTickFrameRate = (int)Math.Round(60.0 / digestionTickRate);
				if (digestionTickFrameRate != 0 && prey.timeSpentInStomach % digestionTickFrameRate != 0)
				{
					continue;
				}
				switch (prey.Type)
				{
				case PreyType.Player:
				{
					Entity instance9 = prey.Instance;
					Player preyPlayer2 = (Player)(object)((instance9 is Player) ? instance9 : null);
					bool shouldDigestPlayer = true;
					if (pred.type == 18 && pred.AsNurse().healPlayerIndex != -1 && pred.AsNurse().healPlayerIndex == ((Entity)preyPlayer2).whoAmI && !pred.AsNurse().digestScamPatient)
					{
						if (preyPlayer2.statLife < preyPlayer2.statLifeMax2)
						{
							prey.NoHealth = false;
							preyPlayer2.statLife += (int)Math.Round(digestionDamage);
							if (preyPlayer2.statLife > preyPlayer2.statLifeMax2)
							{
								preyPlayer2.statLife = preyPlayer2.statLifeMax2;
							}
							CombatText obj = Main.combatText[CombatText.NewText(((Entity)preyPlayer2).Hitbox, Color.LimeGreen, (int)Math.Round(digestionDamage), false, true)];
							obj.position.X = ((Entity)pred).Center.X;
							obj.position.X += ((Entity)pred).direction * 14;
							obj.position.Y = ((Entity)preyPlayer2).Center.Y;
							obj.position.Y += (float)((Entity)preyPlayer2).height / 5f;
							obj.velocity.X = (float)((Entity)pred).direction * 2.5f;
							obj.velocity.Y = -4f;
						}
					}
					else if (shouldDigestPlayer)
					{
						prey.NoHealth = preyPlayer2.AsFood().TakeDigestionDamage((Entity)(object)pred, digestionDamage);
						if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
						{
							Main.NewText("Successfully dealt digestion damage to prey: " + preyPlayer2.name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						}
						if (prey.NoHealth)
						{
							pred.AsPred().AteFriendly = true;
							if (pred.AsPred().OnDigestionKill != null)
							{
								pred.AsPred().OnDigestionKill(pred, prey);
							}
							PlayDigestionBelch(pred, prey);
						}
					}
					else if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText("Failed to deal digestion damage to prey: " + preyPlayer2.name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					break;
				}
				case PreyType.NPC:
				{
					Entity instance8 = prey.Instance;
					NPC preyNPC2 = (NPC)(object)((instance8 is NPC) ? instance8 : null);
					if (1 == 0)
					{
						break;
					}
					if (preyNPC2.type == 636 && ModContent.GetInstance<V2ServerConfig>().EasilyEdibleEmpress)
					{
						digestionDamage *= 20.0;
					}
					prey.NoHealth = PreyNPC.TakeDigestionDamage(preyNPC2, (Entity)(object)pred, digestionDamage);
					preyNPC2.netUpdate = true;
					if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText("Successfully dealt digestion damage to prey: " + preyNPC2.GivenOrTypeName, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					else if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText("Failed to deal digestion damage to prey: " + preyNPC2.GivenOrTypeName, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					if (prey.NoHealth)
					{
						if (preyNPC2.isLikeATownNPC)
						{
							pred.AsPred().AteFriendly = true;
						}
						if (pred.AsPred().OnDigestionKill != null)
						{
							pred.AsPred().OnDigestionKill(pred, prey);
						}
						PlayDigestionBelch(pred, prey);
					}
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance7 = prey.Instance;
					Projectile preyProjectile2 = (Projectile)(object)((instance7 is Projectile) ? instance7 : null);
					if (1 == 0)
					{
						break;
					}
					prey.NoHealth = preyProjectile2.TakeDigestionDamage((Entity)(object)pred, digestionDamage);
					preyProjectile2.netUpdate = true;
					if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText("Successfully dealt digestion damage to prey: " + preyProjectile2.Name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					else if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText("Failed to deal digestion damage to prey: " + preyProjectile2.Name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					if (prey.NoHealth)
					{
						if (pred.AsPred().OnDigestionKill != null)
						{
							pred.AsPred().OnDigestionKill(pred, prey);
						}
						PlayDigestionBelch(pred, prey);
					}
					break;
				}
				}
			}
			else
			{
				prey.UpdateInStomach?.Invoke(null, (Entity)(object)pred, dead: true);
				if (pred.AsPred().GetPreyAbsorptionRate == null)
				{
					break;
				}
				double digestedWeightPerTick = pred.AsPred().GetPreyAbsorptionRate(pred) / (double)GetStomachTracker(pred).Prey.Count;
				double effectiveSize = pred.AsFood().DefinedBaseSize + pred.AsPred().ExtraWeight;
				if (pred.AsFood().DefinedEffectiveSize != 0.0)
				{
					effectiveSize = pred.AsFood().DefinedEffectiveSize;
				}
				if (prey.WeightLeftToDigest <= digestedWeightPerTick)
				{
					pred.AsPred().ExtraWeight += prey.WeightLeftToDigest * pred.AsPred().WeightGainRatio * (pred.AsFood().DefinedBaseSize / effectiveSize);
					prey.WeightLeftToDigest = 0.0;
				}
				else
				{
					pred.AsPred().ExtraWeight += digestedWeightPerTick * pred.AsPred().WeightGainRatio * (pred.AsFood().DefinedBaseSize / effectiveSize);
					prey.WeightLeftToDigest -= digestedWeightPerTick;
				}
			}
		}
		if (((Entity)(object)pred).CurrentCaptor() == null && pred.AsPred().GetVisualBellySize != null)
		{
			ActiveSound stomachNoises = default(ActiveSound);
			if (!SoundEngine.TryGetActiveSound(pred.AsPred().ActiveStomachNoises, ref stomachNoises))
			{
				PredNPC predNPC = pred.AsPred();
				SoundStyle val = (V2.GetFooled ? StomachNoises.AprilFools : StomachNoises.Muffled);
				((SoundStyle)(ref val)).Volume = 0.25f + 0.15f * (float)pred.AsPred().GetVisualBellySize(pred);
				predNPC.ActiveStomachNoises = SoundEngine.PlaySound(ref val, (Vector2?)((Entity)(object)pred).TrueCenter(), (SoundUpdateCallback)null);
				SoundEngine.TryGetActiveSound(pred.AsPred().ActiveStomachNoises, ref stomachNoises);
			}
			if (stomachNoises != null)
			{
				stomachNoises.Position = ((Entity)(object)pred).TrueCenter();
				stomachNoises.Volume = 0.2f;
				ActiveSound obj2 = stomachNoises;
				obj2.Volume += 0.1f * (float)pred.AsPred().GetVisualBellySize(pred);
			}
		}
	}

	public static void AddNewPrey(NPC pred, PreyData prey)
	{
		if (GetStomachTracker(pred) == null)
		{
			VoreTracker.NewTracker((Entity)(object)pred, new List<PreyData> { prey });
		}
		else
		{
			GetStomachTracker(pred).QueueNewPrey(prey);
		}
	}

	public static string GetDigestedPlayerDeathReason(NPC npc, Player player)
	{
		List<string> deathMessageKeyList = new List<string>
		{
			"Mods.V2.Death.DigestedPlayer.Universal.1", "Mods.V2.Death.DigestedPlayer.Universal.2", "Mods.V2.Death.DigestedPlayer.Universal.3", "Mods.V2.Death.DigestedPlayer.Universal.4", "Mods.V2.Death.DigestedPlayer.Universal.5", "Mods.V2.Death.DigestedPlayer.Universal.6", "Mods.V2.Death.DigestedPlayer.Universal.7", "Mods.V2.Death.DigestedPlayer.Universal.8", "Mods.V2.Death.DigestedPlayer.Universal.9", "Mods.V2.Death.DigestedPlayer.Universal.10",
			"Mods.V2.Death.DigestedPlayer.Universal.11", "Mods.V2.Death.DigestedPlayer.Universal.12", "Mods.V2.Death.DigestedPlayer.Universal.13", "Mods.V2.Death.DigestedPlayer.Universal.14", "Mods.V2.Death.DigestedPlayer.Universal.15", "Mods.V2.Death.DigestedPlayer.Universal.16", "Mods.V2.Death.DigestedPlayer.Universal.17", "Mods.V2.Death.DigestedPlayer.Universal.18", "Mods.V2.Death.DigestedPlayer.Universal.19", "Mods.V2.Death.DigestedPlayer.Universal.20",
			"Mods.V2.Death.DigestedPlayer.Universal.21", "Mods.V2.Death.DigestedPlayer.Universal.22"
		};
		switch (npc.AsPred().DigestionType)
		{
		case EntityDigestionType.Acidic:
			deathMessageKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.1", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.2", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.3", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.4", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.5", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.6", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.7", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.8", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.9", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.10" });
			break;
		case EntityDigestionType.Thermal:
			deathMessageKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.1", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.2", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.3", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.4", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.5" });
			break;
		}
		if (npc.AsPred().GetAdditionalDigestedPlayerMessages != null)
		{
			npc.AsPred().GetAdditionalDigestedPlayerMessages(npc, player, deathMessageKeyList);
		}
		return Language.GetTextValueWith(Utils.NextFromCollection<string>(Main.rand, deathMessageKeyList), (object)new
		{
			Player = player.name,
			Pred = (V2.GetFooled ? npc.FullName : npc.GivenOrTypeName)
		});
	}

	public override void OnKill(NPC npc)
	{
		if (GetStomachTracker(npc) == null)
		{
			return;
		}
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			foreach (PreyData prey in GetStomachTracker(npc).Prey)
			{
				((Entity)(object)npc).CurrentCaptor().QueueNewPrey(prey);
			}
		}
		GetStomachTracker(npc).Prey.Clear();
	}

	public static double GetCurrentBellyWeight(NPC pred)
	{
		if (GetStomachTracker(pred) == null)
		{
			return 0.0;
		}
		double totalBellyWeight = 0.0;
		foreach (PreyData prey in GetStomachTracker(pred).Prey)
		{
			totalBellyWeight += prey.WeightLeftToDigest;
			if (!prey.NoHealth)
			{
				switch (prey.Type)
				{
				case PreyType.Player:
				{
					Entity instance3 = prey.Instance;
					Player preyPredPlayer = (Player)(object)((instance3 is Player) ? instance3 : null);
					totalBellyWeight += preyPredPlayer.AsPred().StomachWeight;
					break;
				}
				case PreyType.NPC:
				{
					Entity instance2 = prey.Instance;
					NPC preyPredNPC = (NPC)(object)((instance2 is NPC) ? instance2 : null);
					totalBellyWeight += GetCurrentBellyWeight(preyPredNPC);
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance = prey.Instance;
					Projectile preyPredProjectile = (Projectile)(object)((instance is Projectile) ? instance : null);
					totalBellyWeight += PredProjectile.GetCurrentBellyWeight(preyPredProjectile);
					break;
				}
				}
			}
		}
		return totalBellyWeight;
	}

	public static bool AnyPreyStillAlive(NPC pred)
	{
		if (GetStomachTracker(pred) != null)
		{
			foreach (PreyData item in GetStomachTracker(pred).Prey)
			{
				if (!item.NoHealth)
				{
					return true;
				}
			}
		}
		return false;
	}

	public override bool NeedSaving(NPC npc)
	{
		return npc.AsPred().AteFriendly;
	}

	public override void SaveData(NPC npc, TagCompound tag)
	{
		tag.Add("ExtraWeight", (object)npc.AsPred().ExtraWeight);
	}

	public override void LoadData(NPC npc, TagCompound tag)
	{
		ExtraWeight = tag.GetDouble("ExtraWeight");
	}

	public static void PlaySwallowGulp(NPC pred, PreyData prey)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle? gulpySound = pred.AsPred().BigGulps;
		if (prey.WeightLeftToDigest < pred.AsPred().SmallGulpThreshold)
		{
			gulpySound = pred.AsPred().SmallGulps;
		}
		SoundEngine.PlaySound(ref gulpySound, (Vector2?)(((Entity)(object)pred).TrueCenter() + MouthSoundOffset(pred)), (SoundUpdateCallback)null);
	}

	public static void PlayDigestionBelch(NPC pred, PreyData prey)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle? bworpySound = pred.AsPred().StandardBurps;
		if (prey.WeightLeftToDigest < pred.AsPred().SmallBurpThreshold && pred.AsPred().SmallBurps.HasValue)
		{
			bworpySound = pred.AsPred().SmallBurps;
		}
		if (prey.WeightLeftToDigest < pred.AsPred().BigBurpThreshold && pred.AsPred().BigBurps.HasValue)
		{
			bworpySound = pred.AsPred().BigBurps;
		}
		SoundEngine.PlaySound(ref bworpySound, (Vector2?)(((Entity)(object)pred).TrueCenter() + MouthSoundOffset(pred)), (SoundUpdateCallback)null);
	}
}
