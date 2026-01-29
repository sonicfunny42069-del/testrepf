using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs;
using V2.Sounds.Vore;

namespace V2.AprilFools;

public class AprilFoolsPredNPC : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return true;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		npc.AsPred().CanSwallowBosses = true;
		npc.AsPred().BigGulps = Gulps.AprilFools;
		npc.AsPred().BaseStomachacheMeterCapacity = 9999999.0;
		npc.AsPred().MaxStomachCapacity = 9999999.0;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerDeathMessage;
		npc.AsPred().StandardBurps = Burps.AprilFools;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return (double)npc.damage * 0.5;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return (double)npc.lifeMax * 0.1 * ((double)npc.life / (double)npc.lifeMax) * (double)npc.scale;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 1) * (double)npc.scale;
	}

	public override void PostAI(NPC npc)
	{
		npc.scale = 1f + (float)npc.AsPred().ExtraWeight * 0.2f;
		if (((Entity)(object)npc).CurrentCaptor() == null)
		{
			npc.DoContactGulpage();
		}
	}

	public static void GetDigestedPlayerDeathMessage(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.Clear();
		deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.AprilFools");
	}

	public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() == null)
		{
			SpriteEffects val = ((((Entity)npc).direction != -1) ? ((SpriteEffects)0) : ((SpriteEffects)1));
			SpriteEffects spriteEffects = val;
			double bellySize = PredNPC.GetCurrentBellyWeight(npc);
			bellySize /= PreyData.NewData((Entity)(object)npc).InitialSize;
			Texture2D texture = ModContent.Request<Texture2D>("V2/AprilFools/Belly", (AssetRequestMode)1).Value;
			spriteBatch.Draw(texture, ((Entity)npc).Center - screenPos + new Vector2(0f, npc.gfxOffY) + new Vector2((((Entity)npc).direction == 1) ? 6f : (-26f), 2f) * (float)bellySize, (Rectangle?)texture.Bounds, drawColor, npc.rotation, new Vector2(32f, 32f), (float)bellySize * 0.33f, spriteEffects, 0f);
		}
	}
}
