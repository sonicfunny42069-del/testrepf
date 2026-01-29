using Terraria.Audio;

namespace V2.Sounds.MuffledSounds;

public static class MuffledItemSounds
{
	public static readonly SoundStyle MagicMirrorTeleport;

	static MuffledItemSounds()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle magicMirrorTeleport = default(SoundStyle);
		((SoundStyle)(ref magicMirrorTeleport))._002Ector("V2/Sounds/MuffledSounds/Item6", (SoundType)0);
		((SoundStyle)(ref magicMirrorTeleport)).MaxInstances = 0;
		MagicMirrorTeleport = magicMirrorTeleport;
	}
}
