using Terraria.Audio;

namespace V2.Sounds.MuffledSounds;

public static class MuffledMiscSounds
{
	public static readonly SoundStyle Shatter;

	static MuffledMiscSounds()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle shatter = default(SoundStyle);
		((SoundStyle)(ref shatter))._002Ector("V2/Sounds/MuffledSounds/Shatter", (SoundType)0);
		((SoundStyle)(ref shatter)).MaxInstances = 0;
		Shatter = shatter;
	}
}
