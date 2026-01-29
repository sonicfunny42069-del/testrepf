using System.Collections.Generic;
using BetterDialogue.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.TownNPCs.Nurse.ChatButtons;

public class TraditionalHealButton : ChatButton
{
	public override double Priority => ((ChatButton)ChatButton.NurseHeal).Priority;

	public override string Text(NPC npc, Player player)
	{
		return "Traditional";
	}

	public override bool IsActive(NPC npc, Player player)
	{
		if (npc.type == 18)
		{
			return npc.AsNurse().healTypeChoice;
		}
		return false;
	}

	public override void OnClick(NPC npc, Player player)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		int health = Main.LocalPlayer.statLifeMax2 - Main.LocalPlayer.statLife;
		bool removeDebuffs = true;
		PlayerLoader.ModifyNursePrice(Main.LocalPlayer, npc, health, removeDebuffs, ref npc.AsNurse().originalHealPrice);
		if (npc.AsNurse().originalHealPrice > 0)
		{
			if (Main.LocalPlayer.BuyItem((long)npc.AsNurse().originalHealPrice, -1))
			{
				AchievementsHelper.HandleNurseService(npc.AsNurse().originalHealPrice);
				SoundEngine.PlaySound(ref SoundID.Item4, (Vector2?)null, (SoundUpdateCallback)null);
				SoundEngine.PlaySound(ref SoundID.Coins, (Vector2?)null, (SoundUpdateCallback)null);
				Main.LocalPlayer.HealEffect(health, true);
				if ((double)Main.LocalPlayer.statLife < (double)Main.LocalPlayer.statLifeMax2 * 0.25)
				{
					Main.npcChatText = Lang.dialog(227, false);
				}
				else if ((double)Main.LocalPlayer.statLife < (double)Main.LocalPlayer.statLifeMax2 * 0.5)
				{
					Main.npcChatText = Lang.dialog(228, false);
				}
				else if ((double)Main.LocalPlayer.statLife < (double)Main.LocalPlayer.statLifeMax2 * 0.75)
				{
					Main.npcChatText = Lang.dialog(229, false);
				}
				else
				{
					Main.npcChatText = Lang.dialog(230, false);
				}
				Player localPlayer = Main.LocalPlayer;
				localPlayer.statLife += health;
				if (removeDebuffs)
				{
					for (int l = 0; l < Player.MaxBuffs; l++)
					{
						int num24 = Main.LocalPlayer.buffType[l];
						if (Main.debuff[num24] && Main.LocalPlayer.buffTime[l] > 0 && (num24 < 0 || !Sets.NurseCannotRemoveDebuff[num24]))
						{
							Main.player[Main.myPlayer].DelBuff(l);
							l = -1;
						}
					}
				}
				PlayerLoader.PostNurseHeal(Main.LocalPlayer, npc, health, removeDebuffs, npc.AsNurse().originalHealPrice);
			}
			else
			{
				Main.npcChatText = Utils.NextFromCollection<string>(Main.rand, new List<string> { "You can't afford me. How unfortunate. Guess you'll have to stop wasting my time.", "I'll never be able to go for lunch if you keep calling me for check-ups you can't afford. And trust me, that won't stop me from eating.", "I don't work for free, and neither does my gut. Either cough up the cash for a traditional fix-up or get out." });
			}
		}
		else
		{
			Main.npcChatText = Utils.NextFromCollection<string>(Main.rand, new List<string> { "I don't give happy endings, unless you consider the chance to fatten up my glutes to be one.", "I'll never be able to go for lunch if you keep calling me for nothing. And trust me, that won't stop me from eating.", "You keep wasting my time, I'll see if I can somehow churn you into more space in the hospital I run around back." });
		}
		npc.AsNurse().healTypeChoice = false;
		npc.AsNurse().originalHealPrice = 0;
	}
}
