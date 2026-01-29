using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;

namespace V2.NPCs;

public class GeneralNPC : GlobalNPC
{
	public delegate bool DelegateNewAI(NPC npc);

	public delegate void DelegateFirstFramePreAIMethod(NPC npc);

	public delegate List<string> DelegateGetChat(NPC npc, Player player);

	public EntityGender Gender;

	public SpriteAnimation CustomSprite { get; set; }

	public DelegateNewAI NewAIMethod { get; set; }

	public NPCBehaviorPattern BehaviorPattern { get; internal set; }

	public bool FirstFrame { get; set; }

	public DelegateFirstFramePreAIMethod FirstFramePreAIMethod { get; set; }

	public DelegateGetChat GetNewDialogue { get; set; }

	public double HealthRegenCount { get; set; }

	public double MaxHealthBoostCount { get; set; }

	public float TargetRange { get; set; }

	public bool TargetRequiresLineOfSight { get; set; }

	public TargetType TargetType { get; set; }

	public TargetPriorityLevel TargetPriority { get; set; }

	public bool IsTileEntity { get; set; }

	public int Aggro { get; set; }

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return true;
	}

	public GeneralNPC()
	{
		Gender = EntityGender.Other;
		NewAIMethod = null;
		FirstFrame = true;
		FirstFramePreAIMethod = null;
		TargetRange = 0f;
		TargetRequiresLineOfSight = false;
		TargetType = TargetType.None;
		TargetPriority = TargetPriorityLevel.Neutral;
		IsTileEntity = false;
		Aggro = 0;
		GetNewDialogue = null;
	}

	public override void ResetEffects(NPC npc)
	{
	}

	public static void SetChatboxText(NPC npc, Player player, string chatText)
	{
		Main.CancelHairWindow();
		Main.SetNPCShopIndex(0);
		Main.InGuideCraftMenu = false;
		player.dropItemCheck();
		Main.npcChatCornerItem = 0;
		player.sign = -1;
		Main.editSign = false;
		player.SetTalkNPC(((Entity)npc).whoAmI, false);
		Main.playerInventory = false;
		player.chest = -1;
		Recipe.FindRecipes(false);
		Main.npcChatText = chatText;
	}

	public override void GetChat(NPC npc, ref string chat)
	{
		if (npc.AsV2NPC().GetNewDialogue != null)
		{
			List<string> chatPool = npc.AsV2NPC().GetNewDialogue(npc, Main.CurrentPlayer);
			if (chatPool != null)
			{
				chat = Utils.NextFromCollection<string>(Main.rand, chatPool);
			}
		}
	}

	public override void SendExtraAI(NPC npc, BitWriter bitWriter, BinaryWriter binaryWriter)
	{
	}

	public override void ReceiveExtraAI(NPC npc, BitReader bitReader, BinaryReader binaryReader)
	{
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		if (npc.AsV2NPC().CustomSprite != null)
		{
			SpriteEffects val = ((((Entity)npc).direction != -1) ? ((SpriteEffects)0) : ((SpriteEffects)1));
			SpriteEffects spriteEffects = val;
			Texture2D texture = ModContent.Request<Texture2D>(((ModTexturedType)npc.AsV2NPC().CustomSprite).Texture, (AssetRequestMode)1).Value;
			Rectangle sourceRect = (Rectangle)(((_003F?)npc.AsV2NPC().CustomSprite.DecideFrame()) ?? texture.Bounds);
			spriteBatch.Draw(texture, ((Entity)npc).Center - screenPos + new Vector2(0f, npc.gfxOffY), (Rectangle?)sourceRect, drawColor, npc.rotation, Utils.Size(sourceRect) / 2f, 1f, spriteEffects, 0f);
			return false;
		}
		return true;
	}

	public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
	{
		((NPCLoot)(ref npcLoot)).RemoveWhere((Predicate<IItemDropRule>)delegate(IItemDropRule x)
		{
			DropBasedOnExpertMode val = (DropBasedOnExpertMode)(object)((x is DropBasedOnExpertMode) ? x : null);
			if (val != null)
			{
				IItemDropRule ruleForNormalMode = val.ruleForNormalMode;
				CommonDropWithRerolls val2 = (CommonDropWithRerolls)(object)((ruleForNormalMode is CommonDropWithRerolls) ? ruleForNormalMode : null);
				if (val2 != null)
				{
					return ((CommonDrop)val2).itemId == 885;
				}
			}
			return false;
		}, true);
	}
}
