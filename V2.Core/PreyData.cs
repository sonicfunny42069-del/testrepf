using System;
using Terraria;
using V2.Core.StruggleSystem;
using V2.Items;
using V2.NPCs;
using V2.PlayerHandling;
using V2.Projectiles;

namespace V2.Core;

public class PreyData
{
	public delegate void DelegateUpdateInStomach(Entity prey, Entity pred, bool dead);

	public int timeSpentInStomach;

	public PreyType Type { get; set; }

	public Entity Instance { get; set; }

	public int ExactType { get; set; }

	public string Name { get; set; }

	public bool NoHealth { get; set; }

	public bool InventoryItem { get; set; }

	public double InitialWeight { get; set; }

	public double InitialSize { get; set; }

	public double WeightLeftToDigest { get; set; }

	public double SizeLeftToDigest => WeightLeftToDigest / InitialWeight * InitialSize;

	public StruggleChart AssignedStruggleChart { get; set; }

	public DelegateUpdateInStomach UpdateInStomach { get; set; }

	public VoreTracker ConnectedTracker { get; set; }

	public PreyData()
	{
		Type = PreyType.Undefined;
	}

	public static PreyData NewData(PreyType type, int exactType, string name, double weightRemainingIfDead = -1.0)
	{
		PreyData data = new PreyData();
		data.Type = type;
		data.ExactType = exactType;
		data.Name = name;
		if (weightRemainingIfDead != -1.0)
		{
			data.WeightLeftToDigest = weightRemainingIfDead;
			data.NoHealth = true;
		}
		return data;
	}

	public static PreyData NewLiquidData(int liquidType, int liquidAmount)
	{
		PreyData data = new PreyData(liquidType, liquidAmount);
		data.Type = PreyType.Liquid;
		data.Instance = null;
		data.NoHealth = true;
		data.ExactType = liquidType;
		PreyData preyData = data;
		preyData.Name = liquidType switch
		{
			0 => "Water", 
			1 => "Lava", 
			2 => "Honey", 
			3 => "Shimmer", 
			_ => "Some Other Liquid", 
		};
		data.WeightLeftToDigest = liquidAmount;
		return data;
	}

	public static PreyData NewLiquidData(int liquidType, double liquidAmount)
	{
		PreyData data = new PreyData();
		data.Type = PreyType.Liquid;
		data.Instance = null;
		data.NoHealth = true;
		data.ExactType = liquidType;
		PreyData preyData = data;
		preyData.Name = liquidType switch
		{
			0 => "Water", 
			1 => "Lava", 
			2 => "Honey", 
			3 => "Shimmer", 
			_ => "Some Other Liquid", 
		};
		data.WeightLeftToDigest = liquidAmount;
		return data;
	}

	public static PreyData NewData(Entity preyEntity, VoreTracker tracker = null)
	{
		Player preyPlayer = (Player)(object)((preyEntity is Player) ? preyEntity : null);
		if (preyPlayer != null)
		{
			PreyData data = NewData(PreyType.Player, 0, "Player " + preyPlayer.name);
			data.Instance = (Entity)(object)preyPlayer;
			if (tracker != null)
			{
				data.ConnectedTracker = tracker;
			}
			data.Recalculate();
			return data;
		}
		NPC preyNPC = (NPC)(object)((preyEntity is NPC) ? preyEntity : null);
		if (preyNPC != null)
		{
			PreyData data2 = NewData(PreyType.NPC, preyNPC.type, preyNPC.GivenOrTypeName);
			data2.Instance = (Entity)(object)preyNPC;
			if (tracker != null)
			{
				data2.ConnectedTracker = tracker;
			}
			data2.Recalculate();
			return data2;
		}
		Projectile preyProjectile = (Projectile)(object)((preyEntity is Projectile) ? preyEntity : null);
		if (preyProjectile != null)
		{
			PreyData data3 = NewData(PreyType.Projectile, preyProjectile.type, preyProjectile.Name);
			data3.Instance = (Entity)(object)preyProjectile;
			if (tracker != null)
			{
				data3.ConnectedTracker = tracker;
			}
			data3.Recalculate();
			return data3;
		}
		Item preyItem = (Item)(object)((preyEntity is Item) ? preyEntity : null);
		if (preyItem != null)
		{
			PreyData data4 = NewData(PreyType.Item, preyItem.type, preyItem.AffixName());
			data4.Instance = (Entity)(object)preyItem;
			if (tracker != null)
			{
				data4.ConnectedTracker = tracker;
			}
			data4.Recalculate();
			return data4;
		}
		throw new Exception("hi !!\nthomas says that the thing you asked to make is wrong\nsomething about a pa ram being an     in valid enter tee?\nI asked if I could take what was left from him though and he said yeah\ngive me and my tummy another snack whenever :D-rose");
	}

