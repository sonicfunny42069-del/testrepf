using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Voraria.Meteorite;

public class MeteorMarble : ModNPC
{
	public override string Texture => "V2/NPCs/Voraria/Meteorite/MeteorMarble_Core_Heat0";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return false;
	}

	public override void SetStaticDefaults()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.Velocity = 1f;
		val.Direction = -1;
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
	}

	public override void SetDefaults()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.friendly = false;
		((Entity)((ModNPC)this).NPC).width = 10;
		((Entity)((ModNPC)this).NPC).height = 10;
		((ModNPC)this).NPC.aiStyle = -1;
		((ModNPC)this).NPC.lifeMax = 90;
		((ModNPC)this).NPC.damage = 15;
		((ModNPC)this).NPC.defense = 5;
		((ModNPC)this).NPC.knockBackResist = 0.5f;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 0.4;
		((ModNPC)this).NPC.AsPred().DigestionType = EntityDigestionType.Thermal;
		((ModNPC)this).NPC.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModNPC)this).NPC.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModNPC)this).NPC.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		((ModNPC)this).NPC.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModNPC)this).NPC.AsPred().GetVisualBellySize = GetVisualBellySize;
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		bestiaryEntry.Info.AddRange((IEnumerable<IBestiaryInfoElement>)(object)new IBestiaryInfoElement[2]
		{
			(IBestiaryInfoElement)Biomes.Meteor,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.Meteorite.MeteorMarble")
		});
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Meteorite.MeteorMarble.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Meteorite.MeteorMarble.2" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Meteorite.MeteorMarble.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 10.0;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 15.0;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 0, 4);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 4);
	}

	public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
	{
	}
}
