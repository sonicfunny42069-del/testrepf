using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace V2.NPCs.Voraria.TownNPCs.Enigma;

public class EnigmaProfile : ITownNPCProfile
{
	private Asset<Texture2D> _defaultNoAlt;

	public EnigmaProfile()
	{
		if (!Main.dedServ)
		{
			string npcFileTitleFilePath = "V2/NPCs/Voraria/TownNPCs/Enigma/Clover_WeightBase_BellyBase";
			_defaultNoAlt = ModContent.Request<Texture2D>(npcFileTitleFilePath, (AssetRequestMode)1);
		}
	}

	public int RollVariation()
	{
		return 0;
	}

	public string GetNameForVariant(NPC npc)
	{
		return "Clover";
	}

	public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
	{
		if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
		{
			return _defaultNoAlt;
		}
		string weightString = "_WeightBase";
		string text = "V2/NPCs/Voraria/TownNPCs/Enigma/Clover" + weightString;
		int bellySize = 0;
		if (!V2.GetFooled)
		{
			bellySize = npc.AsPred().GetVisualBellySize(npc);
		}
		string bellyString = "_Belly" + ((bellySize == 0) ? "Base" : ((object)bellySize));
		return ModContent.Request<Texture2D>(text + bellyString, (AssetRequestMode)1);
	}

	public int GetHeadTextureIndex(NPC npc)
	{
		return ModContent.GetModHeadSlot("V2/NPCs/Voraria/TownNPCs/Enigma/Clover_Head");
	}
}
