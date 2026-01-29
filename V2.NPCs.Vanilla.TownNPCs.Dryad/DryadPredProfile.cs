using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.TownNPCs.Dryad;

public class DryadPredProfile : ITownNPCProfile
{
	private readonly Asset<Texture2D> _defaultNoAlt;

	public DryadPredProfile()
	{
		if (!Main.dedServ)
		{
			string npcFileTitleFilePath = "V2/NPCs/Vanilla/TownNPCs/Dryad/Dryad_WeightBase_BellyBase";
			_defaultNoAlt = ModContent.Request<Texture2D>(npcFileTitleFilePath, (AssetRequestMode)1);
		}
	}

	public int RollVariation()
	{
		return 0;
	}

	public string GetNameForVariant(NPC npc)
	{
		return npc.getNewNPCName();
	}

	public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
	{
		if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
		{
			return _defaultNoAlt;
		}
		string exactTextureToUse = "V2/NPCs/Vanilla/TownNPCs/Dryad/";
		foreach (ResourcePack enabledResourcePack in V2.EnabledResourcePacks)
		{
			bool packOverrideFound = false;
			if (enabledResourcePack.Name == "True Dryad Fan")
			{
				exactTextureToUse += "AltSheetSets/True Dryad Fan/";
				packOverrideFound = true;
			}
			if (packOverrideFound)
			{
				break;
			}
		}
		exactTextureToUse += "Dryad";
		string weightString = "_WeightBase";
		exactTextureToUse += weightString;
		int bellySize = npc.AsPred().GetVisualBellySize(npc);
		string bellyString = "_Belly" + ((bellySize == 0) ? "Base" : ((object)bellySize));
		exactTextureToUse += bellyString;
		return ModContent.Request<Texture2D>(exactTextureToUse, (AssetRequestMode)1);
	}

	public int GetHeadTextureIndex(NPC npc)
	{
		return 5;
	}
}
