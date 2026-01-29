using System;
using Terraria;

namespace V2.NPCs.Vanilla.Sky;

public static class HarpyStuff
{
	public static class Statistics
	{
		public static float MaxMoveSpeed
		{
			get
			{
				float baseMaxMoveSpeed = Main.GameMode switch
				{
					2 => 3.9f, 
					1 => 3.3f, 
					0 => 3f, 
					_ => 2f, 
				};
				if (Main.zenithWorld)
				{
					baseMaxMoveSpeed *= 1.1f;
				}
				else if (Main.getGoodWorld)
				{
					baseMaxMoveSpeed *= 1.05f;
				}
				return baseMaxMoveSpeed;
			}
		}

		public static int DiveBombLength
		{
			get
			{
				int baseDiveBombLength = Main.GameMode switch
				{
					2 => V2Utils.SensibleTime(0, 0, 0, 40), 
					1 => V2Utils.SensibleTime(0, 0, 0, 50), 
					0 => V2Utils.SensibleTime(0, 0, 1), 
					_ => V2Utils.SensibleTime(0, 0, 1), 
				};
				if (Main.zenithWorld)
				{
					baseDiveBombLength = (int)Math.Round((float)baseDiveBombLength * 0.6f);
				}
				else if (Main.getGoodWorld)
				{
					baseDiveBombLength = (int)Math.Round((float)baseDiveBombLength * 0.85f);
				}
				return baseDiveBombLength;
			}
		}

		public static int DiveBombRecoveryLength
		{
			get
			{
				int baseDiveBombRecoveryLength = Main.GameMode switch
				{
					2 => V2Utils.SensibleTime(0, 0, 2), 
					1 => V2Utils.SensibleTime(0, 0, 3), 
					0 => V2Utils.SensibleTime(0, 0, 4), 
					_ => V2Utils.SensibleTime(0, 0, 4), 
				};
				if (Main.zenithWorld)
				{
					baseDiveBombRecoveryLength = (int)Math.Round((float)baseDiveBombRecoveryLength * 0.7f);
				}
				else if (Main.getGoodWorld)
				{
					baseDiveBombRecoveryLength = (int)Math.Round((float)baseDiveBombRecoveryLength * 0.9f);
				}
				return baseDiveBombRecoveryLength;
			}
		}
	}

	public static class ItemTheftRules
	{
		public static ItemTheftRule GiantHarpyFeather => new ItemTheftRule((NPC npc, Entity pred) => 1516, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 1.0 / 30.0, 
			1 => 0.025, 
			_ => 0.02, 
		});
	}

	public static Harpy AsHarpy(this NPC npc)
	{
		Harpy harpy = default(Harpy);
		if (!npc.TryGetGlobalNPC<Harpy>(ref harpy))
		{
			throw new Exception("this instance of a Harpy, supposedly, doesn't exist");
		}
		return harpy;
	}
}
