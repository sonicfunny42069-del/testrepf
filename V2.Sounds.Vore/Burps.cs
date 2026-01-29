using Terraria.Audio;

namespace V2.Sounds.Vore;

public static class Burps
{
	public static class Humanoid
	{
		public static class Zombie
		{
			public static readonly SoundStyle Standard;

			static Zombie()
			{
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_0022: Unknown result type (might be due to invalid IL or missing references)
				SoundStyle standard = default(SoundStyle);
				((SoundStyle)(ref standard))._002Ector("V2/Sounds/Vore/Burps/Humanoid/Zombie/Standard_1", (SoundType)0);
				((SoundStyle)(ref standard)).MaxInstances = 0;
				((SoundStyle)(ref standard)).PitchVariance = 0.04f;
				Standard = standard;
			}
		}

		public static readonly SoundStyle Small;

		public static readonly SoundStyle Standard;

		static Humanoid()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			SoundStyle val = default(SoundStyle);
			((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/Burps/Humanoid/Small_", 1, 9, (SoundType)0);
			((SoundStyle)(ref val)).MaxInstances = 0;
			((SoundStyle)(ref val)).PitchVariance = 0.04f;
			Small = val;
			((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/Burps/Humanoid/Standard_", 1, 14, (SoundType)0);
			((SoundStyle)(ref val)).MaxInstances = 0;
			((SoundStyle)(ref val)).PitchVariance = 0.04f;
			Standard = val;
		}
	}

	public static readonly SoundStyle AprilFools;

	static Burps()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle aprilFools = default(SoundStyle);
		((SoundStyle)(ref aprilFools))._002Ector("V2/Sounds/Vore/Burps/AprilFools", (SoundType)0);
		((SoundStyle)(ref aprilFools)).MaxInstances = 0;
		((SoundStyle)(ref aprilFools)).PitchVariance = 0f;
		AprilFools = aprilFools;
	}
}
