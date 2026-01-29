using Terraria.Audio;

namespace V2.Sounds.Vore;

public static class StomachNoises
{
	public static readonly SoundStyle AprilFools;

	public static readonly SoundStyle Normal;

	public static readonly SoundStyle Muffled;

	static StomachNoises()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle val = default(SoundStyle);
		((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/StomachNoises/AprilFools", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		AprilFools = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/StomachNoises/Normal_", 1, 3, (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		Normal = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/Vore/StomachNoises/Muffled_", 1, 3, (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		Muffled = val;
	}
}
