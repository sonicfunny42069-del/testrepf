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
using V2.Core;
using V2.Items;
using V2.NPCs;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.Projectiles;

public class PredProjectile : GlobalProjectile
{
	public delegate bool DelegateCanBeForceFed(Projectile projectile);

	public delegate void DelegateOnForceFed(Projectile projectile, Player player);

	public delegate double DelegateGetDigestionTickRate(Projectile projectile, PreyData prey);

	public delegate double DelegateGetDigestionTickDamage(Projectile projectile, PreyData prey);

	public delegate void DelegateOnDigestionKill(Projectile projectile, PreyData digestedPrey);

	public delegate void DelegateGetDigestedPlayerAdditionalDeathMessages(Projectile projectile, Player player, List<string> deathMessageKeyList);

	public delegate double DelegateGetPreyAbsorptionRate(Projectile projectile);

	public delegate int DelegateGetVisualBellySize(Projectile projectile);

	public delegate int DelegateGetVisualWeightStage(Projectile projectile);

	private double _stomachache;

	public StatModifier StomachacheMeterCapacityModifier;

	public EntityDigestionType DigestionType { get; set; }

	public double MaxStomachCapacity { get; set; }

	public float MaxSwallowRange { get; set; }

	public double ExtraWeight { get; set; }

	public double WeightGainRatio { get; set; }

	public bool CanSwallowBosses { get; set; }

	public Vector2 MouthSoundRawOffset { internal get; set; }

	public SoundStyle? SmallGulps { get; set; }

	public double SmallGulpThreshold { get; set; }

	public SoundStyle? BigGulps { get; set; }

	public SoundStyle? SmallBurps { get; set; }

	public double SmallBurpThreshold { get; set; }

	public SoundStyle? StandardBurps { get; set; }

	public double BigBurpThreshold { get; set; }

	public SoundStyle? BigBurps { get; set; }

	public float BurpPitchOffset { get; set; }

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
			if (BaseStomachacheMeterCapacity == -1.0)
			{
				return -1.0;
			}
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

	public SlotId ActiveStomachNoises { get; set; }

	public override bool InstancePerEntity => true;

	public static VoreTracker GetStomachTracker(Projectile projectile)
	{
		if (Main.gameMenu)
		{
			return null;
		}
		return ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault(delegate(VoreTracker x)
		{
			Entity predator = x.Predator;
			Projectile val = (Projectile)(object)((predator is Projectile) ? predator : null);
			return val != null && ((Entity)val).whoAmI == ((Entity)projectile).whoAmI;
		});
	}