	public void Recalculate()
	{
		double refPlayerWidth = 20.0;
		double refPlayerHeight = 42.0;
		switch (Type)
		{
		case PreyType.Player:
			if (Instance != null && Instance is Player)
			{
				ExactType = 0;
				double num = (WeightLeftToDigest = 1.0);
				double initialWeight = (InitialSize = num);
				InitialWeight = initialWeight;
				if (ConnectedTracker != null)
				{
					AssignedStruggleChart = new ProceduralStruggleChart();
					AssignedStruggleChart.ConnectedTracker = ConnectedTracker;
					AssignedStruggleChart.ForPredator = false;
					AssignedStruggleChart.OnStartup();
				}
				return;
			}
			break;
		case PreyType.NPC:
		{
			if (Instance == null)
			{
				break;
			}
			Entity instance = Instance;
			NPC preyNPC = (NPC)(object)((instance is NPC) ? instance : null);
			if (preyNPC != null)
			{
				ExactType = preyNPC.netID;
				if (preyNPC.AsFood().DefinedEffectiveSize != 0.0)
				{
					double num = (WeightLeftToDigest = preyNPC.AsFood().DefinedEffectiveSize);
					double initialWeight = (InitialSize = num);
					InitialWeight = initialWeight;
				}
				else if (preyNPC.AsFood().DefinedBaseSize != 0.0)
				{
					double num = (WeightLeftToDigest = preyNPC.AsFood().DefinedBaseSize + preyNPC.AsPred().ExtraWeight);
					double initialWeight = (InitialSize = num);
					InitialWeight = initialWeight;
				}
				else
				{
					double playerToNPCWidthRatio = (double)((Entity)preyNPC).width / refPlayerWidth;
					double playerToNPCHeightRatio = (double)((Entity)preyNPC).height / refPlayerHeight;
					double num = (WeightLeftToDigest = playerToNPCWidthRatio * playerToNPCHeightRatio);
					double initialWeight = (InitialSize = num);
					InitialWeight = initialWeight;
				}
				if (ConnectedTracker != null)
				{
					AssignedStruggleChart = new ProceduralStruggleChart();
					AssignedStruggleChart.ConnectedTracker = ConnectedTracker;
					AssignedStruggleChart.ForPredator = false;
					AssignedStruggleChart.OnStartup();
				}
				return;
			}
			break;
		}
		case PreyType.Projectile:
		{
			if (Instance == null)
			{
				break;
			}
			Entity instance2 = Instance;
			Projectile preyProjectile = (Projectile)(object)((instance2 is Projectile) ? instance2 : null);
			if (preyProjectile != null)
			{
				ExactType = preyProjectile.type;
				if (preyProjectile.AsFood().DefinedSize != 0.0)
				{
					double num = (WeightLeftToDigest = preyProjectile.AsFood().DefinedSize + preyProjectile.AsPred().ExtraWeight);
					double initialWeight = (InitialSize = num);
					InitialWeight = initialWeight;
				}
				else
				{
					double playerToProjWidthRatio = (double)((Entity)preyProjectile).width / refPlayerWidth;
					double playerToProjHeightRatio = (double)((Entity)preyProjectile).height / refPlayerHeight;
					double num = (WeightLeftToDigest = playerToProjWidthRatio * playerToProjHeightRatio);
					double initialWeight = (InitialSize = num);
					InitialWeight = initialWeight;
				}
				if (ConnectedTracker != null)
				{
					AssignedStruggleChart = new ProceduralStruggleChart();
					AssignedStruggleChart.ConnectedTracker = ConnectedTracker;
					AssignedStruggleChart.ForPredator = false;
					AssignedStruggleChart.OnStartup();
				}
				return;
			}
			break;
		}
		case PreyType.Item:
			if (Instance != null)
			{
				Entity instance3 = Instance;
				Item preyItem = (Item)(object)((instance3 is Item) ? instance3 : null);
				if (preyItem != null)
				{
					ExactType = preyItem.type;
					double num = (WeightLeftToDigest = preyItem.CalculateSnackSize());
					double initialWeight = (InitialSize = num);
					InitialWeight = initialWeight;
					UpdateInStomach = (DelegateUpdateInStomach)Delegate.Combine(UpdateInStomach, preyItem.AsFood().UpdateInStomach);
					return;
				}
			}
			break;
		case PreyType.Liquid:
			if (Instance != null)
			{
				Instance = null;
			}
			return;
		case PreyType.Custom:
			if (Instance != null)
			{
				Instance = null;
			}
			return;
		}
		throw new Exception("hi !!\nthomas says that the thing you asked to re\nuh    recal              reclam\numm           re   calendar ?\nanyway i thought it was yummy but thomas didnt like it\nsend me more cool snacks please :D-rose");
	}

