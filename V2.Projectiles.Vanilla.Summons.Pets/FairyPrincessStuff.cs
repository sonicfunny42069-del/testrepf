using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using V2.Core;

namespace V2.Projectiles.Vanilla.Summons.Pets;

public static class FairyPrincessStuff
{
	public static class Animations
	{
		public static class BaseWeight
		{
			public static class OVHerOwnFuckingMother
			{
				public class Alive : SpriteAnimation
				{
					public override string Texture => "V2/Projectiles/Vanilla/Summons/Pets/FairyPrincess_WeightBase_BossBelly_EmpressOfLight";

					public override List<(int frame, int rawDelay)> Frames
					{
						get
						{
							int num = 6;
							List<(int, int)> list = new List<(int, int)>(num);
							CollectionsMarshal.SetCount(list, num);
							Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
							int num2 = 0;
							span[num2] = (0, 15);
							num2++;
							span[num2] = (1, 15);
							num2++;
							span[num2] = (2, 15);
							num2++;
							span[num2] = (3, 15);
							num2++;
							span[num2] = (4, 15);
							num2++;
							span[num2] = (5, 15);
							num2++;
							return list;
						}
					}

					public override Rectangle? DecideFrame()
					{
						//IL_000e: Unknown result type (might be due to invalid IL or missing references)
						return new Rectangle(0, 118 * base.FrameID, 80, 118);
					}
				}

				public class DigestStage1 : SpriteAnimation
				{
					public override string Texture => "V2/Projectiles/Vanilla/Summons/Pets/FairyPrincess_WeightBase_BossBelly_EmpressOfLight";

					public override List<(int frame, int rawDelay)> Frames
					{
						get
						{
							int num = 6;
							List<(int, int)> list = new List<(int, int)>(num);
							CollectionsMarshal.SetCount(list, num);
							Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
							int num2 = 0;
							span[num2] = (0, 15);
							num2++;
							span[num2] = (1, 15);
							num2++;
							span[num2] = (2, 15);
							num2++;
							span[num2] = (3, 15);
							num2++;
							span[num2] = (4, 15);
							num2++;
							span[num2] = (5, 15);
							num2++;
							return list;
						}
					}

					public override Rectangle? DecideFrame()
					{
						//IL_000f: Unknown result type (might be due to invalid IL or missing references)
						return new Rectangle(80, 118 * base.FrameID, 80, 118);
					}
				}

				public class DigestStage2 : SpriteAnimation
				{
					public override string Texture => "V2/Projectiles/Vanilla/Summons/Pets/FairyPrincess_WeightBase_BossBelly_EmpressOfLight";

					public override List<(int frame, int rawDelay)> Frames
					{
						get
						{
							int num = 6;
							List<(int, int)> list = new List<(int, int)>(num);
							CollectionsMarshal.SetCount(list, num);
							Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
							int num2 = 0;
							span[num2] = (0, 15);
							num2++;
							span[num2] = (1, 15);
							num2++;
							span[num2] = (2, 15);
							num2++;
							span[num2] = (3, 15);
							num2++;
							span[num2] = (4, 15);
							num2++;
							span[num2] = (5, 15);
							num2++;
							return list;
						}
					}

					public override Rectangle? DecideFrame()
					{
						//IL_0012: Unknown result type (might be due to invalid IL or missing references)
						return new Rectangle(160, 118 * base.FrameID, 80, 118);
					}
				}

				public class DigestStage3 : SpriteAnimation
				{
					public override string Texture => "V2/Projectiles/Vanilla/Summons/Pets/FairyPrincess_WeightBase_BossBelly_EmpressOfLight";

					public override List<(int frame, int rawDelay)> Frames
					{
						get
						{
							int num = 6;
							List<(int, int)> list = new List<(int, int)>(num);
							CollectionsMarshal.SetCount(list, num);
							Span<(int, int)> span = CollectionsMarshal.AsSpan(list);
							int num2 = 0;
							span[num2] = (0, 15);
							num2++;
							span[num2] = (1, 15);
							num2++;
							span[num2] = (2, 15);
							num2++;
							span[num2] = (3, 15);
							num2++;
							span[num2] = (4, 15);
							num2++;
							span[num2] = (5, 15);
							num2++;
							return list;
						}
					}

					public override Rectangle? DecideFrame()
					{
						//IL_0012: Unknown result type (might be due to invalid IL or missing references)
						return new Rectangle(240, 118 * base.FrameID, 80, 118);
					}
				}
			}
		}
	}

	public static int MaxHealth => 3500;

	public static double Size => 0.7;

	public static double MaxStomachCapacity => 30.0;

	public static double DigestDamage => 40.0;

	public static double DigestRate => 2.0;

	public static double AbsorbRate => 1.0 / (double)V2Utils.SensibleTime(0, 1, 30);

	public static FairyPrincess AsFairyPrincess(this Projectile projectile)
	{
		FairyPrincess predFairyPrincess = default(FairyPrincess);
		if (!projectile.TryGetGlobalProjectile<FairyPrincess>(ref predFairyPrincess))
		{
			throw new Exception("this instance of the Heiress of Light can't be pred or prey");
		}
		return predFairyPrincess;
	}
}