	public static Vector2 MouthSoundOffset(Projectile projectile)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Vector2 happyBurpyOffsetDirectionized = projectile.AsPred().MouthSoundRawOffset;
		if (((Entity)projectile).direction != 0)
		{
			happyBurpyOffsetDirectionized.X *= ((Entity)projectile).direction;
		}
		return happyBurpyOffsetDirectionized;
	}

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		return true;
	}

	public PredProjectile()
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		MaxStomachCapacity = 0.0;
		MaxSwallowRange = 36f;
		ExtraWeight = 0.0;
		WeightGainRatio = 0.4;
		CanSwallowBosses = false;
		GetDigestionTickRate = null;
		GetDigestionTickDamage = null;
		GetPreyAbsorptionRate = null;
		NonPreferenceBypass = false;
		CanBeForceFed = (Projectile projectile) => false;
		OnForceFed = null;
		Stomachache = 0.0;
		BaseStomachacheMeterCapacity = 100.0;
		StomachacheMeterCapacityModifier = StatModifier.Default;
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
		BurpPitchOffset = 0f;
		OnDigestionKill = null;
		GetAdditionalDigestedPlayerMessages = null;
		GetVisualBellySize = null;
		GetVisualWeightStage = null;
	}

	public static void ResetEffects(Projectile projectile)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		double stomachacheQuellPerTick = projectile.AsPred().StomachacheMeterCapacity * (0.05 / (double)V2Utils.SensibleTime(0, 0, 1));
		if (GetStomachTracker(projectile) != null && AnyPreyStillAlive(projectile))
		{
			stomachacheQuellPerTick *= 0.1;
		}
		projectile.AsPred().Stomachache -= stomachacheQuellPerTick;
		projectile.AsPred().StomachacheMeterCapacityModifier = StatModifier.Default;
	}

	public static bool CanSwallow(Projectile pred, Entity prey)
	{
		if (V2.VoreNPCBlacklist != null && V2.VoreProjectileBlacklist.Count > 0 && V2.VoreProjectileBlacklist.Contains(pred.type))
		{
			return false;
		}
		if (pred.AsPred().MaxStomachCapacity == 0.0)
		{
			return false;
		}
		if (GetCurrentBellyWeight(pred) >= pred.AsPred().MaxStomachCapacity)
		{
			return false;
		}
		if (!pred.AsPred().NonPreferenceBypass)
		{
			switch (ModContent.GetInstance<V2ServerConfig>().GenderBlacklist)
			{
			case "No Male":
				if (pred.AsV2Proj().Gender == EntityGender.Male)
				{
					return false;
				}
				break;
			case "No Female":
				if (pred.AsV2Proj().Gender == EntityGender.Female)
				{
					return false;
				}
				break;
			case "No M or F...but why?":
				if (pred.AsV2Proj().Gender != EntityGender.Other)
				{
					return false;
				}
				break;
			}
		}
		if (prey.CurrentCaptor() != null)
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
				if (!pred.AsPred().CanSwallowBosses && isThePreyAFuckingBoss)
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
		return true;
	}

	public static void Swallow(Projectile pred, Entity prey, int MPstate = 0, int MPwhoAmI = -1)
	{
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
		PlaySwallowGulp(pred, food);
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
				pred.AsFood().Health -= item.AsFood().OnSwallowDamage;
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
			((BinaryWriter)(object)packet2).Write((byte)2);
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
			((BinaryWriter)(object)packet).Write((byte)2);
			((BinaryWriter)(object)packet).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet).Write((byte)food.Type);
			((BinaryWriter)(object)packet).Write(prey.whoAmI);
			((BinaryWriter)(object)packet).Write(MPwhoAmI);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
	}

	public static void Regurgitate(Projectile pred, int index = -1, int MPstate = 0, int MPwhoAmI = -1)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
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
			((BinaryWriter)(object)packet2).Write((byte)2);
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
			((BinaryWriter)(object)packet).Write((byte)2);
			((BinaryWriter)(object)packet).Write(Main.myPlayer);
			((BinaryWriter)(object)packet).Write(index);
			((BinaryWriter)(object)packet).Write(Main.myPlayer);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
		void Regurgitate_Inner(Projectile val3, PreyData preyData)
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

	public static void UpdatePrey(Projectile pred)
	{
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
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
				if (pred.AsPred().GetDigestionTickRate == null || pred.AsPred().GetDigestionTickDamage == null)
				{
					if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
					{
						Main.NewText(pred.Name + " has invalid digestion damage/tick rate methods!", byte.MaxValue, byte.MaxValue, byte.MaxValue);
					}
					break;
				}
				double digestionDamage = pred.AsPred().GetDigestionTickDamage(pred, prey);
				double digestionTickRate = pred.AsPred().GetDigestionTickRate(pred, prey);
				int digestionTickFrameRate = (int)Math.Round(60.0 / digestionTickRate);
				if (prey.timeSpentInStomach % digestionTickFrameRate != 0)
				{
					continue;
				}
				switch (prey.Type)
				{
				case PreyType.Player:
				{
					Entity instance7 = prey.Instance;
					Player preyPlayer2 = (Player)(object)((instance7 is Player) ? instance7 : null);
					if (true)
					{
						prey.NoHealth = preyPlayer2.AsFood().TakeDigestionDamage((Entity)(object)pred, digestionDamage);
						if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
						{
							Main.NewText("Successfully dealt digestion damage to prey: " + preyPlayer2.name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						}
						if (prey.NoHealth)
						{
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
					Entity instance6 = prey.Instance;
					NPC preyNPC2 = (NPC)(object)((instance6 is NPC) ? instance6 : null);
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
					Entity instance5 = prey.Instance;
					Projectile preyProjectile2 = (Projectile)(object)((instance5 is Projectile) ? instance5 : null);
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
				if (prey.WeightLeftToDigest <= digestedWeightPerTick)
				{
					pred.AsPred().ExtraWeight += prey.WeightLeftToDigest * pred.AsPred().WeightGainRatio;
					prey.WeightLeftToDigest = 0.0;
				}
				else
				{
					pred.AsPred().ExtraWeight += digestedWeightPerTick * pred.AsPred().WeightGainRatio;
					prey.WeightLeftToDigest -= digestedWeightPerTick;
				}
			}
		}
		if (((Entity)(object)pred).CurrentCaptor() == null && pred.AsPred().GetVisualBellySize != null)
		{
			ActiveSound stomachNoises = default(ActiveSound);
			if (!SoundEngine.TryGetActiveSound(pred.AsPred().ActiveStomachNoises, ref stomachNoises))
			{
				PredProjectile predProjectile = pred.AsPred();
				SoundStyle val = (V2.GetFooled ? StomachNoises.AprilFools : StomachNoises.Muffled);
				((SoundStyle)(ref val)).Volume = 0.25f + 0.15f * (float)pred.AsPred().GetVisualBellySize(pred);
				predProjectile.ActiveStomachNoises = SoundEngine.PlaySound(ref val, (Vector2?)((Entity)(object)pred).TrueCenter(), (SoundUpdateCallback)null);
				SoundEngine.TryGetActiveSound(pred.AsPred().ActiveStomachNoises, ref stomachNoises);
			}
			if (stomachNoises != null)
			{
				stomachNoises.Position = ((Entity)(object)pred).TrueCenter();
				stomachNoises.Volume = 0.25f;
				ActiveSound obj = stomachNoises;
				obj.Volume += 0.15f * (float)pred.AsPred().GetVisualBellySize(pred);
			}
		}
	}

	public static void AddNewPrey(Projectile pred, PreyData prey)
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

	public static string GetDigestedPlayerDeathReason(Projectile projectile, Player player)
	{
		List<string> deathMessageKeyList = new List<string>
		{
			"Mods.V2.Death.DigestedPlayer.Universal.1", "Mods.V2.Death.DigestedPlayer.Universal.2", "Mods.V2.Death.DigestedPlayer.Universal.3", "Mods.V2.Death.DigestedPlayer.Universal.4", "Mods.V2.Death.DigestedPlayer.Universal.5", "Mods.V2.Death.DigestedPlayer.Universal.6", "Mods.V2.Death.DigestedPlayer.Universal.7", "Mods.V2.Death.DigestedPlayer.Universal.8", "Mods.V2.Death.DigestedPlayer.Universal.9", "Mods.V2.Death.DigestedPlayer.Universal.10",
			"Mods.V2.Death.DigestedPlayer.Universal.11", "Mods.V2.Death.DigestedPlayer.Universal.12", "Mods.V2.Death.DigestedPlayer.Universal.13", "Mods.V2.Death.DigestedPlayer.Universal.14", "Mods.V2.Death.DigestedPlayer.Universal.15", "Mods.V2.Death.DigestedPlayer.Universal.16", "Mods.V2.Death.DigestedPlayer.Universal.17", "Mods.V2.Death.DigestedPlayer.Universal.18", "Mods.V2.Death.DigestedPlayer.Universal.19", "Mods.V2.Death.DigestedPlayer.Universal.20",
			"Mods.V2.Death.DigestedPlayer.Universal.21", "Mods.V2.Death.DigestedPlayer.Universal.22"
		};
		switch (projectile.AsPred().DigestionType)
		{
		case EntityDigestionType.Acidic:
			deathMessageKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.1", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.2", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.3", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.4", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.5", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.6", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.7", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.8", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.9", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Acidic.10" });
			break;
		case EntityDigestionType.Thermal:
			deathMessageKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.1", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.2", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.3", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.4", "Mods.V2.Death.DigestedPlayer.SpecificDigestionType.Thermal.5" });
			break;
		}
		if (projectile.AsPred().GetAdditionalDigestedPlayerMessages != null)
		{
			projectile.AsPred().GetAdditionalDigestedPlayerMessages(projectile, player, deathMessageKeyList);
		}
		return Language.GetTextValueWith(Utils.NextFromCollection<string>(Main.rand, deathMessageKeyList), (object)new
		{
			Player = player.name,
			Pred = projectile.Name
		});
	}

	public override bool PreKill(Projectile projectile, int timeLeft)
	{
		if (GetStomachTracker(projectile) != null)
		{
			if (((Entity)(object)projectile).CurrentCaptor() != null)
			{
				foreach (PreyData prey in GetStomachTracker(projectile).Prey)
				{
					((Entity)(object)projectile).CurrentCaptor().QueueNewPrey(prey);
				}
			}
			GetStomachTracker(projectile).Prey.Clear();
		}
		return true;
	}

	public static double GetCurrentBellyWeight(Projectile pred)
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
					totalBellyWeight += PredNPC.GetCurrentBellyWeight(preyPredNPC);
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance = prey.Instance;
					Projectile preyPredProjectile = (Projectile)(object)((instance is Projectile) ? instance : null);
					totalBellyWeight += GetCurrentBellyWeight(preyPredProjectile);
					break;
				}
				}
			}
		}
		return totalBellyWeight;
	}

	public static bool AnyPreyStillAlive(Projectile pred)
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

	public static void PlaySwallowGulp(Projectile pred, PreyData prey)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle? gulpySound = pred.AsPred().BigGulps;
		if (prey.WeightLeftToDigest < pred.AsPred().SmallGulpThreshold)
		{
			gulpySound = pred.AsPred().SmallGulps;
		}
		SoundEngine.PlaySound(ref gulpySound, (Vector2?)(((Entity)(object)pred).TrueCenter() + MouthSoundOffset(pred)), (SoundUpdateCallback)null);
	}

	public static void PlayDigestionBelch(Projectile pred, PreyData prey)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle? bworpySound = pred.AsPred().StandardBurps;
		if (prey != null)
		{
			if (prey.WeightLeftToDigest < pred.AsPred().SmallBurpThreshold && pred.AsPred().SmallBurps.HasValue)
			{
				bworpySound = pred.AsPred().SmallBurps;
			}
			if (prey.WeightLeftToDigest < pred.AsPred().BigBurpThreshold && pred.AsPred().BigBurps.HasValue)
			{
				bworpySound = pred.AsPred().BigBurps;
			}
		}
		SoundStyle value = bworpySound.Value;
		((SoundStyle)(ref value)).Pitch = pred.AsPred().BurpPitchOffset;
		SoundEngine.PlaySound(ref value, (Vector2?)(((Entity)(object)pred).TrueCenter() + MouthSoundOffset(pred)), (SoundUpdateCallback)null);
	}
}
