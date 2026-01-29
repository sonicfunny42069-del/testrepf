using BetterDialogue.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.NPCs.Vanilla.TownNPCs.Nurse.ChatButtons;

public class FinishTummyHealButton : ChatButton
{
	public override double Priority => ((ChatButton)ChatButton.NurseHeal).Priority;

	public override string Text(NPC npc, Player player)
	{
		string buttonText = "Finish Healing";
		if (npc.AsNurse().healOvertime > 0)
		{
			int originalPrice = (int)((double)npc.AsNurse().originalHealPrice * 0.8) + npc.AsNurse().healOvertime;
			PlayerLoader.ModifyNursePrice(Main.LocalPlayer, npc, 0, false, ref originalPrice);
			int platOvertimeFee = 0;
			int goldOvertimeFee = 0;
			int silverOvertimeFee = 0;
			int copperOvertimeFee = 0;
			if (originalPrice >= 1000000)
			{
				platOvertimeFee = originalPrice / 1000000;
				originalPrice -= platOvertimeFee * 1000000;
			}
			if (originalPrice >= 10000)
			{
				goldOvertimeFee = originalPrice / 10000;
				originalPrice -= goldOvertimeFee * 10000;
			}
			if (originalPrice >= 100)
			{
				silverOvertimeFee = originalPrice / 100;
				originalPrice -= silverOvertimeFee * 100;
			}
			if (originalPrice >= 1)
			{
				copperOvertimeFee = originalPrice;
			}
			if (originalPrice > 0)
			{
				buttonText += " (";
				if (platOvertimeFee > 0)
				{
					buttonText = buttonText + platOvertimeFee + " " + Lang.inter[15].Value + " ";
				}
				if (goldOvertimeFee > 0)
				{
					buttonText = buttonText + goldOvertimeFee + " " + Lang.inter[16].Value + " ";
				}
				if (silverOvertimeFee > 0)
				{
					buttonText = buttonText + silverOvertimeFee + " " + Lang.inter[17].Value + " ";
				}
				if (copperOvertimeFee > 0)
				{
					buttonText = buttonText + copperOvertimeFee + " " + Lang.inter[18].Value + " ";
				}
				buttonText += ")";
			}
		}
		return buttonText;
	}

	public override Color? OverrideColor(NPC npc, Player player)
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if (npc.AsNurse().healOvertime > 0)
		{
			int originalPrice = (int)((double)npc.AsNurse().originalHealPrice * 0.8) + npc.AsNurse().healOvertime;
			int platOvertimeFee = 0;
			int goldOvertimeFee = 0;
			int silverOvertimeFee = 0;
			int copperOvertimeFee = 0;
			if (originalPrice >= 1000000)
			{
				platOvertimeFee = originalPrice / 1000000;
				originalPrice -= platOvertimeFee * 1000000;
			}
			if (originalPrice >= 10000)
			{
				goldOvertimeFee = originalPrice / 10000;
				originalPrice -= goldOvertimeFee * 10000;
			}
			if (originalPrice >= 100)
			{
				silverOvertimeFee = originalPrice / 100;
				originalPrice -= silverOvertimeFee * 100;
			}
			if (originalPrice >= 1)
			{
				copperOvertimeFee = originalPrice;
			}
			float num11 = (float)(int)Main.mouseTextColor / 255f;
			if (platOvertimeFee > 0)
			{
				return new Color((int)(byte)(220f * num11), (int)(byte)(220f * num11), (int)(byte)(198f * num11), (int)Main.mouseTextColor);
			}
			if (goldOvertimeFee > 0)
			{
				return new Color((int)(byte)(224f * num11), (int)(byte)(201f * num11), (int)(byte)(92f * num11), (int)Main.mouseTextColor);
			}
			if (silverOvertimeFee > 0)
			{
				return new Color((int)(byte)(181f * num11), (int)(byte)(192f * num11), (int)(byte)(193f * num11), (int)Main.mouseTextColor);
			}
			if (copperOvertimeFee > 0)
			{
				return new Color((int)(byte)(246f * num11), (int)(byte)(138f * num11), (int)(byte)(96f * num11), (int)Main.mouseTextColor);
			}
		}
		return Color.Gray;
	}

	public override bool IsActive(NPC npc, Player player)
	{
		if (npc.type == 18 && player.IsFoodFor((Entity)(object)npc, out var pastTense) && !pastTense)
		{
			return npc.AsNurse().healPlayerIndex == ((Entity)player).whoAmI;
		}
		return false;
	}

	public override void OnClick(NPC npc, Player player)
	{
		if (npc.AsNurse().healOvertime > 0)
		{
			if (Main.LocalPlayer.BuyItem((long)((int)((double)npc.AsNurse().originalHealPrice * 0.8) + npc.AsNurse().healOvertime), -1))
			{
				PredNPC.GetStomachTracker(npc).Prey.RemoveAll(delegate(PreyData x)
				{
					if (x.Type == PreyType.Player && !x.NoHealth)
					{
						Entity instance = x.Instance;
						return ((instance is Player) ? instance : null).whoAmI == ((Entity)Main.CurrentPlayer).whoAmI;
					}
					return false;
				});
				npc.AsNurse().healPlayerIndex = -1;
				npc.AsNurse().originalHealPrice = 0;
				npc.AsNurse().healOvertime = 0;
				npc.AsNurse().digestScamPatient = false;
				Main.npcChatText = "Ready to get out, then? Feels like you've got enough to pay in there, too. Alright, give me a moment...\n[c/7F7F7F:<" + npc.GivenName + "'s stomach begins convulsing rhythmically as you begin to be forced back up her throat and out of her mouth. Once you're safely out of her stomach, she takes her payment before you have the chance to give it to her yourself.>]\nThere you go. Good as new, and you didn't even need to get melted into butt fat. Be grateful I gave you that much, and don't ask for a lollipop.";
			}
			else
			{
				npc.AsNurse().originalHealPrice = 0;
				npc.AsNurse().healOvertime = 0;
				npc.AsNurse().digestScamPatient = true;
				Main.npcChatText = "Really? Trying to undercut ME on healing? Why, you little prick...\n[c/7F7F7F:<As if on cue, " + npc.GivenName + "'s stomach roars to life, acids already starting to flood in to melt you down just as readily as she'd healed you up only moments prior.>]\nHope you enjoyed the \"free\" treatment while it lasted, " + Main.LocalPlayer.name + ". You're about to find out firsthand why healthcare isn't free, cheapskate!";
			}
		}
		else
		{
			Main.npcChatText = "Your healing's not even done yet. Sit still in there until me and my gut are done fixing you up.";
		}
	}
}
