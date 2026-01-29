using Terraria.Audio;

namespace V2.Sounds.MuffledSounds;

public static class MuffledNPCSounds
{
	public static readonly SoundStyle NPCHit1;

	public static readonly SoundStyle NPCHit2;

	public static readonly SoundStyle NPCHit3;

	public static readonly SoundStyle NPCHit4;

	public static readonly SoundStyle NPCDeath1;

	public static readonly SoundStyle NPCDeath2;

	static MuffledNPCSounds()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle val = default(SoundStyle);
		((SoundStyle)(ref val))._002Ector("V2/Sounds/MuffledSounds/NPC_Hit_1", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		NPCHit1 = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/MuffledSounds/NPC_Hit_2", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		NPCHit2 = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/MuffledSounds/NPC_Hit_3", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		NPCHit3 = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/MuffledSounds/NPC_Hit_4", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		NPCHit4 = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/MuffledSounds/NPC_Killed_1", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		NPCDeath1 = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/MuffledSounds/NPC_Killed_2", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		NPCDeath2 = val;
	}
}
