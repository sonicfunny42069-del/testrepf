using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace V2.Core;

public class V2MasterSystem : ModSystem
{
	public bool freedSucc;

	public bool freedAngel;

	public bool freedEnigma;

	public List<VoreTracker> VoreTrackers { get; set; } = new List<VoreTracker>();

	public override void OnWorldLoad()
	{
		VoreTrackers = new List<VoreTracker>();
		freedSucc = false;
		freedAngel = false;
		freedEnigma = false;
	}

	public override void OnWorldUnload()
	{
		VoreTrackers = new List<VoreTracker>();
		freedSucc = false;
		freedAngel = false;
		freedEnigma = false;
	}

	public override void PreUpdateEntities()
	{
		foreach (VoreTracker tracker in VoreTrackers)
		{
			tracker.UpdatePrey();
			if (Main.netMode == 0)
			{
				tracker.UpdateProgress();
				tracker.HandleStruggleSystem();
			}
		}
		VoreTrackers.RemoveAll((VoreTracker x) => x.CheckClearability());
	}

	public override void SaveWorldData(TagCompound tag)
	{
		tag["freedSucc"] = freedSucc;
		tag["freedAngel"] = freedAngel;
		tag["freedEnigma"] = freedEnigma;
	}

	public override void LoadWorldData(TagCompound tag)
	{
		freedSucc = tag.ContainsKey("freedSucc") && tag.GetBool("freedSucc");
		freedAngel = tag.ContainsKey("freedAngel") && tag.GetBool("freedAngel");
		freedEnigma = tag.ContainsKey("freedEnigma") && tag.GetBool("freedEnigma");
	}

	public override void NetSend(BinaryWriter writer)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		BitsByte flags = default(BitsByte);
		((BitsByte)(ref flags))._002Ector(freedSucc, freedAngel, freedEnigma, false, false, false, false, false);
		writer.Write(BitsByte.op_Implicit(flags));
	}

	public override void NetReceive(BinaryReader reader)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		BitsByte flags = BitsByte.op_Implicit(reader.ReadByte());
		freedSucc = ((BitsByte)(ref flags))[0];
		freedAngel = ((BitsByte)(ref flags))[1];
		freedEnigma = ((BitsByte)(ref flags))[2];
	}
}
