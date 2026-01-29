using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.TownNPCs;

public static class TownNPCAIReference
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static TileActionAttempt _003C0_003E__SearchAvoidedByNPCs;
	}

	public static void TownNPCVanillaAI(NPC npc)
	{
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0885: Unknown result type (might be due to invalid IL or missing references)
		//IL_088a: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0916: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0991: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Unknown result type (might be due to invalid IL or missing references)
		//IL_0814: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1001: Unknown result type (might be due to invalid IL or missing references)
		//IL_1005: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5173: Unknown result type (might be due to invalid IL or missing references)
		//IL_1195: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_68a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_524c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f68: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_68f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11db: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_52b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_52bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1235: Unknown result type (might be due to invalid IL or missing references)
		//IL_52cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_52e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1961: Unknown result type (might be due to invalid IL or missing references)
		//IL_221a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2224: Unknown result type (might be due to invalid IL or missing references)
		//IL_2229: Unknown result type (might be due to invalid IL or missing references)
		//IL_3135: Unknown result type (might be due to invalid IL or missing references)
		//IL_3147: Unknown result type (might be due to invalid IL or missing references)
		//IL_30e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_30fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_310a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5470: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_3551: Unknown result type (might be due to invalid IL or missing references)
		//IL_3556: Unknown result type (might be due to invalid IL or missing references)
		//IL_50e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_50eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_50ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_50f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_50f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_50fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_5103: Unknown result type (might be due to invalid IL or missing references)
		//IL_510a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4190: Unknown result type (might be due to invalid IL or missing references)
		//IL_419f: Unknown result type (might be due to invalid IL or missing references)
		//IL_41a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_41a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_41ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2624: Unknown result type (might be due to invalid IL or missing references)
		//IL_2629: Unknown result type (might be due to invalid IL or missing references)
		//IL_2631: Unknown result type (might be due to invalid IL or missing references)
		//IL_2636: Unknown result type (might be due to invalid IL or missing references)
		//IL_263e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2643: Unknown result type (might be due to invalid IL or missing references)
		//IL_2500: Unknown result type (might be due to invalid IL or missing references)
		//IL_2505: Unknown result type (might be due to invalid IL or missing references)
		//IL_41e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_41e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_41ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_41f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_420d: Unknown result type (might be due to invalid IL or missing references)
		//IL_421d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4224: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e14: Unknown result type (might be due to invalid IL or missing references)
		//IL_369a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2678: Unknown result type (might be due to invalid IL or missing references)
		//IL_2457: Unknown result type (might be due to invalid IL or missing references)
		//IL_245c: Unknown result type (might be due to invalid IL or missing references)
		//IL_59cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_44e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_44e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_36a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_3607: Unknown result type (might be due to invalid IL or missing references)
		//IL_3624: Unknown result type (might be due to invalid IL or missing references)
		//IL_3629: Unknown result type (might be due to invalid IL or missing references)
		//IL_362e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3633: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_5de5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_59dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_59e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e82: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e87: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_36e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_36eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_36f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3651: Unknown result type (might be due to invalid IL or missing references)
		//IL_366c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3689: Unknown result type (might be due to invalid IL or missing references)
		//IL_368e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3693: Unknown result type (might be due to invalid IL or missing references)
		//IL_3698: Unknown result type (might be due to invalid IL or missing references)
		//IL_601a: Unknown result type (might be due to invalid IL or missing references)
		//IL_601f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6025: Expected O, but got Unknown
		//IL_5ce3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b07: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4aa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4aaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_4aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4aba: Unknown result type (might be due to invalid IL or missing references)
		//IL_4abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_4556: Unknown result type (might be due to invalid IL or missing references)
		//IL_455b: Unknown result type (might be due to invalid IL or missing references)
		//IL_402b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4030: Unknown result type (might be due to invalid IL or missing references)
		//IL_4035: Unknown result type (might be due to invalid IL or missing references)
		//IL_4037: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e97: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eae: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_371d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3733: Unknown result type (might be due to invalid IL or missing references)
		//IL_3743: Unknown result type (might be due to invalid IL or missing references)
		//IL_374a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6030: Unknown result type (might be due to invalid IL or missing references)
		//IL_6044: Unknown result type (might be due to invalid IL or missing references)
		//IL_6049: Unknown result type (might be due to invalid IL or missing references)
		//IL_604e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6053: Unknown result type (might be due to invalid IL or missing references)
		//IL_6055: Unknown result type (might be due to invalid IL or missing references)
		//IL_605c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ef4: Unknown result type (might be due to invalid IL or missing references)
		//IL_5efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_5cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_456b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4586: Unknown result type (might be due to invalid IL or missing references)
		//IL_45a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_45a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_45ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4045: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ebe: Unknown result type (might be due to invalid IL or missing references)
		//IL_3783: Unknown result type (might be due to invalid IL or missing references)
		//IL_3799: Unknown result type (might be due to invalid IL or missing references)
		//IL_37a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_37b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_606f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6076: Unknown result type (might be due to invalid IL or missing references)
		//IL_607d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6082: Unknown result type (might be due to invalid IL or missing references)
		//IL_55bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_4efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_4eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_45bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_405a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ee5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ee9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f06: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_37e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_380f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3816: Unknown result type (might be due to invalid IL or missing references)
		//IL_60ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_60cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_55d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_45e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_45e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_45ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_45ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_4600: Unknown result type (might be due to invalid IL or missing references)
		//IL_4605: Unknown result type (might be due to invalid IL or missing references)
		//IL_460a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f56: Unknown result type (might be due to invalid IL or missing references)
		//IL_57d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_55e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_55ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_57e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2906: Unknown result type (might be due to invalid IL or missing references)
		//IL_291f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e51: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_57fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_5803: Unknown result type (might be due to invalid IL or missing references)
		//IL_4713: Unknown result type (might be due to invalid IL or missing references)
		//IL_4720: Unknown result type (might be due to invalid IL or missing references)
		//IL_472a: Unknown result type (might be due to invalid IL or missing references)
		//IL_472f: Unknown result type (might be due to invalid IL or missing references)
		//IL_473c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4750: Unknown result type (might be due to invalid IL or missing references)
		//IL_4755: Unknown result type (might be due to invalid IL or missing references)
		//IL_475f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4764: Unknown result type (might be due to invalid IL or missing references)
		//IL_4769: Unknown result type (might be due to invalid IL or missing references)
		//IL_464d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4652: Unknown result type (might be due to invalid IL or missing references)
		//IL_465c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4672: Unknown result type (might be due to invalid IL or missing references)
		//IL_4682: Unknown result type (might be due to invalid IL or missing references)
		//IL_4689: Unknown result type (might be due to invalid IL or missing references)
		//IL_4691: Unknown result type (might be due to invalid IL or missing references)
		//IL_4698: Unknown result type (might be due to invalid IL or missing references)
		//IL_62ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_62f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_61a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_61b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a50: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_49ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_49c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_49d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_49d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4884: Unknown result type (might be due to invalid IL or missing references)
		//IL_4891: Unknown result type (might be due to invalid IL or missing references)
		//IL_48a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_48aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_48b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_48b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_48be: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_6479: Unknown result type (might be due to invalid IL or missing references)
		//IL_6488: Unknown result type (might be due to invalid IL or missing references)
		//IL_61d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e07: Unknown result type (might be due to invalid IL or missing references)
		//IL_4808: Unknown result type (might be due to invalid IL or missing references)
		//IL_480f: Unknown result type (might be due to invalid IL or missing references)
		//IL_47dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_47e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_47f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_65fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_660a: Unknown result type (might be due to invalid IL or missing references)
		//IL_64d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_64d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_64db: Unknown result type (might be due to invalid IL or missing references)
		//IL_64dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_634d: Unknown result type (might be due to invalid IL or missing references)
		//IL_635a: Unknown result type (might be due to invalid IL or missing references)
		//IL_630d: Unknown result type (might be due to invalid IL or missing references)
		//IL_631c: Unknown result type (might be due to invalid IL or missing references)
		//IL_493d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4944: Unknown result type (might be due to invalid IL or missing references)
		//IL_4914: Unknown result type (might be due to invalid IL or missing references)
		//IL_491f: Unknown result type (might be due to invalid IL or missing references)
		//IL_492a: Unknown result type (might be due to invalid IL or missing references)
		//IL_477f: Unknown result type (might be due to invalid IL or missing references)
		//IL_478c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4796: Unknown result type (might be due to invalid IL or missing references)
		//IL_479b: Unknown result type (might be due to invalid IL or missing references)
		//IL_47a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_47bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_47c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_47cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_47d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_47d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_6799: Unknown result type (might be due to invalid IL or missing references)
		//IL_67a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_64ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_649c: Unknown result type (might be due to invalid IL or missing references)
		//IL_64ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f63: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_48d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_48e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_48f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_48f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4903: Unknown result type (might be due to invalid IL or missing references)
		//IL_4908: Unknown result type (might be due to invalid IL or missing references)
		//IL_490d: Unknown result type (might be due to invalid IL or missing references)
		//IL_661e: Unknown result type (might be due to invalid IL or missing references)
		//IL_662d: Unknown result type (might be due to invalid IL or missing references)
		//IL_652b: Unknown result type (might be due to invalid IL or missing references)
		//IL_67bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_67cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f77: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f86: Unknown result type (might be due to invalid IL or missing references)
		NPC.ShimmeredTownNPCs[npc.type] = npc.IsShimmerVariant;
		if (npc.type == 441 && npc.GivenName == "Andrew")
		{
			npc.defDefense = 200;
		}
		int num = 300;
		if (npc.type == 638 || npc.type == 656 || Sets.IsTownSlime[npc.type])
		{
			num = 0;
		}
		bool tryToStayInHouse = Main.raining;
		if (!Main.dayTime)
		{
			tryToStayInHouse = true;
		}
		if (Main.eclipse)
		{
			tryToStayInHouse = true;
		}
		if (Main.slimeRain)
		{
			tryToStayInHouse = true;
		}
		float damageMult = 1f;
		if (Main.masterMode)
		{
			npc.defense = (npc.dryadWard ? (npc.defDefense + 14) : npc.defDefense);
		}
		else if (Main.expertMode)
		{
			npc.defense = (npc.dryadWard ? (npc.defDefense + 10) : npc.defDefense);
		}
		else
		{
			npc.defense = (npc.dryadWard ? (npc.defDefense + 6) : npc.defDefense);
		}
		if (npc.isLikeATownNPC)
		{
			if (NPC.combatBookWasUsed)
			{
				damageMult += 0.2f;
				npc.defense += 6;
			}
			if (NPC.combatBookVolumeTwoWasUsed)
			{
				damageMult += 0.2f;
				npc.defense += 6;
			}
			if (NPC.downedBoss1)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (NPC.downedBoss2)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (NPC.downedBoss3)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (NPC.downedQueenBee)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (Main.hardMode)
			{
				damageMult += 0.4f;
				npc.defense += 12;
			}
			if (NPC.downedQueenSlime)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedMechBoss1)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedMechBoss2)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedMechBoss3)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedPlantBoss)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			if (NPC.downedEmpressOfLight)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			if (NPC.downedGolemBoss)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			if (NPC.downedAncientCultist)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			NPCLoader.BuffTownNPC(ref damageMult, ref npc.defense);
		}
		if (npc.type == 142 && Main.netMode != 1 && !Main.xMas)
		{
			npc.SimpleStrikeNPC(9999, 0, false, 0f, (DamageClass)null, false, 0f, true);
			if (Main.netMode == 2)
			{
				NetMessage.SendData(28, -1, -1, (NetworkText)null, ((Entity)npc).whoAmI, 9999f, 0f, 0f, 0, 0, 0);
			}
		}
		if ((npc.type == 148 || npc.type == 149) && npc.localAI[0] == 0f)
		{
			npc.localAI[0] = Main.rand.Next(1, 5);
		}
		if (npc.type == 124)
		{
			int num3 = NPC.lazyNPCOwnedProjectileSearchArray[((Entity)npc).whoAmI];
			bool flag2 = false;
			if (Utils.IndexInRange<Projectile>(Main.projectile, num3))
			{
				Projectile projectile = Main.projectile[num3];
				if (((Entity)projectile).active && projectile.type == 582 && projectile.ai[1] == (float)((Entity)npc).whoAmI)
				{
					flag2 = true;
				}
			}
			npc.localAI[0] = Utils.ToInt(flag2);
		}
		if ((npc.type == 362 || npc.type == 364 || npc.type == 602 || npc.type == 608) && Main.netMode != 1 && (((Entity)npc).velocity.Y > 4f || ((Entity)npc).velocity.Y < -4f || ((Entity)npc).wet))
		{
			int num4 = ((Entity)npc).direction;
			npc.Transform(npc.type + 1);
			npc.TargetClosest(true);
			((Entity)npc).direction = num4;
			npc.netUpdate = true;
			return;
		}
		switch (npc.type)
		{
		case 588:
			NPC.savedGolfer = true;
			break;
		case 441:
			NPC.savedTaxCollector = true;
			break;
		case 107:
			NPC.savedGoblin = true;
			break;
		case 108:
			NPC.savedWizard = true;
			break;
		case 124:
			NPC.savedMech = true;
			break;
		case 353:
			NPC.savedStylist = true;
			break;
		case 369:
			NPC.savedAngler = true;
			break;
		case 550:
			NPC.savedBartender = true;
			break;
		}
		npc.dontTakeDamage = false;
		Color val;
		if (npc.ai[0] == 25f)
		{
			npc.dontTakeDamage = true;
			if (npc.ai[1] == 0f)
			{
				((Entity)npc).velocity.X = 0f;
			}
			((Entity)npc).shimmerWet = false;
			((Entity)npc).wet = false;
			((Entity)npc).lavaWet = false;
			((Entity)npc).honeyWet = false;
			if (npc.ai[1] == 0f && Main.netMode == 1)
			{
				return;
			}
			if (npc.ai[1] == 0f && npc.ai[2] < 1f)
			{
				AI_007_TownEntities_Shimmer_TeleportToLandingSpot(npc);
			}
			if (npc.ai[2] > 0f)
			{
				npc.ai[2] -= 1f;
				if (npc.ai[2] <= 0f)
				{
					npc.ai[1] = 1f;
				}
				return;
			}
			npc.ai[1] += 1f;
			if (npc.ai[1] >= 30f)
			{
				if (!Collision.WetCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height))
				{
					npc.shimmerTransparency = MathHelper.Clamp(npc.shimmerTransparency - 1f / 60f, 0f, 1f);
				}
				else
				{
					npc.ai[1] = 30f;
				}
				((Entity)npc).velocity = new Vector2(0f, -4f * npc.shimmerTransparency);
			}
			Rectangle hitbox = ((Entity)npc).Hitbox;
			hitbox.Y += 20;
			hitbox.Height -= 20;
			float num5 = Utils.NextFloatDirection(Main.rand);
			Vector2 center = ((Entity)npc).Center;
			val = Main.hslToRgb((float)Main.timeForVisualEffects / 360f % 1f, 0.6f, 0.65f, byte.MaxValue);
			Lighting.AddLight(center, ((Color)(ref val)).ToVector3() * Utils.Remap(npc.ai[1], 30f, 90f, 0f, 0.7f, true));
			if (Utils.NextFloat(Main.rand) > Utils.Remap(npc.ai[1], 30f, 60f, 1f, 0.5f, true))
			{
				Vector2 val2 = Utils.NextVector2FromRectangle(Main.rand, hitbox) + Utils.NextVector2Circular(Main.rand, 8f, 0f) + new Vector2(0f, 4f);
				Vector2? val3 = Utils.RotatedBy(new Vector2(0f, -2f), (double)(num5 * ((float)Math.PI * 2f) * 0.11f), default(Vector2));
				val = default(Color);
				Dust.NewDustPerfect(val2, 309, val3, 0, val, 1.7f - Math.Abs(num5) * 1.3f);
			}
			if (npc.ai[1] > 60f && Utils.NextBool(Main.rand, 15))
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector = Utils.NextVector2FromRectangle(Main.rand, ((Entity)npc).Hitbox);
					ParticleOrchestrator.RequestParticleSpawn(true, (ParticleOrchestraType)27, new ParticleOrchestraSettings
					{
						PositionInWorld = vector,
						MovementVector = Utils.RotatedBy(((Entity)npc).DirectionTo(vector), (double)((float)Math.PI * 9f / 20f * (float)(Main.rand.Next(2) * 2 - 1)), default(Vector2)) * Utils.NextFloat(Main.rand)
					}, (int?)null);
				}
			}
			npc.TargetClosest(true);
			NPCAimedTarget targetData = npc.GetTargetData(true);
			if (npc.ai[1] >= 75f && npc.shimmerTransparency <= 0f && Main.netMode != 1)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 0f;
				npc.ai[2] = 0f;
				npc.ai[3] = 0f;
				Math.Sign(((NPCAimedTarget)(ref targetData)).Center.X - ((Entity)npc).Center.X);
				((Entity)npc).velocity = new Vector2(0f, -4f);
				npc.localAI[0] = 0f;
				npc.localAI[1] = 0f;
				npc.localAI[2] = 0f;
				npc.localAI[3] = 0f;
				npc.netUpdate = true;
				npc.townNpcVariationIndex = ((npc.townNpcVariationIndex != 1) ? 1 : 0);
				NetMessage.SendData(56, -1, -1, (NetworkText)null, ((Entity)npc).whoAmI, 0f, 0f, 0f, 0, 0, 0);
				npc.Teleport(((Entity)npc).position, 12, 0);
				ParticleOrchestrator.BroadcastParticleSpawn((ParticleOrchestraType)31, new ParticleOrchestraSettings
				{
					PositionInWorld = ((Entity)npc).Center
				});
			}
			return;
		}
		if (npc.type >= 0 && Sets.TownCritter[npc.type] && npc.target == 255)
		{
			npc.TargetClosest(true);
			if (((Entity)npc).position.X < ((Entity)Main.player[npc.target]).position.X)
			{
				((Entity)npc).direction = 1;
				npc.spriteDirection = ((Entity)npc).direction;
			}
			if (((Entity)npc).position.X > ((Entity)Main.player[npc.target]).position.X)
			{
				((Entity)npc).direction = -1;
				npc.spriteDirection = ((Entity)npc).direction;
			}
			if (npc.homeTileX == -1)
			{
				npc.UpdateHomeTileState(npc.homeless, (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f), npc.homeTileY);
			}
		}
		else if (npc.homeTileX == -1 && npc.homeTileY == -1 && ((Entity)npc).velocity.Y == 0f && !npc.shimmering)
		{
			npc.UpdateHomeTileState(npc.homeless, (int)((Entity)npc).Center.X / 16, (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 4f) / 16);
		}
		bool flag3 = false;
		int num6 = (int)(((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16;
		int num7 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 1f) / 16;
		AI_007_FindGoodRestingSpot(npc, num6, num7, out var floorX, out var floorY);
		if (npc.type == 441)
		{
			NPC.taxCollector = true;
		}
		npc.directionY = -1;
		if (((Entity)npc).direction == 0)
		{
			((Entity)npc).direction = 1;
		}
		if (npc.ai[0] != 24f)
		{
			for (int j = 0; j < 255; j++)
			{
				if (((Entity)Main.player[j]).active && Main.player[j].talkNPC == ((Entity)npc).whoAmI)
				{
					flag3 = true;
					if (npc.ai[0] != 0f)
					{
						npc.netUpdate = true;
					}
					npc.ai[0] = 0f;
					npc.ai[1] = 300f;
					npc.localAI[3] = 100f;
					if (((Entity)Main.player[j]).position.X + (float)(((Entity)Main.player[j]).width / 2) < ((Entity)npc).position.X + (float)(((Entity)npc).width / 2))
					{
						((Entity)npc).direction = -1;
					}
					else
					{
						((Entity)npc).direction = 1;
					}
				}
			}
		}
		if (npc.ai[3] == 1f)
		{
			npc.life = -1;
			npc.HitEffect(0, 10.0, (bool?)null);
			((Entity)npc).active = false;
			npc.netUpdate = true;
			if (npc.type == 37)
			{
				SoundEngine.PlaySound(ref SoundID.Roar, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
			}
			return;
		}
		if (npc.type == 37 && Main.netMode != 1)
		{
			npc.UpdateHomeTileState(false, Main.dungeonX, Main.dungeonY);
			if (NPC.downedBoss3)
			{
				npc.ai[3] = 1f;
				npc.netUpdate = true;
			}
		}
		if (npc.type == 368)
		{
			npc.homeless = true;
			if (!Main.dayTime)
			{
				if (!npc.shimmering)
				{
					npc.UpdateHomeTileState(npc.homeless, (int)(((Entity)npc).Center.X / 16f), (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 2f) / 16);
				}
				if (!flag3 && npc.ai[0] == 0f)
				{
					npc.ai[0] = 1f;
					npc.ai[1] = 200f;
				}
				tryToStayInHouse = false;
			}
		}
		if (npc.type == 369 && npc.homeless && ((Entity)npc).wet)
		{
			if (((Entity)npc).Center.X / 16f < 380f || ((Entity)npc).Center.X / 16f > (float)(Main.maxTilesX - 380))
			{
				npc.UpdateHomeTileState(npc.homeless, Main.spawnTileX, Main.spawnTileY);
				npc.ai[0] = 1f;
				npc.ai[1] = 200f;
			}
			if (((Entity)npc).position.X / 16f < 300f)
			{
				((Entity)npc).direction = 1;
			}
			else if (((Entity)npc).position.X / 16f > (float)(Main.maxTilesX - 300))
			{
				((Entity)npc).direction = -1;
			}
		}
		if (!WorldGen.InWorld(num6, num7, 0) || (Main.netMode == 1 && !Main.sectionManager.TileLoaded(num6, num7)))
		{
			return;
		}
		Tile val4;
		if (!npc.homeless && Main.netMode != 1 && npc.townNPC)
		{
			if (tryToStayInHouse)
			{
				goto IL_0ec6;
			}
			if (npc.type == 37)
			{
				bool[] tileDungeon = Main.tileDungeon;
				val4 = ((Tilemap)(ref Main.tile))[num6, num7];
				if (tileDungeon[((Tile)(ref val4)).TileType])
				{
					goto IL_0ec6;
				}
			}
		}
		goto IL_103e;
		IL_0ec6:
		if (!AI_007_TownEntities_IsInAGoodRestingSpot(npc, num6, num7, floorX, floorY))
		{
			bool flag4 = true;
			Rectangle rectangle = default(Rectangle);
			for (int k = 0; k < 2; k++)
			{
				if (!flag4)
				{
					break;
				}
				((Rectangle)(ref rectangle))._002Ector((int)(((Entity)npc).position.X + (float)(((Entity)npc).width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(((Entity)npc).position.Y + (float)(((Entity)npc).height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
				if (k == 1)
				{
					((Rectangle)(ref rectangle))._002Ector(floorX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, floorY * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
				}
				for (int l = 0; l < 255; l++)
				{
					if (((Entity)Main.player[l]).active)
					{
						Rectangle val5 = new Rectangle((int)((Entity)Main.player[l]).position.X, (int)((Entity)Main.player[l]).position.Y, ((Entity)Main.player[l]).width, ((Entity)Main.player[l]).height);
						if (((Rectangle)(ref val5)).Intersects(rectangle))
						{
							flag4 = false;
							break;
						}
					}
				}
			}
			if (flag4)
			{
				AI_007_TownEntities_TeleportToHome(npc, floorX, floorY);
			}
		}
		goto IL_103e;
		IL_103e:
		bool isRodent = npc.type == 300 || npc.type == 447 || npc.type == 610;
		bool canBreatheUnderwater = npc.type == 616 || npc.type == 617 || npc.type == 625;
		bool flag7 = npc.type == 361 || npc.type == 445 || npc.type == 687;
		bool flag8 = Sets.IsTownSlime[npc.type];
		_ = Sets.IsTownPet[npc.type];
		bool flag9 = canBreatheUnderwater || flag7;
		bool flag10 = canBreatheUnderwater || flag7;
		bool flag11 = flag8;
		bool flag12 = flag8;
		float num8 = 200f;
		if (Sets.DangerDetectRange[npc.type] != -1)
		{
			num8 = Sets.DangerDetectRange[npc.type];
		}
		bool flag13 = false;
		bool flag14 = false;
		float num9 = -1f;
		float num10 = -1f;
		int num11 = 0;
		int num12 = -1;
		int num13 = -1;
		bool keepwalking;
		if (!canBreatheUnderwater && Main.netMode != 1 && !flag3)
		{
			for (int m = 0; m < 200; m++)
			{
				if (!((Entity)Main.npc[m]).active || Main.npc[m].friendly || Main.npc[m].damage <= 0 || !(((Entity)Main.npc[m]).Distance(((Entity)npc).Center) < num8) || (npc.type == 453 && Sets.Skeletons[Main.npc[m].type]) || (!Main.npc[m].noTileCollide && !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[m]).Center, 0, 0)) || !NPCLoader.CanHitNPC(Main.npc[m], npc))
				{
					continue;
				}
				bool flag15 = Main.npc[m].CanBeChasedBy((object)npc, false);
				flag13 = true;
				float num14 = ((Entity)Main.npc[m]).Center.X - ((Entity)npc).Center.X;
				if (npc.type == 614)
				{
					if (num14 < 0f && (num9 == -1f || num14 > num9))
					{
						num10 = num14;
						num13 = m;
					}
					if (num14 > 0f && (num10 == -1f || num14 < num10))
					{
						num9 = num14;
						num12 = m;
					}
					continue;
				}
				if (num14 < 0f && (num9 == -1f || num14 > num9))
				{
					num9 = num14;
					if (flag15)
					{
						num12 = m;
					}
				}
				if (num14 > 0f && (num10 == -1f || num14 < num10))
				{
					num10 = num14;
					if (flag15)
					{
						num13 = m;
					}
				}
			}
			if (flag13)
			{
				num11 = ((num9 == -1f) ? 1 : ((num10 != -1f) ? Utils.ToDirectionInt(num10 < 0f - num9) : (-1)));
				float num15 = 0f;
				if (num9 != -1f)
				{
					num15 = 0f - num9;
				}
				if (num15 == 0f || (num10 < num15 && num10 > 0f))
				{
					num15 = num10;
				}
				if (npc.ai[0] == 8f)
				{
					if (((Entity)npc).direction == -num11)
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 300 + Main.rand.Next(300);
						npc.ai[2] = 0f;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
				else if (npc.ai[0] != 10f && npc.ai[0] != 12f && npc.ai[0] != 13f && npc.ai[0] != 14f && npc.ai[0] != 15f)
				{
					if (Sets.PrettySafe[npc.type] != -1 && (float)Sets.PrettySafe[npc.type] < num15)
					{
						flag13 = false;
						flag14 = Sets.AttackType[npc.type] > -1;
					}
					else if (npc.ai[0] != 1f)
					{
						int tileX = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
						int tileY = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
						bool currentlyDrowning = ((Entity)npc).wet && !flag9;
						AI_007_TownEntities_GetWalkPrediction(npc, num6, floorX, flag9, currentlyDrowning, tileX, tileY, out keepwalking, out var avoidFalling);
						if (!avoidFalling)
						{
							if (npc.ai[0] == 3f || npc.ai[0] == 4f || npc.ai[0] == 16f || npc.ai[0] == 17f)
							{
								NPC nPC = Main.npc[(int)npc.ai[2]];
								if (((Entity)nPC).active)
								{
									nPC.ai[0] = 1f;
									nPC.ai[1] = 120 + Main.rand.Next(120);
									nPC.ai[2] = 0f;
									nPC.localAI[3] = 0f;
									((Entity)nPC).direction = -num11;
									nPC.netUpdate = true;
								}
							}
							npc.ai[0] = 1f;
							npc.ai[1] = 120 + Main.rand.Next(120);
							npc.ai[2] = 0f;
							npc.localAI[3] = 0f;
							((Entity)npc).direction = -num11;
							npc.netUpdate = true;
						}
					}
					else if (npc.ai[0] == 1f && ((Entity)npc).direction != -num11)
					{
						((Entity)npc).direction = -num11;
						npc.netUpdate = true;
					}
				}
			}
		}
		GameModeData gameModeInfo;
		if (npc.ai[0] == 0f)
		{
			if (npc.localAI[3] > 0f)
			{
				npc.localAI[3] -= 1f;
			}
			int num16 = 120;
			if (npc.type == 638)
			{
				num16 = 60;
			}
			if ((flag7 || flag8) && ((Entity)npc).wet)
			{
				npc.ai[0] = 1f;
				npc.ai[1] = 200 + Main.rand.Next(500, 700);
				npc.ai[2] = 0f;
				npc.localAI[3] = 0f;
				npc.netUpdate = true;
			}
			else if (tryToStayInHouse && !flag3 && !Sets.TownCritter[npc.type])
			{
				if (Main.netMode != 1)
				{
					if (num6 == floorX && num7 == floorY)
					{
						if (((Entity)npc).velocity.X != 0f)
						{
							npc.netUpdate = true;
						}
						if (((Entity)npc).velocity.X > 0.1f)
						{
							((Entity)npc).velocity.X -= 0.1f;
						}
						else if (((Entity)npc).velocity.X < -0.1f)
						{
							((Entity)npc).velocity.X += 0.1f;
						}
						else
						{
							((Entity)npc).velocity.X = 0f;
							AI_007_TryForcingSitting(npc, floorX, floorY);
						}
						if (Sets.IsTownPet[npc.type])
						{
							AI_007_AttemptToPlayIdleAnimationsForPets(npc, num16 * 4);
						}
					}
					else
					{
						if (num6 > floorX)
						{
							((Entity)npc).direction = -1;
						}
						else
						{
							((Entity)npc).direction = 1;
						}
						npc.ai[0] = 1f;
						npc.ai[1] = 200 + Main.rand.Next(200);
						npc.ai[2] = 0f;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
			}
			else
			{
				if (isRodent)
				{
					((Entity)npc).velocity.X *= 0.5f;
				}
				if (((Entity)npc).velocity.X > 0.1f)
				{
					((Entity)npc).velocity.X -= 0.1f;
				}
				else if (((Entity)npc).velocity.X < -0.1f)
				{
					((Entity)npc).velocity.X += 0.1f;
				}
				else
				{
					((Entity)npc).velocity.X = 0f;
				}
				if (Main.netMode != 1)
				{
					if (!flag3 && Sets.IsTownPet[npc.type] && npc.ai[1] >= 100f && npc.ai[1] <= 150f)
					{
						AI_007_AttemptToPlayIdleAnimationsForPets(npc, num16);
					}
					if (npc.ai[1] > 0f)
					{
						npc.ai[1] -= 1f;
					}
					bool flag16 = true;
					int tileX2 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
					int tileY2 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
					bool currentlyDrowning2 = ((Entity)npc).wet && !flag9;
					AI_007_TownEntities_GetWalkPrediction(npc, num6, floorX, flag9, currentlyDrowning2, tileX2, tileY2, out keepwalking, out var avoidFalling2);
					if (((Entity)npc).wet && !flag9 && Collision.DrownCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 1f, true))
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 200 + Main.rand.Next(300);
						npc.ai[2] = 0f;
						if (Sets.TownCritter[npc.type])
						{
							npc.ai[1] += Main.rand.Next(200, 400);
						}
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
					if (avoidFalling2)
					{
						flag16 = false;
					}
					if (npc.ai[1] <= 0f)
					{
						if (flag16 && !avoidFalling2)
						{
							npc.ai[0] = 1f;
							npc.ai[1] = 200 + Main.rand.Next(300);
							npc.ai[2] = 0f;
							if (Sets.TownCritter[npc.type])
							{
								npc.ai[1] += Main.rand.Next(200, 400);
							}
							npc.localAI[3] = 0f;
							npc.netUpdate = true;
						}
						else
						{
							((Entity)npc).direction = ((Entity)npc).direction * -1;
							npc.ai[1] = 60 + Main.rand.Next(120);
							npc.netUpdate = true;
						}
					}
				}
			}
			if (Main.netMode != 1 && (!tryToStayInHouse || AI_007_TownEntities_IsInAGoodRestingSpot(npc, num6, num7, floorX, floorY)))
			{
				if (num6 < floorX - 25 || num6 > floorX + 25)
				{
					if (npc.localAI[3] == 0f)
					{
						if (num6 < floorX - 50 && ((Entity)npc).direction == -1)
						{
							((Entity)npc).direction = 1;
							npc.netUpdate = true;
						}
						else if (num6 > floorX + 50 && ((Entity)npc).direction == 1)
						{
							((Entity)npc).direction = -1;
							npc.netUpdate = true;
						}
					}
				}
				else if (Utils.NextBool(Main.rand, 80) && npc.localAI[3] == 0f)
				{
					npc.localAI[3] = 200f;
					((Entity)npc).direction = ((Entity)npc).direction * -1;
					npc.netUpdate = true;
				}
			}
		}
		else if (npc.ai[0] == 1f)
		{
			if (Main.netMode != 1 && tryToStayInHouse && AI_007_TownEntities_IsInAGoodRestingSpot(npc, num6, num7, floorX, floorY) && !Sets.TownCritter[npc.type])
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 200 + Main.rand.Next(200);
				npc.localAI[3] = 60f;
				npc.netUpdate = true;
			}
			else
			{
				bool flag17 = !flag9 && Collision.DrownCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 1f, true);
				if (!flag17)
				{
					if (Main.netMode != 1 && !npc.homeless)
					{
						bool[] tileDungeon2 = Main.tileDungeon;
						val4 = ((Tilemap)(ref Main.tile))[num6, num7];
						if (!tileDungeon2[((Tile)(ref val4)).TileType] && (num6 < floorX - 35 || num6 > floorX + 35))
						{
							if (((Entity)npc).position.X < (float)(floorX * 16) && ((Entity)npc).direction == -1)
							{
								npc.ai[1] -= 5f;
							}
							else if (((Entity)npc).position.X > (float)(floorX * 16) && ((Entity)npc).direction == 1)
							{
								npc.ai[1] -= 5f;
							}
						}
					}
					npc.ai[1] -= 1f;
				}
				if (npc.ai[1] <= 0f)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 300 + Main.rand.Next(300);
					npc.ai[2] = 0f;
					if (Sets.TownCritter[npc.type])
					{
						npc.ai[1] -= Main.rand.Next(100);
					}
					else
					{
						npc.ai[1] += Main.rand.Next(900);
					}
					npc.localAI[3] = 60f;
					npc.netUpdate = true;
				}
				if (npc.closeDoor && ((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f > (float)(npc.doorX + 2) || (((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f < (float)(npc.doorX - 2)))
				{
					Tile tileSafely = Framing.GetTileSafely(npc.doorX, npc.doorY);
					if (TileLoader.CloseDoorID(tileSafely) >= 0)
					{
						if (WorldGen.CloseDoor(npc.doorX, npc.doorY, false))
						{
							npc.closeDoor = false;
							NetMessage.SendData(19, -1, -1, (NetworkText)null, 1, (float)npc.doorX, (float)npc.doorY, (float)((Entity)npc).direction, 0, 0, 0);
						}
						if ((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f > (float)(npc.doorX + 4) || (((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f < (float)(npc.doorX - 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f > (float)(npc.doorY + 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f < (float)(npc.doorY - 4))
						{
							npc.closeDoor = false;
						}
					}
					else if (((Tile)(ref tileSafely)).TileType == 389)
					{
						if (WorldGen.ShiftTallGate(npc.doorX, npc.doorY, true, false))
						{
							npc.closeDoor = false;
							NetMessage.SendData(19, -1, -1, (NetworkText)null, 5, (float)npc.doorX, (float)npc.doorY, 0f, 0, 0, 0);
						}
						if ((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f > (float)(npc.doorX + 4) || (((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f < (float)(npc.doorX - 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f > (float)(npc.doorY + 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f < (float)(npc.doorY - 4))
						{
							npc.closeDoor = false;
						}
					}
					else
					{
						npc.closeDoor = false;
					}
				}
				float num17 = 1f;
				float num18 = 0.07f;
				if (npc.type == 614 && flag13)
				{
					num17 = 1.5f;
					num18 = 0.1f;
				}
				else if (npc.type == 299 || npc.type == 539 || npc.type == 538 || (npc.type >= 639 && npc.type <= 645))
				{
					num17 = 1.5f;
				}
				else if (canBreatheUnderwater)
				{
					if (((Entity)npc).wet)
					{
						num18 = 1f;
						num17 = 2f;
					}
					else
					{
						num18 = 0.07f;
						num17 = 0.5f;
					}
				}
				if (npc.type == 625)
				{
					if (((Entity)npc).wet)
					{
						num18 = 1f;
						num17 = 2.5f;
					}
					else
					{
						num18 = 0.07f;
						num17 = 0.2f;
					}
				}
				if (isRodent)
				{
					num17 = 2f;
					num18 = 1f;
				}
				if (npc.friendly && (flag13 || flag17))
				{
					num17 = 1.5f;
					float num19 = 1f - (float)npc.life / (float)npc.lifeMax;
					num17 += num19 * 0.9f;
					num18 = 0.1f;
				}
				if (flag11 && ((Entity)npc).wet)
				{
					num17 = 2f;
					num18 = 0.2f;
				}
				if (flag7 && ((Entity)npc).wet)
				{
					if (Math.Abs(((Entity)npc).velocity.X) < 0.05f && Math.Abs(((Entity)npc).velocity.Y) < 0.05f)
					{
						((Entity)npc).velocity.X += num17 * 10f * (float)((Entity)npc).direction;
					}
					else
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
				}
				else if (((Entity)npc).velocity.X < 0f - num17 || ((Entity)npc).velocity.X > num17)
				{
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
					}
				}
				else if (((Entity)npc).velocity.X < num17 && ((Entity)npc).direction == 1)
				{
					((Entity)npc).velocity.X += num18;
					if (((Entity)npc).velocity.X > num17)
					{
						((Entity)npc).velocity.X = num17;
					}
				}
				else if (((Entity)npc).velocity.X > 0f - num17 && ((Entity)npc).direction == -1)
				{
					((Entity)npc).velocity.X -= num18;
					if (((Entity)npc).velocity.X > num17)
					{
						((Entity)npc).velocity.X = num17;
					}
				}
				bool flag18 = true;
				if ((float)(npc.homeTileY * 16 - 32) > ((Entity)npc).position.Y)
				{
					flag18 = false;
				}
				if (!flag18 && ((Entity)npc).velocity.Y == 0f)
				{
					Collision.StepDown(ref ((Entity)npc).position, ref ((Entity)npc).velocity, ((Entity)npc).width, ((Entity)npc).height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false);
				}
				if (((Entity)npc).velocity.Y >= 0f)
				{
					Collision.StepUp(ref ((Entity)npc).position, ref ((Entity)npc).velocity, ((Entity)npc).width, ((Entity)npc).height, ref npc.stepSpeed, ref npc.gfxOffY, 1, flag18, 1);
				}
				if (((Entity)npc).velocity.Y == 0f)
				{
					int num20 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
					int num21 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
					int num22 = 180;
					AI_007_TownEntities_GetWalkPrediction(npc, num6, floorX, flag9, flag17, num20, num21, out var keepwalking3, out var avoidFalling3);
					bool flag19 = false;
					bool flag20 = false;
					if (((Entity)npc).wet && !flag9 && npc.townNPC && (flag20 = flag17) && npc.localAI[3] <= 0f)
					{
						avoidFalling3 = true;
						npc.localAI[3] = num22;
						int num23 = 0;
						for (int n = 0; n <= 10; n++)
						{
							val4 = Framing.GetTileSafely(num20 - ((Entity)npc).direction, num21 - n);
							if (((Tile)(ref val4)).LiquidAmount == 0)
							{
								break;
							}
							num23++;
						}
						float num24 = 0.3f;
						float num25 = (float)Math.Sqrt((float)(num23 * 16 + 16) * 2f * num24);
						if (num25 > 26f)
						{
							num25 = 26f;
						}
						((Entity)npc).velocity.Y = 0f - num25;
						npc.localAI[3] = ((Entity)npc).position.X;
						flag19 = true;
					}
					if (avoidFalling3 && !flag19)
					{
						int num26 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f);
						int num27 = 0;
						for (int num28 = -1; num28 <= 1; num28++)
						{
							Tile tileSafely2 = Framing.GetTileSafely(num26 + num28, num21 + 1);
							if (((Tile)(ref tileSafely2)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely2)).TileType])
							{
								num27++;
							}
						}
						if (num27 <= 2)
						{
							if (((Entity)npc).velocity.X != 0f)
							{
								npc.netUpdate = true;
							}
							keepwalking3 = (avoidFalling3 = false);
							npc.ai[0] = 0f;
							npc.ai[1] = 50 + Main.rand.Next(50);
							npc.ai[2] = 0f;
							npc.localAI[3] = 40f;
						}
					}
					if (((Entity)npc).position.X == npc.localAI[3] && !flag19)
					{
						((Entity)npc).direction = ((Entity)npc).direction * -1;
						npc.netUpdate = true;
						npc.localAI[3] = num22;
					}
					if (flag17 && !flag19)
					{
						if (npc.localAI[3] > (float)num22)
						{
							npc.localAI[3] = num22;
						}
						if (npc.localAI[3] > 0f)
						{
							npc.localAI[3] -= 1f;
						}
					}
					else
					{
						npc.localAI[3] = -1f;
					}
					Tile tileSafely3 = Framing.GetTileSafely(num20, num21);
					Tile tileSafely4 = Framing.GetTileSafely(num20, num21 - 1);
					Tile tileSafely5 = Framing.GetTileSafely(num20, num21 - 2);
					bool flag21 = ((Entity)npc).height / 16 < 3;
					if ((npc.townNPC || Sets.AllowDoorInteraction[npc.type]) && ((Tile)(ref tileSafely5)).HasUnactuatedTile && (TileLoader.IsClosedDoor(tileSafely5) || ((Tile)(ref tileSafely5)).TileType == 388) && (Utils.NextBool(Main.rand, 10) || tryToStayInHouse))
					{
						if (Main.netMode != 1)
						{
							if (WorldGen.OpenDoor(num20, num21 - 2, ((Entity)npc).direction))
							{
								npc.closeDoor = true;
								npc.doorX = num20;
								npc.doorY = num21 - 2;
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 0, (float)num20, (float)(num21 - 2), (float)((Entity)npc).direction, 0, 0, 0);
								npc.netUpdate = true;
								npc.ai[1] += 80f;
							}
							else if (WorldGen.OpenDoor(num20, num21 - 2, -((Entity)npc).direction))
							{
								npc.closeDoor = true;
								npc.doorX = num20;
								npc.doorY = num21 - 2;
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 0, (float)num20, (float)(num21 - 2), (float)(-((Entity)npc).direction), 0, 0, 0);
								npc.netUpdate = true;
								npc.ai[1] += 80f;
							}
							else if (WorldGen.ShiftTallGate(num20, num21 - 2, false, false))
							{
								npc.closeDoor = true;
								npc.doorX = num20;
								npc.doorY = num21 - 2;
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 4, (float)num20, (float)(num21 - 2), 0f, 0, 0, 0);
								npc.netUpdate = true;
								npc.ai[1] += 80f;
							}
							else
							{
								((Entity)npc).direction = ((Entity)npc).direction * -1;
								npc.netUpdate = true;
							}
						}
					}
					else
					{
						if ((((Entity)npc).velocity.X < 0f && ((Entity)npc).direction == -1) || (((Entity)npc).velocity.X > 0f && ((Entity)npc).direction == 1))
						{
							bool flag22 = false;
							bool flag23 = false;
							if (((Tile)(ref tileSafely5)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely5)).TileType] && !Main.tileSolidTop[((Tile)(ref tileSafely5)).TileType] && (!flag21 || (((Tile)(ref tileSafely4)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely4)).TileType] && !Main.tileSolidTop[((Tile)(ref tileSafely4)).TileType])))
							{
								if (!Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20 - ((Entity)npc).direction, num21 - 5, num21 - 1) && !Collision.SolidTiles(num20, num20, num21 - 5, num21 - 3))
								{
									((Entity)npc).velocity.Y = -6f;
									npc.netUpdate = true;
								}
								else if (isRodent)
								{
									if (WorldGen.SolidTile((int)(((Entity)npc).Center.X / 16f) + ((Entity)npc).direction, (int)(((Entity)npc).Center.Y / 16f), false))
									{
										((Entity)npc).direction = ((Entity)npc).direction * -1;
										((Entity)npc).velocity.X *= 0f;
										npc.netUpdate = true;
									}
								}
								else if (flag13)
								{
									flag23 = true;
									flag22 = true;
								}
								else if (!flag20)
								{
									flag22 = true;
								}
							}
							else if (((Tile)(ref tileSafely4)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely4)).TileType] && !Main.tileSolidTop[((Tile)(ref tileSafely4)).TileType])
							{
								if (!Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20 - ((Entity)npc).direction, num21 - 4, num21 - 1) && !Collision.SolidTiles(num20, num20, num21 - 4, num21 - 2))
								{
									((Entity)npc).velocity.Y = -5f;
									npc.netUpdate = true;
								}
								else if (flag13)
								{
									flag23 = true;
									flag22 = true;
								}
								else
								{
									flag22 = true;
								}
							}
							else if (((Entity)npc).position.Y + (float)((Entity)npc).height - (float)(num21 * 16) > 20f && ((Tile)(ref tileSafely3)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely3)).TileType] && !((Tile)(ref tileSafely3)).TopSlope)
							{
								if (!Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20, num21 - 3, num21 - 1))
								{
									((Entity)npc).velocity.Y = -4.4f;
									npc.netUpdate = true;
								}
								else if (flag13)
								{
									flag23 = true;
									flag22 = true;
								}
								else
								{
									flag22 = true;
								}
							}
							else if (avoidFalling3)
							{
								if (!flag20)
								{
									flag22 = true;
								}
								if (flag13)
								{
									flag23 = true;
								}
							}
							else if (flag12 && !Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20 - ((Entity)npc).direction, num21 - 2, num21 - 1))
							{
								((Entity)npc).velocity.Y = -5f;
								npc.netUpdate = true;
							}
							if (flag23)
							{
								keepwalking3 = false;
								((Entity)npc).velocity.X = 0f;
								npc.ai[0] = 8f;
								npc.ai[1] = 240f;
								npc.netUpdate = true;
							}
							if (flag22)
							{
								((Entity)npc).direction = ((Entity)npc).direction * -1;
								((Entity)npc).velocity.X *= -1f;
								npc.netUpdate = true;
							}
							if (keepwalking3)
							{
								npc.ai[1] = 90f;
								npc.netUpdate = true;
							}
							if (((Entity)npc).velocity.Y < 0f)
							{
								npc.localAI[3] = ((Entity)npc).position.X;
							}
						}
						if (((Entity)npc).velocity.Y < 0f && ((Entity)npc).wet)
						{
							((Entity)npc).velocity.Y *= 1.2f;
						}
						if (((Entity)npc).velocity.Y < 0f && Sets.TownCritter[npc.type] && !isRodent)
						{
							((Entity)npc).velocity.Y *= 1.2f;
						}
					}
				}
				else if (flag12 && !((Entity)npc).wet)
				{
					int num29 = (int)(((Entity)npc).Center.X / 16f);
					int num30 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
					int num31 = 0;
					for (int num32 = -1; num32 <= 1; num32++)
					{
						for (int num33 = 1; num33 <= 6; num33++)
						{
							Tile tileSafely6 = Framing.GetTileSafely(num29 + num32, num30 + num33);
							if (((Tile)(ref tileSafely6)).LiquidAmount > 0 || (((Tile)(ref tileSafely6)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely6)).TileType]))
							{
								num31++;
							}
						}
					}
					if (num31 <= 2)
					{
						if (((Entity)npc).velocity.X != 0f)
						{
							npc.netUpdate = true;
						}
						((Entity)npc).velocity.X *= 0.2f;
						npc.ai[0] = 0f;
						npc.ai[1] = 50 + Main.rand.Next(50);
						npc.ai[2] = 0f;
						npc.localAI[3] = 40f;
					}
				}
			}
		}
		else if (npc.ai[0] == 2f || npc.ai[0] == 11f)
		{
			if (Main.netMode != 1)
			{
				npc.localAI[3] -= 1f;
				if (Utils.NextBool(Main.rand, 60) && npc.localAI[3] == 0f)
				{
					npc.localAI[3] = 60f;
					((Entity)npc).direction = ((Entity)npc).direction * -1;
					npc.netUpdate = true;
				}
			}
			npc.ai[1] -= 1f;
			((Entity)npc).velocity.X *= 0.8f;
			if (npc.ai[1] <= 0f)
			{
				npc.localAI[3] = 40f;
				npc.ai[0] = 0f;
				npc.ai[1] = 60 + Main.rand.Next(60);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 3f || npc.ai[0] == 4f || npc.ai[0] == 5f || npc.ai[0] == 8f || npc.ai[0] == 9f || npc.ai[0] == 16f || npc.ai[0] == 17f || npc.ai[0] == 20f || npc.ai[0] == 21f || npc.ai[0] == 22f || npc.ai[0] == 23f)
		{
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			if (npc.ai[0] == 8f && npc.ai[1] < 60f && flag13)
			{
				npc.ai[1] = 180f;
				npc.netUpdate = true;
			}
			if (npc.ai[0] == 5f)
			{
				Point coords = Utils.ToTileCoordinates(((Entity)npc).Bottom + Vector2.UnitY * -2f);
				Tile tile = ((Tilemap)(ref Main.tile))[coords.X, coords.Y];
				if (!Sets.CanBeSatOnForNPCs[((Tile)(ref tile)).TileType])
				{
					npc.ai[1] = 0f;
				}
				else
				{
					Main.sittingManager.AddNPC(((Entity)npc).whoAmI, coords);
				}
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 60 + Main.rand.Next(60);
				npc.ai[2] = 0f;
				npc.localAI[3] = 30 + Main.rand.Next(60);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 6f || npc.ai[0] == 7f || npc.ai[0] == 18f || npc.ai[0] == 19f)
		{
			if (npc.ai[0] == 18f && (npc.localAI[3] < 1f || npc.localAI[3] > 2f))
			{
				npc.localAI[3] = 2f;
			}
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			int num34 = (int)npc.ai[2];
			if (num34 < 0 || num34 > 255 || !Main.player[num34].CanBeTalkedTo || ((Entity)Main.player[num34]).Distance(((Entity)npc).Center) > 200f || !Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)Main.player[num34]).Top, 0, 0))
			{
				npc.ai[1] = 0f;
			}
			if (npc.ai[1] > 0f)
			{
				int num35 = ((((Entity)npc).Center.X < ((Entity)Main.player[num34]).Center.X) ? 1 : (-1));
				if (num35 != ((Entity)npc).direction)
				{
					npc.netUpdate = true;
				}
				((Entity)npc).direction = num35;
			}
			else
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 60 + Main.rand.Next(60);
				npc.ai[2] = 0f;
				npc.localAI[3] = 30 + Main.rand.Next(60);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 10f)
		{
			int attackProjectileType = 0;
			int attackBaseDamage = 0;
			float attackKnockback = 0f;
			float attackProjectileSpeedMult = 0f;
			int attackProjectileDelay = 0;
			int attackCooldown = 0;
			int attackRandomExtraCooldown = 0;
			float attackProjectileGravityCorrection = 0f;
			float num42 = Sets.DangerDetectRange[npc.type];
			float attackProjectileRandomOffset = 0f;
			if ((float)Sets.AttackTime[npc.type] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
				npc.localAI[3] = 0f;
			}
			if (npc.type == 38)
			{
				attackProjectileType = 30;
				attackProjectileSpeedMult = 6f;
				attackBaseDamage = 20;
				attackProjectileDelay = 10;
				attackCooldown = 180;
				attackRandomExtraCooldown = 120;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 7f;
			}
			else if (npc.type == 633)
			{
				attackProjectileType = 880;
				attackProjectileSpeedMult = 24f;
				attackBaseDamage = 15;
				attackProjectileDelay = 1;
				attackProjectileGravityCorrection = 0f;
				attackKnockback = 7f;
				attackCooldown = 15;
				attackRandomExtraCooldown = 10;
				if (npc.ShouldBestiaryGirlBeLycantrope())
				{
					attackProjectileType = 929;
					attackBaseDamage = (int)((float)attackBaseDamage * 1.5f);
				}
			}
			else if (npc.type == 550)
			{
				attackProjectileType = 669;
				attackProjectileSpeedMult = 6f;
				attackBaseDamage = 24;
				attackProjectileDelay = 10;
				attackCooldown = 120;
				attackRandomExtraCooldown = 60;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 9f;
			}
			else if (npc.type == 588)
			{
				attackProjectileType = 721;
				attackProjectileSpeedMult = 8f;
				attackBaseDamage = 15;
				attackProjectileDelay = 5;
				attackCooldown = 20;
				attackRandomExtraCooldown = 10;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 9f;
			}
			else if (npc.type == 208)
			{
				attackProjectileType = 588;
				attackProjectileSpeedMult = 6f;
				attackBaseDamage = 30;
				attackProjectileDelay = 10;
				attackCooldown = 60;
				attackRandomExtraCooldown = 120;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 6f;
			}
			else if (npc.type == 17)
			{
				attackProjectileType = 48;
				attackProjectileSpeedMult = 9f;
				attackBaseDamage = 12;
				attackProjectileDelay = 10;
				attackCooldown = 60;
				attackRandomExtraCooldown = 60;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 1.5f;
			}
			else if (npc.type == 369)
			{
				attackProjectileType = 520;
				attackProjectileSpeedMult = 12f;
				attackBaseDamage = 10;
				attackProjectileDelay = 10;
				attackCooldown = 0;
				attackRandomExtraCooldown = 1;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 3f;
			}
			else if (npc.type == 453)
			{
				attackProjectileType = 21;
				attackProjectileSpeedMult = 14f;
				attackBaseDamage = 14;
				attackProjectileDelay = 10;
				attackCooldown = 0;
				attackRandomExtraCooldown = 1;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 3f;
			}
			else if (npc.type == 107)
			{
				attackProjectileType = 24;
				attackProjectileSpeedMult = 5f;
				attackBaseDamage = 15;
				attackProjectileDelay = 10;
				attackCooldown = 60;
				attackRandomExtraCooldown = 60;
				attackProjectileGravityCorrection = 16f;
				attackKnockback = 1f;
			}
			else if (npc.type == 124)
			{
				attackProjectileType = 582;
				attackProjectileSpeedMult = 10f;
				attackBaseDamage = 11;
				attackProjectileDelay = 1;
				attackCooldown = 30;
				attackRandomExtraCooldown = 30;
				attackKnockback = 3.5f;
			}
			else if (npc.type == 18)
			{
				attackProjectileType = 583;
				attackProjectileSpeedMult = 8f;
				attackBaseDamage = 8;
				attackProjectileDelay = 1;
				attackCooldown = 15;
				attackRandomExtraCooldown = 10;
				attackKnockback = 2f;
				attackProjectileGravityCorrection = 10f;
			}
			else if (npc.type == 142)
			{
				attackProjectileType = 589;
				attackProjectileSpeedMult = 7f;
				attackBaseDamage = 22;
				attackProjectileDelay = 1;
				attackCooldown = 10;
				attackRandomExtraCooldown = 1;
				attackKnockback = 2f;
				attackProjectileGravityCorrection = 10f;
			}
			NPCLoader.TownNPCAttackStrength(npc, ref attackBaseDamage, ref attackKnockback);
			NPCLoader.TownNPCAttackCooldown(npc, ref attackCooldown, ref attackRandomExtraCooldown);
			NPCLoader.TownNPCAttackProj(npc, ref attackProjectileType, ref attackProjectileDelay);
			NPCLoader.TownNPCAttackProjSpeed(npc, ref attackProjectileSpeedMult, ref attackProjectileGravityCorrection, ref attackProjectileRandomOffset);
			if (Main.expertMode)
			{
				float num43 = attackBaseDamage;
				gameModeInfo = Main.GameModeInfo;
				attackBaseDamage = (int)(num43 * ((GameModeData)(ref gameModeInfo)).TownNPCDamageMultiplier);
			}
			attackBaseDamage = (int)((float)attackBaseDamage * damageMult);
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			if (npc.localAI[3] == (float)attackProjectileDelay && Main.netMode != 1)
			{
				Vector2 vec = -Vector2.UnitY;
				if (num11 == 1 && npc.spriteDirection == 1 && num13 != -1)
				{
					vec = ((Entity)npc).DirectionTo(((Entity)Main.npc[num13]).Center + new Vector2(0f, (0f - attackProjectileGravityCorrection) * MathHelper.Clamp(((Entity)npc).Distance(((Entity)Main.npc[num13]).Center) / num42, 0f, 1f)));
				}
				if (num11 == -1 && npc.spriteDirection == -1 && num12 != -1)
				{
					vec = ((Entity)npc).DirectionTo(((Entity)Main.npc[num12]).Center + new Vector2(0f, (0f - attackProjectileGravityCorrection) * MathHelper.Clamp(((Entity)npc).Distance(((Entity)Main.npc[num12]).Center) / num42, 0f, 1f)));
				}
				if (Utils.HasNaNs(vec) || Math.Sign(vec.X) != npc.spriteDirection)
				{
					((Vector2)(ref vec))._002Ector((float)npc.spriteDirection, -1f);
				}
				vec *= attackProjectileSpeedMult;
				vec += Utils.RandomVector2(Main.rand, 0f - attackProjectileRandomOffset, attackProjectileRandomOffset);
				int num44 = 1000;
				num44 = npc.type switch
				{
					124 => Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, vec.X, vec.Y, attackProjectileType, attackBaseDamage, attackKnockback, Main.myPlayer, 0f, (float)((Entity)npc).whoAmI, (float)npc.townNpcVariationIndex), 
					142 => Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, vec.X, vec.Y, attackProjectileType, attackBaseDamage, attackKnockback, Main.myPlayer, 0f, (float)Main.rand.Next(5), 0f), 
					_ => Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, vec.X, vec.Y, attackProjectileType, attackBaseDamage, attackKnockback, Main.myPlayer, 0f, 0f, 0f), 
				};
				Main.projectile[num44].npcProj = true;
				Main.projectile[num44].noDropItem = true;
				if (npc.type == 588)
				{
					Main.projectile[num44].timeLeft = 480;
				}
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = ((npc.localAI[2] == 8f && flag13) ? 8 : 0);
				npc.ai[1] = attackCooldown + Main.rand.Next(attackRandomExtraCooldown);
				npc.ai[2] = 0f;
				npc.localAI[1] = (npc.localAI[3] = attackCooldown / 2 + Main.rand.Next(attackRandomExtraCooldown));
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 12f)
		{
			int attackProjectileType2 = 0;
			int attackBaseDamage2 = 0;
			float attackProjectileSpeedMultiplier = 0f;
			int attackProjectileDelay2 = 0;
			int attackCooldown2 = 0;
			int attackRandomExtraCooldown2 = 0;
			float attackKnockback2 = 0f;
			float attackProjectileGravityCorrection2 = 0f;
			bool attackIsInBetweenShots = false;
			float attackProjectileRandomOffset2 = 0f;
			if ((float)Sets.AttackTime[npc.type] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
				npc.localAI[3] = 0f;
			}
			int num52 = -1;
			if (num11 == 1 && npc.spriteDirection == 1)
			{
				num52 = num13;
			}
			if (num11 == -1 && npc.spriteDirection == -1)
			{
				num52 = num12;
			}
			if (npc.type == 19)
			{
				attackProjectileType2 = 14;
				attackProjectileSpeedMultiplier = 13f;
				attackBaseDamage2 = 24;
				attackCooldown2 = 14;
				attackRandomExtraCooldown2 = 4;
				attackKnockback2 = 3f;
				attackProjectileDelay2 = 1;
				attackProjectileRandomOffset2 = 0.5f;
				if ((float)Sets.AttackTime[npc.type] == npc.ai[1])
				{
					npc.frameCounter = 0.0;
					npc.localAI[3] = 0f;
				}
				if (Main.hardMode)
				{
					attackBaseDamage2 = 15;
					if (npc.localAI[3] > (float)attackProjectileDelay2)
					{
						attackProjectileDelay2 = 10;
						attackIsInBetweenShots = true;
					}
					if (npc.localAI[3] > (float)attackProjectileDelay2)
					{
						attackProjectileDelay2 = 20;
						attackIsInBetweenShots = true;
					}
					if (npc.localAI[3] > (float)attackProjectileDelay2)
					{
						attackProjectileDelay2 = 30;
						attackIsInBetweenShots = true;
					}
				}
			}
			else if (npc.type == 227)
			{
				attackProjectileType2 = 587;
				attackProjectileSpeedMultiplier = 10f;
				attackBaseDamage2 = 8;
				attackCooldown2 = 10;
				attackRandomExtraCooldown2 = 1;
				attackKnockback2 = 1.75f;
				attackProjectileDelay2 = 1;
				attackProjectileRandomOffset2 = 0.5f;
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 12;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 24;
					attackIsInBetweenShots = true;
				}
				if (Main.hardMode)
				{
					attackBaseDamage2 += 2;
				}
			}
			else if (npc.type == 368)
			{
				attackProjectileType2 = 14;
				attackProjectileSpeedMultiplier = 13f;
				attackBaseDamage2 = 24;
				attackCooldown2 = 12;
				attackRandomExtraCooldown2 = 5;
				attackKnockback2 = 2f;
				attackProjectileDelay2 = 1;
				attackProjectileRandomOffset2 = 0.2f;
				if (Main.hardMode)
				{
					attackBaseDamage2 = 30;
					attackProjectileType2 = 357;
				}
			}
			else if (npc.type == 22)
			{
				attackProjectileSpeedMultiplier = 10f;
				attackBaseDamage2 = 8;
				attackProjectileDelay2 = 1;
				if (Main.hardMode)
				{
					attackProjectileType2 = 2;
					attackCooldown2 = 15;
					attackRandomExtraCooldown2 = 10;
					attackBaseDamage2 += 6;
				}
				else
				{
					attackProjectileType2 = 1;
					attackCooldown2 = 30;
					attackRandomExtraCooldown2 = 20;
				}
				attackKnockback2 = 2.75f;
				attackProjectileGravityCorrection2 = 4f;
				attackProjectileRandomOffset2 = 0.7f;
			}
			else if (npc.type == 228)
			{
				attackProjectileType2 = 267;
				attackProjectileSpeedMultiplier = 14f;
				attackBaseDamage2 = 20;
				attackProjectileDelay2 = 1;
				attackCooldown2 = 10;
				attackRandomExtraCooldown2 = 1;
				attackKnockback2 = 3f;
				attackProjectileGravityCorrection2 = 6f;
				attackProjectileRandomOffset2 = 0.4f;
			}
			else if (npc.type == 178)
			{
				attackProjectileType2 = 242;
				attackProjectileSpeedMultiplier = 13f;
				attackBaseDamage2 = ((!Main.hardMode) ? 11 : 15);
				attackCooldown2 = 10;
				attackRandomExtraCooldown2 = 1;
				attackKnockback2 = 2f;
				attackProjectileDelay2 = 1;
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 8;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 16;
					attackIsInBetweenShots = true;
				}
				attackProjectileRandomOffset2 = 0.3f;
			}
			else if (npc.type == 229)
			{
				attackProjectileType2 = 14;
				attackProjectileSpeedMultiplier = 14f;
				attackBaseDamage2 = 24;
				attackCooldown2 = 10;
				attackRandomExtraCooldown2 = 1;
				attackKnockback2 = 2f;
				attackProjectileDelay2 = 1;
				attackProjectileRandomOffset2 = 0.7f;
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 16;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 24;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 32;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 40;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] > (float)attackProjectileDelay2)
				{
					attackProjectileDelay2 = 48;
					attackIsInBetweenShots = true;
				}
				if (npc.localAI[3] == 0f && num52 != -1 && ((Entity)npc).Distance(((Entity)Main.npc[num52]).Center) < (float)Sets.PrettySafe[npc.type])
				{
					attackProjectileRandomOffset2 = 0.1f;
					attackProjectileType2 = 162;
					attackBaseDamage2 = 50;
					attackKnockback2 = 10f;
					attackProjectileSpeedMultiplier = 24f;
				}
			}
			else if (npc.type == 209)
			{
				attackProjectileType2 = Utils.SelectRandom<int>(Main.rand, new int[3] { 134, 133, 135 });
				attackProjectileDelay2 = 1;
				switch (attackProjectileType2)
				{
				case 135:
					attackProjectileSpeedMultiplier = 12f;
					attackBaseDamage2 = 30;
					attackCooldown2 = 30;
					attackRandomExtraCooldown2 = 10;
					attackKnockback2 = 7f;
					attackProjectileRandomOffset2 = 0.2f;
					break;
				case 133:
					attackProjectileSpeedMultiplier = 10f;
					attackBaseDamage2 = 25;
					attackCooldown2 = 10;
					attackRandomExtraCooldown2 = 1;
					attackKnockback2 = 6f;
					attackProjectileRandomOffset2 = 0.2f;
					break;
				case 134:
					attackProjectileSpeedMultiplier = 13f;
					attackBaseDamage2 = 20;
					attackCooldown2 = 20;
					attackRandomExtraCooldown2 = 10;
					attackKnockback2 = 4f;
					attackProjectileRandomOffset2 = 0.1f;
					break;
				}
			}
			NPCLoader.TownNPCAttackStrength(npc, ref attackBaseDamage2, ref attackKnockback2);
			NPCLoader.TownNPCAttackCooldown(npc, ref attackCooldown2, ref attackRandomExtraCooldown2);
			NPCLoader.TownNPCAttackProj(npc, ref attackProjectileType2, ref attackProjectileDelay2);
			NPCLoader.TownNPCAttackProjSpeed(npc, ref attackProjectileSpeedMultiplier, ref attackProjectileGravityCorrection2, ref attackProjectileRandomOffset2);
			NPCLoader.TownNPCAttackShoot(npc, ref attackIsInBetweenShots);
			if (Main.expertMode)
			{
				float num53 = attackBaseDamage2;
				gameModeInfo = Main.GameModeInfo;
				attackBaseDamage2 = (int)(num53 * ((GameModeData)(ref gameModeInfo)).TownNPCDamageMultiplier);
			}
			attackBaseDamage2 = (int)((float)attackBaseDamage2 * damageMult);
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			if (npc.localAI[3] == (float)attackProjectileDelay2 && Main.netMode != 1)
			{
				Vector2 attackProjectileSpeed = Vector2.Zero;
				if (num52 != -1)
				{
					attackProjectileSpeed = ((Entity)npc).DirectionTo(((Entity)Main.npc[num52]).Center + new Vector2(0f, 0f - attackProjectileGravityCorrection2));
				}
				if (Utils.HasNaNs(attackProjectileSpeed) || Math.Sign(attackProjectileSpeed.X) != npc.spriteDirection)
				{
					((Vector2)(ref attackProjectileSpeed))._002Ector((float)npc.spriteDirection, 0f);
				}
				attackProjectileSpeed *= attackProjectileSpeedMultiplier;
				attackProjectileSpeed += Utils.RandomVector2(Main.rand, 0f - attackProjectileRandomOffset2, attackProjectileRandomOffset2);
				int num54 = 1000;
				int num55 = ((npc.type != 227) ? Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, attackProjectileSpeed.X, attackProjectileSpeed.Y, attackProjectileType2, attackBaseDamage2, attackKnockback2, Main.myPlayer, 0f, 0f, 0f) : Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, attackProjectileSpeed.X, attackProjectileSpeed.Y, attackProjectileType2, attackBaseDamage2, attackKnockback2, Main.myPlayer, 0f, (float)Main.rand.Next(12) / 6f, 0f));
				num54 = num55;
				Main.projectile[num54].npcProj = true;
				Main.projectile[num54].noDropItem = true;
			}
			if (npc.localAI[3] == (float)attackProjectileDelay2 && attackIsInBetweenShots && num52 != -1)
			{
				Vector2 vector2 = ((Entity)npc).DirectionTo(((Entity)Main.npc[num52]).Center);
				if (vector2.Y <= 0.5f && vector2.Y >= -0.5f)
				{
					npc.ai[2] = vector2.Y;
				}
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = ((npc.localAI[2] == 8f && flag13) ? 8 : 0);
				npc.ai[1] = attackCooldown2 + Main.rand.Next(attackRandomExtraCooldown2);
				npc.ai[2] = 0f;
				npc.localAI[1] = (npc.localAI[3] = attackCooldown2 / 2 + Main.rand.Next(attackRandomExtraCooldown2));
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 13f)
		{
			((Entity)npc).velocity.X *= 0.8f;
			if ((float)Sets.AttackTime[npc.type] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
			}
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			if (npc.localAI[3] == 1f && Main.netMode != 1)
			{
				Vector2 vec3 = ((Entity)npc).DirectionTo(((Entity)Main.npc[(int)npc.ai[2]]).Center + new Vector2(0f, -20f));
				if (Utils.HasNaNs(vec3) || Math.Sign(vec3.X) == -npc.spriteDirection)
				{
					((Vector2)(ref vec3))._002Ector((float)npc.spriteDirection, -1f);
				}
				vec3 *= 8f;
				int num56 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, vec3.X, vec3.Y, 584, 0, 0f, Main.myPlayer, npc.ai[2], 0f, 0f);
				Main.projectile[num56].npcProj = true;
				Main.projectile[num56].noDropItem = true;
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 10 + Main.rand.Next(10);
				npc.ai[2] = 0f;
				npc.localAI[3] = 5 + Main.rand.Next(10);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 14f)
		{
			int attackProjectileType3 = 0;
			int attackBaseDamage3 = 0;
			float attackProjectileSpeedMultiplier2 = 0f;
			int num57 = 0;
			int attackBaseCooldown = 0;
			int attackRandomExtraCooldown3 = 0;
			float attackKnockback3 = 0f;
			float attackProjectileGravityCorrection3 = 0f;
			float num61 = Sets.DangerDetectRange[npc.type];
			float attackMagicAuraLightMultiplier = 1f;
			float attackProjectileRandomOffset3 = 0f;
			if ((float)Sets.AttackTime[npc.type] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
				npc.localAI[3] = 0f;
			}
			int num64 = -1;
			if (num11 == 1 && npc.spriteDirection == 1)
			{
				num64 = num13;
			}
			if (num11 == -1 && npc.spriteDirection == -1)
			{
				num64 = num12;
			}
			if (npc.type == 54)
			{
				attackProjectileType3 = 585;
				attackProjectileSpeedMultiplier2 = 10f;
				attackBaseDamage3 = 16;
				num57 = 30;
				attackBaseCooldown = 20;
				attackRandomExtraCooldown3 = 15;
				attackKnockback3 = 2f;
				attackProjectileRandomOffset3 = 1f;
			}
			else if (npc.type == 108)
			{
				attackProjectileType3 = 15;
				attackProjectileSpeedMultiplier2 = 6f;
				attackBaseDamage3 = 18;
				num57 = 15;
				attackBaseCooldown = 15;
				attackRandomExtraCooldown3 = 5;
				attackKnockback3 = 3f;
				attackProjectileGravityCorrection3 = 20f;
			}
			else if (npc.type == 160)
			{
				attackProjectileType3 = 590;
				attackBaseDamage3 = 40;
				num57 = 15;
				attackBaseCooldown = 10;
				attackRandomExtraCooldown3 = 1;
				attackKnockback3 = 3f;
				for (; npc.localAI[3] > (float)num57; num57 += 15)
				{
				}
			}
			else if (npc.type == 663)
			{
				attackProjectileType3 = 950;
				attackBaseDamage3 = ((!Main.hardMode) ? 15 : 20);
				num57 = 15;
				attackBaseCooldown = 0;
				attackRandomExtraCooldown3 = 0;
				attackKnockback3 = 3f;
				for (; npc.localAI[3] > (float)num57; num57 += 10)
				{
				}
			}
			else if (npc.type == 20)
			{
				attackProjectileType3 = 586;
				num57 = 24;
				attackBaseCooldown = 10;
				attackRandomExtraCooldown3 = 1;
				attackKnockback3 = 3f;
			}
			NPCLoader.TownNPCAttackStrength(npc, ref attackBaseDamage3, ref attackKnockback3);
			NPCLoader.TownNPCAttackCooldown(npc, ref attackBaseCooldown, ref attackRandomExtraCooldown3);
			NPCLoader.TownNPCAttackProj(npc, ref attackProjectileType3, ref num57);
			NPCLoader.TownNPCAttackProjSpeed(npc, ref attackProjectileSpeedMultiplier2, ref attackProjectileGravityCorrection3, ref attackProjectileRandomOffset3);
			NPCLoader.TownNPCAttackMagic(npc, ref attackMagicAuraLightMultiplier);
			if (Main.expertMode)
			{
				float num65 = attackBaseDamage3;
				gameModeInfo = Main.GameModeInfo;
				attackBaseDamage3 = (int)(num65 * ((GameModeData)(ref gameModeInfo)).TownNPCDamageMultiplier);
			}
			attackBaseDamage3 = (int)((float)attackBaseDamage3 * damageMult);
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			if (npc.localAI[3] == (float)num57 && Main.netMode != 1)
			{
				Vector2 attackProjectileSpeed2 = Vector2.Zero;
				if (num64 != -1)
				{
					attackProjectileSpeed2 = ((Entity)npc).DirectionTo(((Entity)Main.npc[num64]).Center + new Vector2(0f, (0f - attackProjectileGravityCorrection3) * MathHelper.Clamp(((Entity)npc).Distance(((Entity)Main.npc[num64]).Center) / num61, 0f, 1f)));
				}
				if (Utils.HasNaNs(attackProjectileSpeed2) || Math.Sign(attackProjectileSpeed2.X) != npc.spriteDirection)
				{
					((Vector2)(ref attackProjectileSpeed2))._002Ector((float)npc.spriteDirection, 0f);
				}
				attackProjectileSpeed2 *= attackProjectileSpeedMultiplier2;
				attackProjectileSpeed2 += Utils.RandomVector2(Main.rand, 0f - attackProjectileRandomOffset3, attackProjectileRandomOffset3);
				if (npc.type == 108)
				{
					int num66 = Utils.SelectRandom<int>(Main.rand, new int[7] { 1, 1, 1, 1, 2, 2, 3 });
					for (int num67 = 0; num67 < num66; num67++)
					{
						Vector2 vector3 = Utils.RandomVector2(Main.rand, -3.4f, 3.4f);
						int num68 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, attackProjectileSpeed2.X + vector3.X, attackProjectileSpeed2.Y + vector3.Y, attackProjectileType3, attackBaseDamage3, attackKnockback3, Main.myPlayer, 0f, 0f, (float)npc.townNpcVariationIndex);
						Main.projectile[num68].npcProj = true;
						Main.projectile[num68].noDropItem = true;
					}
				}
				else if (npc.type == 160)
				{
					if (num64 != -1)
					{
						Vector2 vector4 = ((Entity)Main.npc[num64]).position - ((Entity)Main.npc[num64]).Size * 2f + ((Entity)Main.npc[num64]).Size * Utils.RandomVector2(Main.rand, 0f, 1f) * 5f;
						int num69 = 10;
						while (num69 > 0 && WorldGen.SolidTile(Framing.GetTileSafely((int)vector4.X / 16, (int)vector4.Y / 16)))
						{
							num69--;
							vector4 = ((Entity)Main.npc[num64]).position - ((Entity)Main.npc[num64]).Size * 2f + ((Entity)Main.npc[num64]).Size * Utils.RandomVector2(Main.rand, 0f, 1f) * 5f;
						}
						int num70 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector4.X, vector4.Y, 0f, 0f, attackProjectileType3, attackBaseDamage3, attackKnockback3, Main.myPlayer, 0f, 0f, (float)npc.townNpcVariationIndex);
						Main.projectile[num70].npcProj = true;
						Main.projectile[num70].noDropItem = true;
					}
				}
				else if (npc.type == 663)
				{
					if (num64 != -1)
					{
						Vector2 vector5 = ((Entity)Main.npc[num64]).position + ((Entity)Main.npc[num64]).Size * Utils.RandomVector2(Main.rand, 0f, 1f) * 1f;
						int num71 = 5;
						while (num71 > 0 && WorldGen.SolidTile(Framing.GetTileSafely((int)vector5.X / 16, (int)vector5.Y / 16)))
						{
							num71--;
							vector5 = ((Entity)Main.npc[num64]).position + ((Entity)Main.npc[num64]).Size * Utils.RandomVector2(Main.rand, 0f, 1f) * 1f;
						}
						int num72 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector5.X, vector5.Y, 0f, 0f, attackProjectileType3, attackBaseDamage3, attackKnockback3, Main.myPlayer, 0f, 0f, (float)npc.townNpcVariationIndex);
						Main.projectile[num72].npcProj = true;
						Main.projectile[num72].noDropItem = true;
					}
				}
				else if (npc.type == 20)
				{
					int num73 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, attackProjectileSpeed2.X, attackProjectileSpeed2.Y, attackProjectileType3, attackBaseDamage3, attackKnockback3, Main.myPlayer, 0f, (float)((Entity)npc).whoAmI, (float)npc.townNpcVariationIndex);
					Main.projectile[num73].npcProj = true;
					Main.projectile[num73].noDropItem = true;
				}
				else
				{
					int num74 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, attackProjectileSpeed2.X, attackProjectileSpeed2.Y, attackProjectileType3, attackBaseDamage3, attackKnockback3, Main.myPlayer, 0f, 0f, 0f);
					Main.projectile[num74].npcProj = true;
					Main.projectile[num74].noDropItem = true;
				}
			}
			if (attackMagicAuraLightMultiplier > 0f)
			{
				val = npc.GetMagicAuraColor();
				Vector3 vector6 = ((Color)(ref val)).ToVector3() * attackMagicAuraLightMultiplier;
				Lighting.AddLight(((Entity)npc).Center, vector6.X, vector6.Y, vector6.Z);
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = ((npc.localAI[2] == 8f && flag13) ? 8 : 0);
				npc.ai[1] = attackBaseCooldown + Main.rand.Next(attackRandomExtraCooldown3);
				npc.ai[2] = 0f;
				npc.localAI[1] = (npc.localAI[3] = attackBaseCooldown / 2 + Main.rand.Next(attackRandomExtraCooldown3));
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 15f)
		{
			int attackBaseCooldown2 = 0;
			int attackRandomExtraCooldown4 = 0;
			if ((float)Sets.AttackTime[npc.type] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
				npc.localAI[3] = 0f;
			}
			int attackBaseDamage4 = 0;
			float attackKnockback4 = 0f;
			int attackItemWidth = 0;
			int attackItemHeight = 0;
			if (num11 == 1)
			{
				_ = npc.spriteDirection;
			}
			if (num11 == -1)
			{
				_ = npc.spriteDirection;
			}
			if (npc.type == 207)
			{
				attackBaseDamage4 = 11;
				attackItemWidth = (attackItemHeight = 32);
				attackBaseCooldown2 = 12;
				attackRandomExtraCooldown4 = 6;
				attackKnockback4 = 4.25f;
			}
			else if (npc.type == 441)
			{
				attackBaseDamage4 = 9;
				attackItemWidth = (attackItemHeight = 28);
				attackBaseCooldown2 = 9;
				attackRandomExtraCooldown4 = 3;
				attackKnockback4 = 3.5f;
				if (npc.GivenName == "Andrew")
				{
					attackBaseDamage4 *= 2;
					attackKnockback4 *= 2f;
				}
			}
			else if (npc.type == 353)
			{
				attackBaseDamage4 = 10;
				attackItemWidth = (attackItemHeight = 32);
				attackBaseCooldown2 = 15;
				attackRandomExtraCooldown4 = 8;
				attackKnockback4 = 5f;
			}
			else if (Sets.IsTownPet[npc.type])
			{
				attackBaseDamage4 = 10;
				attackItemWidth = (attackItemHeight = 32);
				attackBaseCooldown2 = 15;
				attackRandomExtraCooldown4 = 8;
				attackKnockback4 = 3f;
			}
			NPCLoader.TownNPCAttackStrength(npc, ref attackBaseDamage4, ref attackKnockback4);
			NPCLoader.TownNPCAttackCooldown(npc, ref attackBaseCooldown2, ref attackRandomExtraCooldown4);
			NPCLoader.TownNPCAttackSwing(npc, ref attackItemWidth, ref attackItemHeight);
			if (Main.expertMode)
			{
				float num75 = attackBaseDamage4;
				gameModeInfo = Main.GameModeInfo;
				attackBaseDamage4 = (int)(num75 * ((GameModeData)(ref gameModeInfo)).TownNPCDamageMultiplier);
			}
			attackBaseDamage4 = (int)((float)attackBaseDamage4 * damageMult);
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			if (Main.netMode != 1)
			{
				Tuple<Vector2, float> swingStats = npc.GetSwingStats(Sets.AttackTime[npc.type] * 2, (int)npc.ai[1], npc.spriteDirection, attackItemWidth, attackItemHeight);
				Rectangle itemRectangle = default(Rectangle);
				((Rectangle)(ref itemRectangle))._002Ector((int)swingStats.Item1.X, (int)swingStats.Item1.Y, attackItemWidth, attackItemHeight);
				if (npc.spriteDirection == -1)
				{
					itemRectangle.X -= attackItemWidth;
				}
				itemRectangle.Y -= attackItemHeight;
				npc.TweakSwingStats(Sets.AttackTime[npc.type] * 2, (int)npc.ai[1], npc.spriteDirection, ref itemRectangle);
				int myPlayer = Main.myPlayer;
				for (int num76 = 0; num76 < 200; num76++)
				{
					NPC nPC2 = Main.npc[num76];
					if (((Entity)nPC2).active && nPC2.immune[myPlayer] == 0 && !nPC2.dontTakeDamage && !nPC2.friendly && nPC2.damage > 0 && ((Rectangle)(ref itemRectangle)).Intersects(((Entity)nPC2).Hitbox) && (nPC2.noTileCollide || Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)nPC2).position, ((Entity)nPC2).width, ((Entity)nPC2).height)))
					{
						nPC2.SimpleStrikeNPC(attackBaseDamage4, npc.spriteDirection, false, attackKnockback4, (DamageClass)null, false, 0f, false);
						if (Main.netMode != 0)
						{
							NetMessage.SendData(28, -1, -1, (NetworkText)null, num76, (float)attackBaseDamage4, attackKnockback4, (float)npc.spriteDirection, 0, 0, 0);
						}
						nPC2.netUpdate = true;
						nPC2.immune[myPlayer] = (int)npc.ai[1] + 2;
					}
				}
			}
			if (npc.ai[1] <= 0f)
			{
				bool flag25 = false;
				if (flag13)
				{
					int num80 = -num11;
					if (!Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)npc).Center + Vector2.UnitX * (float)num80 * 32f, 0, 0) || npc.localAI[2] == 8f)
					{
						flag25 = true;
					}
					if (flag25)
					{
						int num81 = Sets.AttackTime[npc.type];
						int num82 = ((num11 == 1) ? num13 : num12);
						int num83 = ((num11 == 1) ? num12 : num13);
						if (num82 != -1 && !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num82]).Center, 0, 0))
						{
							num82 = ((num83 == -1 || !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num83]).Center, 0, 0)) ? (-1) : num83);
						}
						if (num82 != -1)
						{
							npc.ai[0] = 15f;
							npc.ai[1] = num81;
							npc.ai[2] = 0f;
							npc.localAI[3] = 0f;
							((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num82]).position.X) ? 1 : (-1));
							npc.netUpdate = true;
						}
						else
						{
							flag25 = false;
						}
					}
				}
				if (!flag25)
				{
					npc.ai[0] = ((npc.localAI[2] == 8f && flag13) ? 8 : 0);
					npc.ai[1] = attackBaseCooldown2 + Main.rand.Next(attackRandomExtraCooldown4);
					npc.ai[2] = 0f;
					npc.localAI[1] = (npc.localAI[3] = attackBaseCooldown2 / 2 + Main.rand.Next(attackRandomExtraCooldown4));
					npc.netUpdate = true;
				}
			}
		}
		else if (npc.ai[0] == 24f)
		{
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			((Entity)npc).direction = 1;
			npc.spriteDirection = 1;
			val = npc.GetMagicAuraColor();
			Vector3 vector7 = ((Color)(ref val)).ToVector3();
			Lighting.AddLight(((Entity)npc).Center, vector7.X, vector7.Y, vector7.Z);
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 480f;
				npc.ai[2] = 0f;
				npc.localAI[1] = 480f;
				npc.netUpdate = true;
			}
		}
		if (flag11 && ((Entity)npc).wet)
		{
			int num84 = (int)(((Entity)npc).Center.X / 16f);
			int num85 = 5;
			if (npc.collideX || (num84 < num85 && ((Entity)npc).direction == -1) || (num84 > Main.maxTilesX - num85 && ((Entity)npc).direction == 1))
			{
				((Entity)npc).direction = ((Entity)npc).direction * -1;
				((Entity)npc).velocity.X *= -0.25f;
				npc.netUpdate = true;
			}
			((Entity)npc).velocity.Y *= 0.9f;
			((Entity)npc).velocity.Y -= 0.5f;
			if (((Entity)npc).velocity.Y < -15f)
			{
				((Entity)npc).velocity.Y = -15f;
			}
		}
		if (flag10 && ((Entity)npc).wet)
		{
			if (flag7)
			{
				npc.ai[1] = 50f;
			}
			int num86 = (int)(((Entity)npc).Center.X / 16f);
			int num87 = 5;
			if (npc.collideX || (num86 < num87 && ((Entity)npc).direction == -1) || (num86 > Main.maxTilesX - num87 && ((Entity)npc).direction == 1))
			{
				((Entity)npc).direction = ((Entity)npc).direction * -1;
				((Entity)npc).velocity.X *= -0.25f;
				npc.netUpdate = true;
			}
			float waterLineHeight = default(float);
			if (Collision.GetWaterLine(Utils.ToTileCoordinates(((Entity)npc).Center), ref waterLineHeight))
			{
				float num88 = ((Entity)npc).Center.Y + 1f;
				if (((Entity)npc).Center.Y > waterLineHeight)
				{
					((Entity)npc).velocity.Y -= 0.8f;
					if (((Entity)npc).velocity.Y < -4f)
					{
						((Entity)npc).velocity.Y = -4f;
					}
					if (num88 + ((Entity)npc).velocity.Y < waterLineHeight)
					{
						((Entity)npc).velocity.Y = waterLineHeight - num88;
					}
				}
				else
				{
					((Entity)npc).velocity.Y = MathHelper.Min(((Entity)npc).velocity.Y, waterLineHeight - num88);
				}
			}
			else
			{
				((Entity)npc).velocity.Y -= 0.2f;
			}
		}
		if (Main.netMode != 1 && npc.isLikeATownNPC && !flag3)
		{
			bool flag26 = npc.ai[0] < 2f && !flag13 && !((Entity)npc).wet;
			bool flag27 = (npc.ai[0] < 2f || npc.ai[0] == 8f) && (flag13 || flag14);
			if (npc.localAI[1] > 0f)
			{
				npc.localAI[1] -= 1f;
			}
			if (npc.localAI[1] > 0f)
			{
				flag27 = false;
			}
			if (flag27 && npc.type == 124 && npc.localAI[0] == 1f)
			{
				flag27 = false;
			}
			if (flag27 && npc.type == 20)
			{
				flag27 = false;
				for (int num89 = 0; num89 < 200; num89++)
				{
					NPC nPC3 = Main.npc[num89];
					if (((Entity)nPC3).active && nPC3.townNPC && !(((Entity)npc).Distance(((Entity)nPC3).Center) > 1200f) && nPC3.FindBuffIndex(165) == -1)
					{
						flag27 = true;
						break;
					}
				}
			}
			if (npc.CanTalk && flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 300))
			{
				int num90 = 420;
				num90 = ((!Utils.NextBool(Main.rand, 2)) ? (num90 * Main.rand.Next(1, 3)) : (num90 * Main.rand.Next(1, 4)));
				int num91 = 100;
				int num92 = 20;
				for (int num93 = 0; num93 < 200; num93++)
				{
					NPC nPC4 = Main.npc[num93];
					bool flag28 = (nPC4.ai[0] == 1f && nPC4.closeDoor) || (nPC4.ai[0] == 1f && nPC4.ai[1] > 200f) || nPC4.ai[0] > 1f || ((Entity)nPC4).wet;
					if (nPC4 != npc && ((Entity)nPC4).active && nPC4.CanBeTalkedTo && !flag28 && ((Entity)nPC4).Distance(((Entity)npc).Center) < (float)num91 && ((Entity)nPC4).Distance(((Entity)npc).Center) > (float)num92 && Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)nPC4).Center, 0, 0))
					{
						int num94 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)nPC4).position.X);
						npc.ai[0] = 3f;
						npc.ai[1] = num90;
						npc.ai[2] = num93;
						((Entity)npc).direction = num94;
						npc.netUpdate = true;
						nPC4.ai[0] = 4f;
						nPC4.ai[1] = num90;
						nPC4.ai[2] = ((Entity)npc).whoAmI;
						((Entity)nPC4).direction = -num94;
						nPC4.netUpdate = true;
						break;
					}
				}
			}
			else if (npc.CanTalk && flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1800))
			{
				int num95 = 420;
				num95 = ((!Utils.NextBool(Main.rand, 2)) ? (num95 * Main.rand.Next(1, 3)) : (num95 * Main.rand.Next(1, 4)));
				int num96 = 100;
				int num97 = 20;
				for (int num98 = 0; num98 < 200; num98++)
				{
					NPC nPC5 = Main.npc[num98];
					bool flag29 = (nPC5.ai[0] == 1f && nPC5.closeDoor) || (nPC5.ai[0] == 1f && nPC5.ai[1] > 200f) || nPC5.ai[0] > 1f || ((Entity)nPC5).wet;
					if (nPC5 != npc && ((Entity)nPC5).active && nPC5.CanBeTalkedTo && !Sets.IsTownPet[nPC5.type] && !flag29 && ((Entity)nPC5).Distance(((Entity)npc).Center) < (float)num96 && ((Entity)nPC5).Distance(((Entity)npc).Center) > (float)num97 && Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)nPC5).Center, 0, 0))
					{
						int num99 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)nPC5).position.X);
						npc.ai[0] = 16f;
						npc.ai[1] = num95;
						npc.ai[2] = num98;
						npc.localAI[2] = Main.rand.Next(4);
						npc.localAI[3] = Main.rand.Next(3 - (int)npc.localAI[2]);
						((Entity)npc).direction = num99;
						npc.netUpdate = true;
						nPC5.ai[0] = 17f;
						nPC5.ai[1] = num95;
						nPC5.ai[2] = ((Entity)npc).whoAmI;
						nPC5.localAI[2] = 0f;
						nPC5.localAI[3] = 0f;
						((Entity)nPC5).direction = -num99;
						nPC5.netUpdate = true;
						break;
					}
				}
			}
			else if (!Sets.IsTownPet[npc.type] && flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1200) && (npc.type == 208 || (BirthdayParty.PartyIsUp && Sets.AttackType[npc.type] == Sets.AttackType[208])))
			{
				int num100 = 300;
				int num101 = 150;
				for (int num102 = 0; num102 < 255; num102++)
				{
					Player player = Main.player[num102];
					if (((Entity)player).active && !player.dead && ((Entity)player).Distance(((Entity)npc).Center) < (float)num101 && Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)player).Top, 0, 0))
					{
						int num103 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)player).position.X);
						npc.ai[0] = 6f;
						npc.ai[1] = num100;
						npc.ai[2] = num102;
						((Entity)npc).direction = num103;
						npc.netUpdate = true;
						break;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 600) && npc.type == 550)
			{
				int num104 = 300;
				int num105 = 150;
				for (int num106 = 0; num106 < 255; num106++)
				{
					Player player2 = Main.player[num106];
					if (((Entity)player2).active && !player2.dead && ((Entity)player2).Distance(((Entity)npc).Center) < (float)num105 && Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)player2).Top, 0, 0))
					{
						int num107 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)player2).position.X);
						npc.ai[0] = 18f;
						npc.ai[1] = num104;
						npc.ai[2] = num106;
						((Entity)npc).direction = num107;
						npc.netUpdate = true;
						break;
					}
				}
			}
			else if (!Sets.IsTownPet[npc.type] && flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1800))
			{
				npc.ai[0] = 2f;
				npc.ai[1] = 45 * Main.rand.Next(1, 2);
				npc.netUpdate = true;
			}
			else if (flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 600) && npc.type == 229 && !flag14)
			{
				npc.ai[0] = 11f;
				npc.ai[1] = 30 * Main.rand.Next(1, 4);
				npc.netUpdate = true;
			}
			else if (flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1200))
			{
				int num108 = 220;
				int num109 = 150;
				for (int num110 = 0; num110 < 255; num110++)
				{
					Player player3 = Main.player[num110];
					if (player3.CanBeTalkedTo && ((Entity)player3).Distance(((Entity)npc).Center) < (float)num109 && Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)player3).Top, 0, 0))
					{
						int num111 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)player3).position.X);
						npc.ai[0] = 7f;
						npc.ai[1] = num108;
						npc.ai[2] = num110;
						((Entity)npc).direction = num111;
						npc.netUpdate = true;
						break;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 1f && ((Entity)npc).velocity.Y == 0f && num > 0 && Utils.NextBool(Main.rand, num))
			{
				Point point = Utils.ToTileCoordinates(((Entity)npc).Bottom + Vector2.UnitY * -2f);
				bool flag30 = WorldGen.InWorld(point.X, point.Y, 1);
				if (flag30)
				{
					for (int num112 = 0; num112 < 200; num112++)
					{
						if (((Entity)Main.npc[num112]).active && Main.npc[num112].aiStyle == 7 && Main.npc[num112].townNPC && Main.npc[num112].ai[0] == 5f && Utils.ToTileCoordinates(((Entity)Main.npc[num112]).Bottom + Vector2.UnitY * -2f) == point)
						{
							flag30 = false;
							break;
						}
					}
					for (int num113 = 0; num113 < 255; num113++)
					{
						if (((Entity)Main.player[num113]).active && Main.player[num113].sitting.isSitting && Utils.ToTileCoordinates(((Entity)Main.player[num113]).Center) == point)
						{
							flag30 = false;
							break;
						}
					}
				}
				if (flag30)
				{
					Tile tile2 = ((Tilemap)(ref Main.tile))[point.X, point.Y];
					flag30 = Sets.CanBeSatOnForNPCs[((Tile)(ref tile2)).TileType];
					if (flag30 && ((Tile)(ref tile2)).TileType == 15 && ((Tile)(ref tile2)).TileFrameY >= 1080 && ((Tile)(ref tile2)).TileFrameY <= 1098)
					{
						flag30 = false;
					}
					if (flag30)
					{
						npc.ai[0] = 5f;
						npc.ai[1] = 900 + Main.rand.Next(10800);
						int targetDirection = default(int);
						Vector2 bottom = default(Vector2);
						npc.SitDown(point, ref targetDirection, ref bottom);
						((Entity)npc).direction = targetDirection;
						((Entity)npc).Bottom = bottom;
						((Entity)npc).velocity = Vector2.Zero;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 1f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 600))
			{
				Vector2 top = ((Entity)npc).Top;
				Vector2 bottom2 = ((Entity)npc).Bottom;
				float num114 = ((Entity)npc).width;
				object obj = _003C_003EO._003C0_003E__SearchAvoidedByNPCs;
				if (obj == null)
				{
					TileActionAttempt val6 = DelegateMethods.SearchAvoidedByNPCs;
					_003C_003EO._003C0_003E__SearchAvoidedByNPCs = val6;
					obj = (object)val6;
				}
				if (Utils.PlotTileLine(top, bottom2, num114, (TileActionAttempt)obj))
				{
					Point point2 = Utils.ToTileCoordinates(((Entity)npc).Center + new Vector2((float)(((Entity)npc).direction * 10), 0f));
					bool flag31 = WorldGen.InWorld(point2.X, point2.Y, 1);
					if (flag31)
					{
						Tile tileSafely7 = Framing.GetTileSafely(point2.X, point2.Y);
						if (!((Tile)(ref tileSafely7)).HasUnactuatedTile || !Sets.InteractibleByNPCs[((Tile)(ref tileSafely7)).TileType])
						{
							flag31 = false;
						}
					}
					if (flag31)
					{
						npc.ai[0] = 9f;
						npc.ai[1] = 40 + Main.rand.Next(90);
						((Entity)npc).velocity = Vector2.Zero;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
			}
			if (Main.netMode != 1 && npc.ai[0] < 2f && ((Entity)npc).velocity.Y == 0f && npc.type == 18 && npc.breath > 0)
			{
				int num115 = -1;
				for (int num116 = 0; num116 < 200; num116++)
				{
					NPC nPC6 = Main.npc[num116];
					if (((Entity)nPC6).active && nPC6.townNPC && nPC6.life != nPC6.lifeMax && (num115 == -1 || nPC6.lifeMax - nPC6.life > Main.npc[num115].lifeMax - Main.npc[num115].life) && Collision.CanHitLine(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)nPC6).position, ((Entity)nPC6).width, ((Entity)nPC6).height) && ((Entity)npc).Distance(((Entity)nPC6).Center) < 500f)
					{
						num115 = num116;
					}
				}
				if (num115 != -1)
				{
					npc.ai[0] = 13f;
					npc.ai[1] = 34f;
					npc.ai[2] = num115;
					npc.localAI[3] = 0f;
					((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num115]).position.X) ? 1 : (-1));
					npc.netUpdate = true;
				}
			}
			if (flag27 && ((Entity)npc).velocity.Y == 0f && Sets.AttackType[npc.type] == 0 && Sets.AttackAverageChance[npc.type] > 0 && Utils.NextBool(Main.rand, Sets.AttackAverageChance[npc.type] * 2))
			{
				int num117 = Sets.AttackTime[npc.type];
				int num118 = ((num11 == 1) ? num13 : num12);
				int num119 = ((num11 == 1) ? num12 : num13);
				if (num118 != -1 && !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num118]).Center, 0, 0))
				{
					num118 = ((num119 == -1 || !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num119]).Center, 0, 0)) ? (-1) : num119);
				}
				bool flag32 = num118 != -1;
				if (flag32 && npc.type == 633)
				{
					flag32 = Vector2.Distance(((Entity)npc).Center, ((Entity)Main.npc[num118]).Center) <= 50f;
				}
				if (flag32)
				{
					npc.localAI[2] = npc.ai[0];
					npc.ai[0] = 10f;
					npc.ai[1] = num117;
					npc.ai[2] = 0f;
					npc.localAI[3] = 0f;
					((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num118]).position.X) ? 1 : (-1));
					npc.netUpdate = true;
				}
			}
			else if (flag27 && ((Entity)npc).velocity.Y == 0f && Sets.AttackType[npc.type] == 1 && Sets.AttackAverageChance[npc.type] > 0 && Utils.NextBool(Main.rand, Sets.AttackAverageChance[npc.type] * 2))
			{
				int num120 = Sets.AttackTime[npc.type];
				int num121 = ((num11 == 1) ? num13 : num12);
				int num122 = ((num11 == 1) ? num12 : num13);
				if (num121 != -1 && !Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num121]).Center, 0, 0))
				{
					num121 = ((num122 == -1 || !Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num122]).Center, 0, 0)) ? (-1) : num122);
				}
				if (num121 != -1)
				{
					Vector2 vector8 = ((Entity)npc).DirectionTo(((Entity)Main.npc[num121]).Center);
					if (vector8.Y <= 0.5f && vector8.Y >= -0.5f)
					{
						npc.localAI[2] = npc.ai[0];
						npc.ai[0] = 12f;
						npc.ai[1] = num120;
						npc.ai[2] = vector8.Y;
						npc.localAI[3] = 0f;
						((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num121]).position.X) ? 1 : (-1));
						npc.netUpdate = true;
					}
				}
			}
			if (flag27 && ((Entity)npc).velocity.Y == 0f && Sets.AttackType[npc.type] == 2 && Sets.AttackAverageChance[npc.type] > 0 && Utils.NextBool(Main.rand, Sets.AttackAverageChance[npc.type] * 2))
			{
				int num123 = Sets.AttackTime[npc.type];
				int num124 = ((num11 == 1) ? num13 : num12);
				int num125 = ((num11 == 1) ? num12 : num13);
				if (num124 != -1 && !Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num124]).Center, 0, 0))
				{
					num124 = ((num125 == -1 || !Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num125]).Center, 0, 0)) ? (-1) : num125);
				}
				if (num124 != -1)
				{
					npc.localAI[2] = npc.ai[0];
					npc.ai[0] = 14f;
					npc.ai[1] = num123;
					npc.ai[2] = 0f;
					npc.localAI[3] = 0f;
					((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num124]).position.X) ? 1 : (-1));
					npc.netUpdate = true;
				}
				else if (npc.type == 20)
				{
					npc.localAI[2] = npc.ai[0];
					npc.ai[0] = 14f;
					npc.ai[1] = num123;
					npc.ai[2] = 0f;
					npc.localAI[3] = 0f;
					npc.netUpdate = true;
				}
			}
			if (flag27 && ((Entity)npc).velocity.Y == 0f && Sets.AttackType[npc.type] == 3 && Sets.AttackAverageChance[npc.type] > 0 && Utils.NextBool(Main.rand, Sets.AttackAverageChance[npc.type] * 2))
			{
				int num126 = Sets.AttackTime[npc.type];
				int num127 = ((num11 == 1) ? num13 : num12);
				int num128 = ((num11 == 1) ? num12 : num13);
				if (num127 != -1 && !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num127]).Center, 0, 0))
				{
					num127 = ((num128 == -1 || !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num128]).Center, 0, 0)) ? (-1) : num128);
				}
				if (num127 != -1)
				{
					npc.localAI[2] = npc.ai[0];
					npc.ai[0] = 15f;
					npc.ai[1] = num126;
					npc.ai[2] = 0f;
					npc.localAI[3] = 0f;
					((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num127]).position.X) ? 1 : (-1));
					npc.netUpdate = true;
				}
			}
		}
		if (npc.type == 681)
		{
			float R = 0f;
			float G = 0f;
			float B = 0f;
			TorchID.TorchColor(23, ref R, ref G, ref B);
			float num129 = 0.35f;
			R *= num129;
			G *= num129;
			B *= num129;
			Lighting.AddLight(((Entity)npc).Center, R, G, B);
		}
		if (npc.type == 683 || npc.type == 687)
		{
			float num130 = Utils.WrappedLerp(0.75f, 1f, (float)Main.timeForVisualEffects % 120f / 120f);
			Lighting.AddLight(((Entity)npc).Center, 0.25f * num130, 0.25f * num130, 0.1f * num130);
		}
	}

	public static void AI_007_TownEntities_Shimmer_TeleportToLandingSpot(NPC npc)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		Vector2? vector = AI_007_TownEntities_Shimmer_ScanForBestSpotToLandOn(npc);
		if (vector.HasValue)
		{
			Vector2 vector2 = ((Entity)npc).position;
			((Entity)npc).position = vector.Value;
			Vector2 movementVector = ((Entity)npc).position - vector2;
			int num = 560;
			if (((Vector2)(ref movementVector)).Length() >= (float)num)
			{
				npc.ai[2] = 30f;
				ParticleOrchestrator.BroadcastParticleSpawn((ParticleOrchestraType)32, new ParticleOrchestraSettings
				{
					PositionInWorld = vector2 + ((Entity)npc).Size / 2f,
					MovementVector = movementVector
				});
			}
			npc.netUpdate = true;
		}
	}

	public static Vector2? AI_007_TownEntities_Shimmer_ScanForBestSpotToLandOn(NPC npc)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		Point point = Utils.ToTileCoordinates(((Entity)npc).Top);
		int num = 30;
		Vector2? result = null;
		bool flag = npc.homeless && (npc.homeTileX == -1 || npc.homeTileY == -1);
		for (int i = 1; i < num; i += 2)
		{
			Vector2? vector = ShimmerHelper.FindSpotWithoutShimmer((Entity)(object)npc, point.X, point.Y, i, flag);
			if (vector.HasValue)
			{
				result = vector.Value;
				break;
			}
		}
		if (!result.HasValue && npc.homeTileX != -1 && npc.homeTileY != -1)
		{
			for (int j = 1; j < num; j += 2)
			{
				Vector2? vector2 = ShimmerHelper.FindSpotWithoutShimmer((Entity)(object)npc, npc.homeTileX, npc.homeTileY, j, flag);
				if (vector2.HasValue)
				{
					result = vector2.Value;
					break;
				}
			}
		}
		if (!result.HasValue)
		{
			int num2 = (flag ? 30 : 0);
			num = 60;
			flag = true;
			for (int k = num2; k < num; k += 2)
			{
				Vector2? vector3 = ShimmerHelper.FindSpotWithoutShimmer((Entity)(object)npc, point.X, point.Y, k, flag);
				if (vector3.HasValue)
				{
					result = vector3.Value;
					break;
				}
			}
		}
		if (!result.HasValue && npc.homeTileX != -1 && npc.homeTileY != -1)
		{
			num = 60;
			flag = true;
			for (int l = 30; l < num; l += 2)
			{
				Vector2? vector4 = ShimmerHelper.FindSpotWithoutShimmer((Entity)(object)npc, npc.homeTileX, npc.homeTileY, l, flag);
				if (vector4.HasValue)
				{
					result = vector4.Value;
					break;
				}
			}
		}
		return result;
	}

	public static void AI_007_TownEntities_TeleportToHome(NPC npc, int homeFloorX, int homeFloorY)
	{
		bool flag = false;
		for (int i = 0; i < 3; i++)
		{
			int num2 = homeFloorX + i switch
			{
				1 => -1, 
				0 => 0, 
				_ => 1, 
			};
			if (npc.type == 37 || !Collision.SolidTiles(num2 - 1, num2 + 1, homeFloorY - 3, homeFloorY - 1))
			{
				((Entity)npc).velocity.X = 0f;
				((Entity)npc).velocity.Y = 0f;
				((Entity)npc).position.X = num2 * 16 + 8 - ((Entity)npc).width / 2;
				((Entity)npc).position.Y = (float)(homeFloorY * 16 - ((Entity)npc).height) - 0.1f;
				npc.netUpdate = true;
				AI_007_TryForcingSitting(npc, homeFloorX, homeFloorY);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			npc.homeless = true;
			WorldGen.QuickFindHome(((Entity)npc).whoAmI);
		}
	}

	public static void AI_007_TownEntities_GetWalkPrediction(NPC npc, int myTileX, int homeFloorX, bool canBreathUnderWater, bool currentlyDrowning, int tileX, int tileY, out bool keepwalking, out bool avoidFalling)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		keepwalking = false;
		avoidFalling = true;
		bool flag = myTileX >= homeFloorX - 35 && myTileX <= homeFloorX + 35;
		if (npc.townNPC && npc.ai[1] < 30f)
		{
			Vector2 top = ((Entity)npc).Top;
			Vector2 bottom = ((Entity)npc).Bottom;
			float num = ((Entity)npc).width;
			object obj = _003C_003EO._003C0_003E__SearchAvoidedByNPCs;
			if (obj == null)
			{
				TileActionAttempt val = DelegateMethods.SearchAvoidedByNPCs;
				_003C_003EO._003C0_003E__SearchAvoidedByNPCs = val;
				obj = (object)val;
			}
			keepwalking = !Utils.PlotTileLine(top, bottom, num, (TileActionAttempt)obj);
			if (!keepwalking)
			{
				Rectangle hitbox = ((Entity)npc).Hitbox;
				hitbox.X -= 20;
				hitbox.Width += 40;
				for (int i = 0; i < 200; i++)
				{
					if (((Entity)Main.npc[i]).active && Main.npc[i].friendly && i != ((Entity)npc).whoAmI && ((Entity)Main.npc[i]).velocity.X == 0f && ((Rectangle)(ref hitbox)).Intersects(((Entity)Main.npc[i]).Hitbox))
					{
						keepwalking = true;
						break;
					}
				}
			}
		}
		if (!keepwalking && currentlyDrowning)
		{
			keepwalking = true;
		}
		if (avoidFalling && (Sets.TownCritter[npc.type] || (!flag && ((Entity)npc).direction == Math.Sign(homeFloorX - myTileX))))
		{
			avoidFalling = false;
		}
		if (!avoidFalling)
		{
			return;
		}
		bool flag2 = false;
		Point p = default(Point);
		int num2 = 0;
		for (int j = -1; j <= 4; j++)
		{
			Tile tileSafely = Framing.GetTileSafely(tileX, tileY + j);
			if (((Tile)(ref tileSafely)).LiquidAmount > 0)
			{
				num2++;
				if (((Tile)(ref tileSafely)).LiquidType == 1)
				{
					flag2 = true;
					break;
				}
			}
			if (((Tile)(ref tileSafely)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely)).TileType])
			{
				if (num2 > 0)
				{
					p.X = tileX;
					p.Y = tileY + j;
				}
				avoidFalling = false;
				break;
			}
		}
		avoidFalling |= flag2;
		double num3 = Math.Ceiling((float)((Entity)npc).height / 16f);
		if ((double)num2 >= num3)
		{
			avoidFalling = true;
		}
		if (!avoidFalling && p.X != 0 && p.Y != 0)
		{
			Vector2 vector = Utils.ToWorldCoordinates(p, 8f, 0f) + new Vector2((float)(-((Entity)npc).width / 2), (float)(-((Entity)npc).height));
			avoidFalling = Collision.DrownCollision(vector, ((Entity)npc).width, ((Entity)npc).height, 1f, false);
		}
	}

	public static void AI_007_AttemptToPlayIdleAnimationsForPets(NPC npc, int petIdleChance)
	{
		if (((Entity)npc).velocity.X == 0f && Main.netMode != 1 && Utils.NextBool(Main.rand, petIdleChance))
		{
			int num = 3;
			if (npc.type == 638)
			{
				num = 2;
			}
			if (Sets.IsTownSlime[npc.type])
			{
				num = 0;
			}
			npc.ai[0] = ((num == 0) ? 20 : Main.rand.Next(20, 20 + num));
			npc.ai[1] = 200 + Main.rand.Next(300);
			if (npc.ai[0] == 20f && npc.type == 637)
			{
				npc.ai[1] = 500 + Main.rand.Next(200);
			}
			if (npc.ai[0] == 21f && npc.type == 638)
			{
				npc.ai[1] = 100 + Main.rand.Next(100);
			}
			if (npc.ai[0] == 22f && npc.type == 656)
			{
				npc.ai[1] = 200 + Main.rand.Next(200);
			}
			if (npc.ai[0] == 20f && Sets.IsTownSlime[npc.type])
			{
				npc.ai[1] = 180 + Main.rand.Next(240);
			}
			npc.ai[2] = 0f;
			npc.localAI[3] = 0f;
			npc.netUpdate = true;
		}
	}

	public static bool AI_007_TownEntities_IsInAGoodRestingSpot(NPC npc, int tileX, int tileY, int idealRestX, int idealRestY)
	{
		if (!Main.dayTime && npc.ai[0] == 5f)
		{
			if (Math.Abs(tileX - idealRestX) <= 7)
			{
				return Math.Abs(tileY - idealRestY) <= 7;
			}
			return false;
		}
		if ((npc.type == 361 || npc.type == 445 || npc.type == 687) && ((Entity)npc).wet)
		{
			return false;
		}
		if (tileX == idealRestX)
		{
			return tileY == idealRestY;
		}
		return false;
	}

	public static void AI_007_FindGoodRestingSpot(NPC npc, int myTileX, int myTileY, out int floorX, out int floorY)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		floorX = npc.homeTileX;
		floorY = npc.homeTileY;
		if (floorX == -1 || floorY == -1)
		{
			return;
		}
		while (!WorldGen.SolidOrSlopedTile(floorX, floorY) && floorY < Main.maxTilesY - 20)
		{
			floorY++;
		}
		if (Main.dayTime || (npc.ai[0] == 5f && Math.Abs(myTileX - floorX) < 7 && Math.Abs(myTileY - floorY) < 7))
		{
			return;
		}
		Point point = default(Point);
		((Point)(ref point))._002Ector(floorX, floorY);
		Point point2 = default(Point);
		((Point)(ref point2))._002Ector(-1, -1);
		int num = -1;
		if (npc.type == 638 || npc.type == 656 || Sets.IsTownSlime[npc.type] || npc.ai[0] == 5f)
		{
			return;
		}
		int num2 = 7;
		int num3 = 6;
		int num4 = 1;
		int num5 = 1;
		int num6 = 1;
		for (int i = point.X - num2; i <= point.X + num2; i += num5)
		{
			for (int num7 = point.Y + num4; num7 >= point.Y - num3; num7 -= num6)
			{
				Tile tile = ((Tilemap)(ref Main.tile))[i, num7];
				if (tile != (ArgumentException)null && ((Tile)(ref tile)).HasTile && Sets.CanBeSatOnForNPCs[((Tile)(ref tile)).TileType])
				{
					int num8 = Math.Abs(i - point.X) + Math.Abs(num7 - point.Y);
					if (num == -1 || num8 < num)
					{
						num = num8;
						point2.X = i;
						point2.Y = num7;
					}
				}
			}
		}
		if (num == -1)
		{
			return;
		}
		Tile tile2 = ((Tilemap)(ref Main.tile))[point2.X, point2.Y];
		if (((Tile)(ref tile2)).TileType == 497 || ((Tile)(ref tile2)).TileType == 15)
		{
			if (((Tile)(ref tile2)).TileFrameY % 40 != 0)
			{
				point2.Y--;
			}
			point2.Y += 2;
		}
		else if (((Tile)(ref tile2)).TileType >= TileID.Count)
		{
			TileRestingInfo info = default(TileRestingInfo);
			((TileRestingInfo)(ref info))._002Ector((Entity)(object)npc, point2, Vector2.Zero, ((Entity)npc).direction, 0, default(Vector2), default(ExtraSeatInfo));
			TileLoader.ModifySittingTargetInfo(point2.X, point2.Y, (int)((Tile)(ref tile2)).TileType, ref info);
			point2 = info.AnchorTilePosition;
			point2.Y++;
		}
		for (int j = 0; j < 200; j++)
		{
			if (((Entity)Main.npc[j]).active && Main.npc[j].aiStyle == 7 && Main.npc[j].townNPC && Main.npc[j].ai[0] == 5f && Utils.ToTileCoordinates(((Entity)Main.npc[j]).Bottom + Vector2.UnitY * -2f) == point2)
			{
				return;
			}
		}
		floorX = point2.X;
		floorY = point2.Y;
	}

	public static void AI_007_TryForcingSitting(NPC npc, int homeFloorX, int homeFloorY)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		Tile tile = ((Tilemap)(ref Main.tile))[homeFloorX, homeFloorY - 1];
		bool flag = !Sets.CannotSitOnFurniture[npc.type] && !Sets.IsTownSlime[npc.type] && npc.ai[0] != 5f;
		if (flag)
		{
			flag &= tile != (ArgumentException)null && ((Tile)(ref tile)).HasTile && Sets.CanBeSatOnForNPCs[((Tile)(ref tile)).TileType];
		}
		if (flag)
		{
			flag &= ((Tile)(ref tile)).TileType != 15 || ((Tile)(ref tile)).TileFrameY < 1080 || ((Tile)(ref tile)).TileFrameY > 1098;
		}
		if (flag)
		{
			Point point = Utils.ToTileCoordinates(((Entity)npc).Bottom + Vector2.UnitY * -2f);
			for (int i = 0; i < 200; i++)
			{
				if (((Entity)Main.npc[i]).active && Main.npc[i].aiStyle == 7 && Main.npc[i].townNPC && Main.npc[i].ai[0] == 5f && Utils.ToTileCoordinates(((Entity)Main.npc[i]).Bottom + Vector2.UnitY * -2f) == point)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			npc.ai[0] = 5f;
			npc.ai[1] = 900 + Main.rand.Next(10800);
			int targetDirection = default(int);
			Vector2 bottom = default(Vector2);
			npc.SitDown(new Point(homeFloorX, homeFloorY - 1), ref targetDirection, ref bottom);
			((Entity)npc).direction = targetDirection;
			((Entity)npc).Bottom = bottom;
			((Entity)npc).velocity = Vector2.Zero;
			npc.localAI[3] = 0f;
			npc.netUpdate = true;
		}
	}
}
