using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.IO;
using V2.Core;

namespace V2.NPCs.Vanilla.TownNPCs.Dryad;

public static class DryadStuff
{
	public static class Animations
	{
		public static class AVEmpressOfLight
		{
			public class PhaseOne : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 15;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (0, 200);
						num2++;
						span[num2] = (1, 15);
						num2++;
						span[num2] = (2, 25);
						num2++;
						span[num2] = (3, 25);
						num2++;
						span[num2] = (4, 25);
						num2++;
						span[num2] = (5, 25);
						num2++;
						span[num2] = (4, 25);
						num2++;
						span[num2] = (5, 25);
						num2++;
						span[num2] = (4, 35);
						num2++;
						span[num2] = (5, 45);
						num2++;
						span[num2] = (4, 55);
						num2++;
						span[num2] = (5, 75);
						num2++;
						span[num2] = (3, 15);
						num2++;
						span[num2] = (6, 15);
						num2++;
						span[num2] = (1, 25);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class PhaseTransition : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 21;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (0, 200);
						num2++;
						span[num2] = (1, 15);
						num2++;
						span[num2] = (2, 25);
						num2++;
						span[num2] = (3, 25);
						num2++;
						span[num2] = (4, 25);
						num2++;
						span[num2] = (5, 25);
						num2++;
						span[num2] = (4, 35);
						num2++;
						span[num2] = (5, 45);
						num2++;
						span[num2] = (4, 55);
						num2++;
						span[num2] = (5, 75);
						num2++;
						span[num2] = (10, 85);
						num2++;
						span[num2] = (11, 15);
						num2++;
						span[num2] = (10, 85);
						num2++;
						span[num2] = (12, 25);
						num2++;
						span[num2] = (13, 15);
						num2++;
						span[num2] = (14, 15);
						num2++;
						span[num2] = (15, 15);
						num2++;
						span[num2] = (16, 15);
						num2++;
						span[num2] = (17, 15);
						num2++;
						span[num2] = (18, 25);
						num2++;
						span[num2] = (19, 35);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class PhaseTwo : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 18;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (20, 190);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 245);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 105);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 45);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 190);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 275);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 135);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 225);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (20, 65);
						num2++;
						span[num2] = (21, 10);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class EmpressGetsChurned : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 9;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (20, 190);
						num2++;
						span[num2] = (21, 10);
						num2++;
						span[num2] = (22, 25);
						num2++;
						span[num2] = (23, 20);
						num2++;
						span[num2] = (24, 20);
						num2++;
						span[num2] = (25, 25);
						num2++;
						span[num2] = (26, 35);
						num2++;
						span[num2] = (27, 25);
						num2++;
						span[num2] = (28, 25);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class DigestStage1 : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 18;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (30, 190);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 245);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 105);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 45);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 190);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 275);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 135);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 225);
						num2++;
						span[num2] = (31, 10);
						num2++;
						span[num2] = (30, 65);
						num2++;
						span[num2] = (31, 10);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class DigestStage2 : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 18;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (32, 190);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 245);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 105);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 45);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 190);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 275);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 135);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 225);
						num2++;
						span[num2] = (33, 10);
						num2++;
						span[num2] = (32, 65);
						num2++;
						span[num2] = (33, 10);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class DigestStage3 : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 18;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (34, 190);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 245);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 105);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 45);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 190);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 275);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 135);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 225);
						num2++;
						span[num2] = (35, 10);
						num2++;
						span[num2] = (34, 65);
						num2++;
						span[num2] = (35, 10);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class DigestStage4 : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 18;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (36, 190);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 245);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 105);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 45);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 190);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 275);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 135);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 225);
						num2++;
						span[num2] = (37, 10);
						num2++;
						span[num2] = (36, 65);
						num2++;
						span[num2] = (37, 10);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public class DigestStage5 : SpriteAnimation
			{
				public override string Texture => AnimSetSheet;

				public override List<(int frame, int rawDelay)> Frames
				{
					get
					{
						int num = 18;
						List<(int, int)> list = new List<(int, int)>(num);
						CollectionsMarshal.SetCount(list, num);
						Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
						int num2 = 0;
						span[num2] = (38, 190);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 245);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 105);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 45);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 190);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 275);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 135);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 225);
						num2++;
						span[num2] = (39, 10);
						num2++;
						span[num2] = (38, 65);
						num2++;
						span[num2] = (39, 10);
						num2++;
						return list;
					}
				}

				public override Rectangle? DecideFrame()
				{
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					return new Rectangle(86 * (base.FrameID % 10), 148 * (int)Math.Floor((double)base.FrameID / 10.0), 86, 148);
				}
			}

			public static string AnimSetSheet
			{
				get
				{
					foreach (ResourcePack enabledResourcePack in V2.EnabledResourcePacks)
					{
						if (enabledResourcePack.Name == "True Dryad Fan")
						{
							return "V2/NPCs/Vanilla/TownNPCs/Dryad/AltSheetSets/True Dryad Fan/Dryad_WeightBase_BossBelly_EmpressOfLight";
						}
					}
					return "V2/NPCs/Vanilla/TownNPCs/Dryad/Dryad_WeightBase_BossBelly_EmpressOfLight";
				}
			}
		}
	}

	public static class ItemTheftRules
	{
		public static ItemTheftRule ClothingTop => new ItemTheftRule((NPC npc, Entity pred) => 1853, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule ClothingBottom => new ItemTheftRule((NPC npc, Entity pred) => 1854, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);
	}

	public static DryadPredProfile DryadPredProfile => new DryadPredProfile();

	public static Dryad AsDryad(this NPC npc)
	{
		Dryad predStylist = default(Dryad);
		if (!npc.TryGetGlobalNPC<Dryad>(ref predStylist))
		{
			throw new Exception("this instance of the Dryad can't be pred or prey. find another salad to snack on or get snacked on by");
		}
		return predStylist;
	}
}
