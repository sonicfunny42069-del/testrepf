using Terraria.Audio;

namespace V2.PlayerHandling;

public static class PreyPlayerDigestionSounds
{
	public static readonly SoundStyle PlayerDigestingMale;

	public static readonly SoundStyle PlayerDigestingFemale;

	static PreyPlayerDigestionSounds()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle val = default(SoundStyle);
		((SoundStyle)(ref val))._002Ector("V2/PlayerHandling/MaleHit_FromDigestTick", 0, 3, (SoundType)0);
		((SoundStyle)(ref val)).Volume = 1f;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		PlayerDigestingMale = val;
		((SoundStyle)(ref val))._002Ector("V2/PlayerHandling/FemaleHit_FromDigestTick", 0, 3, (SoundType)0);
		((SoundStyle)(ref val)).Volume = 1f;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		PlayerDigestingFemale = val;
	}
}
