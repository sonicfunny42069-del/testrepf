using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.TownNPCs.ArmsDealer;

public class ArmsDealerProfile : ITownNPCProfile
{
	private Asset<Texture2D> _defaultNoAlt;

	public ArmsDealerProfile()
	{
		if (!Main.dedServ)
		{
			string npcFileTitleFilePath = "V2/NPCs/Vanilla/TownNPCs/ArmsDealer/ArmsDealer_WeightBase_BellyBase";
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
		string weightString = "_WeightBase";
		string text = "V2/NPCs/Vanilla/TownNPCs/ArmsDealer/ArmsDealer" + weightString;
		int bellySize = npc.AsPred().GetVisualBellySize(npc);
		string bellyString = "_Belly" + ((bellySize == 0) ? "Base" : ((object)bellySize));
		return ModContent.Request<Texture2D>(text + bellyString, (AssetRequestMode)1);
	}

	public int GetHeadTextureIndex(NPC npc)
	{
		return 6;
	}
}
