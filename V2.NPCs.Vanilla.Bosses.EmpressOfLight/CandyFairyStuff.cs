using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.Audio;

namespace V2.NPCs.Vanilla.Bosses.EmpressOfLight;

public static class CandyFairyStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule WeaponDrops => new ItemTheftRule(delegate
		{
			int num = 4;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<int> span = CollectionsMarshal.AsSpan(list);
			int num2 = 0;
			span[num2] = 4923;
			num2++;
			span[num2] = 4953;
			num2++;
			span[num2] = 4952;
			num2++;
			span[num2] = 4914;
			num2++;
			List<int> list2 = list;
			return Utils.NextFromCollection<int>(Main.rand, list2);
		}, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.4, 
			1 => 1.0 / 3.0, 
			_ => 0.25, 
		});

		public static ItemTheftRule StarGuitar => new ItemTheftRule((NPC npc, Entity pred) => 4715, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.0333, 
			1 => 0.025, 
			_ => 0.02, 
		});

		public static ItemTheftRule EmpressWings => new ItemTheftRule((NPC npc, Entity pred) => 4823, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.1, 
			1 => 0.075, 
			_ => 0.05, 
		});

		public static ItemTheftRule PrismaticDye => new ItemTheftRule((NPC npc, Entity pred) => 4778, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.15, 
			1 => 0.125, 
			_ => 0.1, 
		});

		public static ItemTheftRule Mask => new ItemTheftRule((NPC npc, Entity pred) => 4784, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.125, 
			1 => 0.1, 
			_ => 0.0667, 
		});

		public static ItemTheftRule Trophy => new ItemTheftRule((NPC npc, Entity pred) => 4783, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.25, 
			1 => 0.2, 
			_ => 0.1, 
		});

		public static ItemTheftRule ExpertDrop => new ItemTheftRule((NPC npc, Entity pred) => 4989, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 1.0, 
			1 => 0.5, 
			_ => 0.0, 
		});

		public static ItemTheftRule MasterTrophy => new ItemTheftRule((NPC npc, Entity pred) => 4949, (NPC npc, Entity pred) => 1, delegate
		{
			int num = ((Main.GameMode == 2) ? 1 : 0);
			return num;
		});

		public static ItemTheftRule MasterPetItem => new ItemTheftRule((NPC npc, Entity pred) => 4811, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => (Main.GameMode == 2) ? (1.0 / 3.0) : 0.0);

		public static ItemTheftRule HangrySwordDrop => new ItemTheftRule((NPC npc, Entity pred) => 5005, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => (npc.AI_120_HallowBoss_IsGenuinelyEnraged() && pred is Player) ? 1f : 0f);
	}

	public static SoundStyle MuffledCandyFairyMusic
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			SoundStyle result = default(SoundStyle);
			((SoundStyle)(ref result))._002Ector("V2/Sounds/MuffledMusic/EmpressOfLight", (SoundType)0);
			((SoundStyle)(ref result)).MaxInstances = 0;
			return result;
		}
	}

	public static SoundStyle MuffledCandyFairyScreech1
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			SoundStyle result = default(SoundStyle);
			((SoundStyle)(ref result))._002Ector("V2/Sounds/MuffledSounds/Item160", (SoundType)0);
			((SoundStyle)(ref result)).MaxInstances = 0;
			return result;
		}
	}

	public static SoundStyle MuffledCandyFairyScreech2
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			SoundStyle result = default(SoundStyle);
			((SoundStyle)(ref result))._002Ector("V2/Sounds/MuffledSounds/Item161", (SoundType)0);
			((SoundStyle)(ref result)).MaxInstances = 0;
			return result;
		}
	}

	public static SoundStyle MuffledCandyFairyDeathScreech
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			SoundStyle result = default(SoundStyle);
			((SoundStyle)(ref result))._002Ector("V2/Sounds/MuffledSounds/NPC_Killed_65", (SoundType)0);
			((SoundStyle)(ref result)).MaxInstances = 0;
			return result;
		}
	}

	public static CandyFairy AsCandyFairy(this NPC npc)
	{
		CandyFairy unreasonablyThickFairy = default(CandyFairy);
		if (!npc.TryGetGlobalNPC<CandyFairy>(ref unreasonablyThickFairy))
		{
			throw new Exception("this instance of the Empress of Light, sadly, can't be pred or prey. the unreasonably thick candy fairy can't be food today, I guess");
		}
		return unreasonablyThickFairy;
	}
}
