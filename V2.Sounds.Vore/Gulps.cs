using Terraria.Audio;

namespace V2.Sounds.Vore;

public static class Gulps
{
	public static readonly SoundStyle AprilFools;

	public static readonly SoundStyle Short;

	public static readonly SoundStyle Standard;

	static Gulps()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle val = default(SoundStyle);
		((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/Gulps/AprilFools", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		AprilFools = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/Gulps/Short_", 1, 4, (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0.04f;
		Short = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/Gulps/Standard_", 1, 10, (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0.04f;
		Standard = val;
	}
}
