using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Items.Voraria.CheatItems;

namespace V2.Commands;

public class AuthorMessage : ModCommand
{
	public override string Command => "authormessage";

	public override CommandType Type => (CommandType)1;

	public override void Action(CommandCaller caller, string input, string[] args)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (!(caller.Player.name != "Rose") && caller.Player.HasItem(ModContent.ItemType<ServerMessageRelay>()))
		{
			string realInput = input.Remove(0, "authormessage".Length + 2);
			if (Main.netMode == 0)
			{
				Main.NewText((object)("[SERVER] " + realInput), (Color?)V2Colors.CarmineThread);
			}
			else
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("[SERVER] " + realInput), V2Colors.CarmineThread, -1);
			}
		}
	}
}