	public PreyData(int liquidType, int liquidAmount)
	{
		double num = (double)liquidAmount / 256.0;
		double liquidAmountReal = num * liquidType switch
		{
			1 => 4.0, 
			2 => 1.5, 
			3 => 0.75, 
			_ => 1.0, 
		};
		Type = PreyType.Liquid;
		Instance = null;
		NoHealth = true;
		ExactType = liquidType;
		Name = liquidType switch
		{
			0 => "Water", 
			1 => "Lava", 
			2 => "Honey", 
			3 => "Shimmer", 
			_ => "Some Other Liquid", 
		};
		InitialWeight = (InitialSize = (WeightLeftToDigest = liquidAmountReal));
	}

	public PreyData(int liquidType, double liquidAmount)
	{
		Type = PreyType.Liquid;
		Instance = null;
		NoHealth = true;
		ExactType = liquidType;
		Name = liquidType switch
		{
			0 => "Water", 
			1 => "Lava", 
			2 => "Honey", 
			3 => "Shimmer", 
			_ => "Some Other Liquid", 
		};
		InitialWeight = (InitialSize = (WeightLeftToDigest = liquidAmount));
	}

	public static double GetPreySize(Entity preyEntity)
	{
		double initialSize = NewData(preyEntity).InitialSize;
		Player preyPlayer = (Player)(object)((preyEntity is Player) ? preyEntity : null);
		if (preyPlayer != null)
		{
			return initialSize + preyPlayer.AsPred().StomachFullness;
		}
		NPC preyNPC = (NPC)(object)((preyEntity is NPC) ? preyEntity : null);
		if (preyNPC != null)
		{
			return initialSize + preyNPC.AsPred().ExtraWeight + PredNPC.GetCurrentBellyWeight(preyNPC);
		}
		Projectile preyProjectile = (Projectile)(object)((preyEntity is Projectile) ? preyEntity : null);
		if (preyProjectile != null)
		{
			return initialSize + preyProjectile.AsPred().ExtraWeight + PredProjectile.GetCurrentBellyWeight(preyProjectile);
		}
		return initialSize;
	}
}
