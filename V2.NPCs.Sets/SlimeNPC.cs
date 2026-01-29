using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Sets;

public class SlimeNPC : GlobalNPC
{
	public override bool InstancePerEntity => true;

	internal int TimeSinceLastJump { get; set; }

	public Vector2 JumpSpeed { get; set; }

	public StatModifier JumpXSpeedModifier { get; set; }

	public StatModifier JumpYSpeedModifier { get; set; }

	public Vector2 FloatSpeed { get; set; }

	public int JumpDelayBase { get; set; }

	public (int Min, int Max) JumpDelayExtra { get; set; }

	public StatModifier JumpDelayModifier { get; set; }

	public bool OccasionalHighJumps { get; set; }

	internal int JumpsUntilNextHighJump { get; set; }

	public int HighJumpFrequency { get; set; }

	public StatModifier HighJumpXModifier { get; set; }

	public StatModifier HighJumpYModifier { get; set; }

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return V2Utils.NPCIDSets.Slimes.Contains(entity.type);
	}

	public override void SetDefaults(NPC entity)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		JumpSpeed = new Vector2(2f, 6f);
		FloatSpeed = new Vector2(2f, 6f);
		JumpDelayBase = V2Utils.SensibleTime(0, 0, 4, 40);
		JumpDelayExtra = (Min: V2Utils.SensibleTime(0, 0, 0, 50), Max: V2Utils.SensibleTime(0, 0, 1, 40));
		OccasionalHighJumps = false;
		HighJumpFrequency = 3;
		JumpsUntilNextHighJump = HighJumpFrequency;
		HighJumpXModifier = StatModifier.Default;
		HighJumpYModifier = StatModifier.Default;
	}

	public override void ResetEffects(NPC npc)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		JumpXSpeedModifier = StatModifier.Default;
		JumpYSpeedModifier = StatModifier.Default;
		JumpDelayModifier = StatModifier.Default;
	}

	public static void OnKilledByDigestion_GrantSlimeMultiPreyGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer == null)
		{
			return;
		}
		List<int> distinctSlimes = new List<int>(V2Utils.NPCIDSets.Slimes);
		int distinctSlimesInTummy = 0;
		foreach (PreyData prey in predPlayer.AsPred().StomachTracker.Prey)
		{
			if (prey.Type == PreyType.NPC)
			{
				int preyNPCID = prey.ExactType;
				if (distinctSlimes.Contains(preyNPCID))
				{
					distinctSlimesInTummy++;
					distinctSlimes.Remove(preyNPCID);
				}
			}
		}
		if (distinctSlimesInTummy >= 3)
		{
			ModContent.GetInstance<Eat3DifferentSlimes>().TrySetCompletion(predPlayer);
		}
	}

	public override void SendExtraAI(NPC npc, BitWriter bitWriter, BinaryWriter binaryWriter)
	{
		binaryWriter.Write(TimeSinceLastJump);
		binaryWriter.Write(JumpsUntilNextHighJump);
	}

	public override void ReceiveExtraAI(NPC npc, BitReader bitReader, BinaryReader binaryReader)
	{
		TimeSinceLastJump = binaryReader.ReadInt32();
		JumpsUntilNextHighJump = binaryReader.ReadInt32();
	}
}
