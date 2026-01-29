using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.NPCAIReference;

public static class FighterAIReference
{
	public static bool VanillaFighterAI(NPC npc)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0916: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_092b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b42: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1058: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1361: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2797: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17af: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3164: Unknown result type (might be due to invalid IL or missing references)
		//IL_316a: Unknown result type (might be due to invalid IL or missing references)
		//IL_316f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3174: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_28bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_27fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2008: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1736: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_335c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3362: Unknown result type (might be due to invalid IL or missing references)
		//IL_3367: Unknown result type (might be due to invalid IL or missing references)
		//IL_336c: Unknown result type (might be due to invalid IL or missing references)
		//IL_326d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3287: Unknown result type (might be due to invalid IL or missing references)
		//IL_328c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3294: Unknown result type (might be due to invalid IL or missing references)
		//IL_3299: Unknown result type (might be due to invalid IL or missing references)
		//IL_319d: Unknown result type (might be due to invalid IL or missing references)
		//IL_31b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_31bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3004: Unknown result type (might be due to invalid IL or missing references)
		//IL_3015: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_28fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_2090: Unknown result type (might be due to invalid IL or missing references)
		//IL_209b: Unknown result type (might be due to invalid IL or missing references)
		//IL_174b: Unknown result type (might be due to invalid IL or missing references)
		//IL_175e: Unknown result type (might be due to invalid IL or missing references)
		//IL_34d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_34df: Unknown result type (might be due to invalid IL or missing references)
		//IL_34e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_34e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3330: Unknown result type (might be due to invalid IL or missing references)
		//IL_3336: Unknown result type (might be due to invalid IL or missing references)
		//IL_333b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3340: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ee9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f19: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1861: Unknown result type (might be due to invalid IL or missing references)
		//IL_186c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3436: Unknown result type (might be due to invalid IL or missing references)
		//IL_3457: Unknown result type (might be due to invalid IL or missing references)
		//IL_3389: Unknown result type (might be due to invalid IL or missing references)
		//IL_33aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_30d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_30d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_30dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_30e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_30ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_3110: Unknown result type (might be due to invalid IL or missing references)
		//IL_3116: Unknown result type (might be due to invalid IL or missing references)
		//IL_313d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3143: Unknown result type (might be due to invalid IL or missing references)
		//IL_3148: Unknown result type (might be due to invalid IL or missing references)
		//IL_314d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_23fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1997: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_187d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1890: Unknown result type (might be due to invalid IL or missing references)
		//IL_1895: Unknown result type (might be due to invalid IL or missing references)
		//IL_189a: Unknown result type (might be due to invalid IL or missing references)
		//IL_149d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ac0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_348e: Unknown result type (might be due to invalid IL or missing references)
		//IL_34af: Unknown result type (might be due to invalid IL or missing references)
		//IL_34c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_33e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3408: Unknown result type (might be due to invalid IL or missing references)
		//IL_341d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3423: Unknown result type (might be due to invalid IL or missing references)
		//IL_32e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3306: Unknown result type (might be due to invalid IL or missing references)
		//IL_331b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3321: Unknown result type (might be due to invalid IL or missing references)
		//IL_321e: Unknown result type (might be due to invalid IL or missing references)
		//IL_323f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3254: Unknown result type (might be due to invalid IL or missing references)
		//IL_325a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2453: Unknown result type (might be due to invalid IL or missing references)
		//IL_245b: Unknown result type (might be due to invalid IL or missing references)
		//IL_230b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2310: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1901: Unknown result type (might be due to invalid IL or missing references)
		//IL_1906: Unknown result type (might be due to invalid IL or missing references)
		//IL_190d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1923: Unknown result type (might be due to invalid IL or missing references)
		//IL_1929: Unknown result type (might be due to invalid IL or missing references)
		//IL_1937: Unknown result type (might be due to invalid IL or missing references)
		//IL_1939: Unknown result type (might be due to invalid IL or missing references)
		//IL_193d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1942: Unknown result type (might be due to invalid IL or missing references)
		//IL_1947: Unknown result type (might be due to invalid IL or missing references)
		//IL_1954: Unknown result type (might be due to invalid IL or missing references)
		//IL_195b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1960: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14df: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c60: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c79: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_2329: Unknown result type (might be due to invalid IL or missing references)
		//IL_232e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2351: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1515: Unknown result type (might be due to invalid IL or missing references)
		//IL_1526: Unknown result type (might be due to invalid IL or missing references)
		//IL_152b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1530: Unknown result type (might be due to invalid IL or missing references)
		//IL_1532: Unknown result type (might be due to invalid IL or missing references)
		//IL_1534: Unknown result type (might be due to invalid IL or missing references)
		//IL_1539: Unknown result type (might be due to invalid IL or missing references)
		//IL_153e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1540: Unknown result type (might be due to invalid IL or missing references)
		//IL_1544: Unknown result type (might be due to invalid IL or missing references)
		//IL_1549: Unknown result type (might be due to invalid IL or missing references)
		//IL_1552: Unknown result type (might be due to invalid IL or missing references)
		//IL_1559: Unknown result type (might be due to invalid IL or missing references)
		//IL_1560: Unknown result type (might be due to invalid IL or missing references)
		//IL_1567: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_35b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_35bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_35d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_35d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_35dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_35e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_35f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3655: Unknown result type (might be due to invalid IL or missing references)
		//IL_367e: Unknown result type (might be due to invalid IL or missing references)
		//IL_24be: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_2502: Unknown result type (might be due to invalid IL or missing references)
		//IL_2507: Unknown result type (might be due to invalid IL or missing references)
		//IL_2509: Unknown result type (might be due to invalid IL or missing references)
		//IL_250b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2517: Unknown result type (might be due to invalid IL or missing references)
		//IL_252e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2533: Unknown result type (might be due to invalid IL or missing references)
		//IL_2546: Unknown result type (might be due to invalid IL or missing references)
		//IL_254c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2562: Unknown result type (might be due to invalid IL or missing references)
		//IL_2564: Unknown result type (might be due to invalid IL or missing references)
		//IL_256e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2573: Unknown result type (might be due to invalid IL or missing references)
		//IL_2398: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d50: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d66: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_26bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_26c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_26c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_36de: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_372d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3757: Unknown result type (might be due to invalid IL or missing references)
		//IL_375d: Unknown result type (might be due to invalid IL or missing references)
		//IL_37a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_37a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_37b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4050: Unknown result type (might be due to invalid IL or missing references)
		//IL_4055: Unknown result type (might be due to invalid IL or missing references)
		//IL_4082: Unknown result type (might be due to invalid IL or missing references)
		//IL_4093: Unknown result type (might be due to invalid IL or missing references)
		//IL_4026: Unknown result type (might be due to invalid IL or missing references)
		//IL_402b: Unknown result type (might be due to invalid IL or missing references)
		//IL_428e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4294: Unknown result type (might be due to invalid IL or missing references)
		//IL_4299: Unknown result type (might be due to invalid IL or missing references)
		//IL_429e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4618: Unknown result type (might be due to invalid IL or missing references)
		//IL_45d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_45e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_44cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_42de: Unknown result type (might be due to invalid IL or missing references)
		//IL_42f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_40bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_40c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4316: Unknown result type (might be due to invalid IL or missing references)
		//IL_432c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4366: Unknown result type (might be due to invalid IL or missing references)
		//IL_437c: Unknown result type (might be due to invalid IL or missing references)
		//IL_486e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4879: Unknown result type (might be due to invalid IL or missing references)
		//IL_454a: Unknown result type (might be due to invalid IL or missing references)
		//IL_455b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4560: Unknown result type (might be due to invalid IL or missing references)
		//IL_4565: Unknown result type (might be due to invalid IL or missing references)
		//IL_43a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_41a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_43e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_43f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_41de: Unknown result type (might be due to invalid IL or missing references)
		//IL_41e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_41f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4205: Unknown result type (might be due to invalid IL or missing references)
		//IL_420a: Unknown result type (might be due to invalid IL or missing references)
		//IL_420e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4218: Unknown result type (might be due to invalid IL or missing references)
		//IL_421d: Unknown result type (might be due to invalid IL or missing references)
		//IL_421f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4229: Unknown result type (might be due to invalid IL or missing references)
		//IL_422e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e89: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eab: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_4be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_48b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_48bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_441d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4433: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_7779: Unknown result type (might be due to invalid IL or missing references)
		//IL_7788: Unknown result type (might be due to invalid IL or missing references)
		//IL_778d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7735: Unknown result type (might be due to invalid IL or missing references)
		//IL_7744: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f37: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4903: Unknown result type (might be due to invalid IL or missing references)
		//IL_490e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f24: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_77c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_77d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_77d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_77d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_77e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_77ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_77f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f68: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f42: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f55: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f59: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_781a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7824: Unknown result type (might be due to invalid IL or missing references)
		//IL_7829: Unknown result type (might be due to invalid IL or missing references)
		//IL_782c: Unknown result type (might be due to invalid IL or missing references)
		//IL_783b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7840: Unknown result type (might be due to invalid IL or missing references)
		//IL_7845: Unknown result type (might be due to invalid IL or missing references)
		//IL_4938: Unknown result type (might be due to invalid IL or missing references)
		//IL_4943: Unknown result type (might be due to invalid IL or missing references)
		//IL_786d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7877: Unknown result type (might be due to invalid IL or missing references)
		//IL_787c: Unknown result type (might be due to invalid IL or missing references)
		//IL_787f: Unknown result type (might be due to invalid IL or missing references)
		//IL_788e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7893: Unknown result type (might be due to invalid IL or missing references)
		//IL_7898: Unknown result type (might be due to invalid IL or missing references)
		//IL_903c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9073: Unknown result type (might be due to invalid IL or missing references)
		//IL_496d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4978: Unknown result type (might be due to invalid IL or missing references)
		//IL_49a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_49ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_7aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_795c: Unknown result type (might be due to invalid IL or missing references)
		//IL_90f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_910a: Unknown result type (might be due to invalid IL or missing references)
		//IL_51a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_51af: Unknown result type (might be due to invalid IL or missing references)
		//IL_51b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_49e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_49ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_79a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_79f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_805b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_91ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_91b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_91b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_91be: Unknown result type (might be due to invalid IL or missing references)
		//IL_91c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_91ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_91d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_91ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_91fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_9204: Unknown result type (might be due to invalid IL or missing references)
		//IL_920b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_890f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8922: Unknown result type (might be due to invalid IL or missing references)
		//IL_87d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_8079: Unknown result type (might be due to invalid IL or missing references)
		//IL_8096: Unknown result type (might be due to invalid IL or missing references)
		//IL_7bbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_7bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_893f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8958: Unknown result type (might be due to invalid IL or missing references)
		//IL_87f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_8815: Unknown result type (might be due to invalid IL or missing references)
		//IL_8460: Unknown result type (might be due to invalid IL or missing references)
		//IL_8473: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_8490: Unknown result type (might be due to invalid IL or missing references)
		//IL_849b: Unknown result type (might be due to invalid IL or missing references)
		//IL_84b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_84bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e22: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e27: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e64: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ea2: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_7eae: Unknown result type (might be due to invalid IL or missing references)
		//IL_7eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ebe: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ef2: Unknown result type (might be due to invalid IL or missing references)
		//IL_7eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_9cd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_8145: Unknown result type (might be due to invalid IL or missing references)
		//IL_814a: Unknown result type (might be due to invalid IL or missing references)
		//IL_814f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8151: Unknown result type (might be due to invalid IL or missing references)
		//IL_815d: Unknown result type (might be due to invalid IL or missing references)
		//IL_817d: Unknown result type (might be due to invalid IL or missing references)
		//IL_93f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_9407: Unknown result type (might be due to invalid IL or missing references)
		//IL_8194: Unknown result type (might be due to invalid IL or missing references)
		//IL_81a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_9733: Unknown result type (might be due to invalid IL or missing references)
		//IL_9749: Unknown result type (might be due to invalid IL or missing references)
		//IL_9420: Unknown result type (might be due to invalid IL or missing references)
		//IL_9436: Unknown result type (might be due to invalid IL or missing references)
		//IL_9446: Unknown result type (might be due to invalid IL or missing references)
		//IL_9463: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8260: Unknown result type (might be due to invalid IL or missing references)
		//IL_8274: Unknown result type (might be due to invalid IL or missing references)
		//IL_8279: Unknown result type (might be due to invalid IL or missing references)
		//IL_827e: Unknown result type (might be due to invalid IL or missing references)
		//IL_828d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8292: Unknown result type (might be due to invalid IL or missing references)
		//IL_829a: Unknown result type (might be due to invalid IL or missing references)
		//IL_829f: Unknown result type (might be due to invalid IL or missing references)
		//IL_82a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_9762: Unknown result type (might be due to invalid IL or missing references)
		//IL_9778: Unknown result type (might be due to invalid IL or missing references)
		//IL_9788: Unknown result type (might be due to invalid IL or missing references)
		//IL_97a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_9509: Unknown result type (might be due to invalid IL or missing references)
		//IL_9542: Unknown result type (might be due to invalid IL or missing references)
		//IL_95df: Unknown result type (might be due to invalid IL or missing references)
		//IL_95e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e40: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e59: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_82c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_82d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_82e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_82ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_82f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_82fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_8301: Unknown result type (might be due to invalid IL or missing references)
		//IL_8303: Unknown result type (might be due to invalid IL or missing references)
		//IL_984a: Unknown result type (might be due to invalid IL or missing references)
		//IL_9883: Unknown result type (might be due to invalid IL or missing references)
		//IL_991c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9923: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_8da6: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_8de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_8de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e04: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e09: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c83: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cae: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ccd: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ce2: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_830c: Unknown result type (might be due to invalid IL or missing references)
		//IL_830e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8316: Unknown result type (might be due to invalid IL or missing references)
		//IL_831b: Unknown result type (might be due to invalid IL or missing references)
		//IL_831f: Unknown result type (might be due to invalid IL or missing references)
		//IL_832d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_9aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_9af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_8eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_8efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_8350: Unknown result type (might be due to invalid IL or missing references)
		//IL_8361: Unknown result type (might be due to invalid IL or missing references)
		//IL_836c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8371: Unknown result type (might be due to invalid IL or missing references)
		//IL_8376: Unknown result type (might be due to invalid IL or missing references)
		//IL_837f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8386: Unknown result type (might be due to invalid IL or missing references)
		//IL_838d: Unknown result type (might be due to invalid IL or missing references)
		//IL_8394: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_52be: Unknown result type (might be due to invalid IL or missing references)
		//IL_52c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_52cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_58f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_58fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_5903: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbba: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_bb90: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_c4fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd50: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd70: Unknown result type (might be due to invalid IL or missing references)
		//IL_bda5: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc03: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba38: Unknown result type (might be due to invalid IL or missing references)
		//IL_c51c: Unknown result type (might be due to invalid IL or missing references)
		//IL_bdec: Unknown result type (might be due to invalid IL or missing references)
		//IL_d799: Unknown result type (might be due to invalid IL or missing references)
		//IL_d7b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_d7cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_d7d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_c53b: Unknown result type (might be due to invalid IL or missing references)
		//IL_c540: Unknown result type (might be due to invalid IL or missing references)
		//IL_be11: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc51: Unknown result type (might be due to invalid IL or missing references)
		//IL_d7ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_d825: Unknown result type (might be due to invalid IL or missing references)
		//IL_be32: Unknown result type (might be due to invalid IL or missing references)
		//IL_be37: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc72: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc77: Unknown result type (might be due to invalid IL or missing references)
		//IL_beec: Unknown result type (might be due to invalid IL or missing references)
		//IL_bef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_be56: Unknown result type (might be due to invalid IL or missing references)
		//IL_be5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_b09b: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf12: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf17: Unknown result type (might be due to invalid IL or missing references)
		//IL_be79: Unknown result type (might be due to invalid IL or missing references)
		//IL_be7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_b652: Unknown result type (might be due to invalid IL or missing references)
		//IL_b663: Unknown result type (might be due to invalid IL or missing references)
		//IL_b889: Unknown result type (might be due to invalid IL or missing references)
		//IL_b898: Unknown result type (might be due to invalid IL or missing references)
		//IL_b89d: Unknown result type (might be due to invalid IL or missing references)
		//IL_b8a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_b107: Unknown result type (might be due to invalid IL or missing references)
		//IL_b10c: Unknown result type (might be due to invalid IL or missing references)
		//IL_b11f: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf38: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_be9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_bea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_b675: Unknown result type (might be due to invalid IL or missing references)
		//IL_b688: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc20: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb43: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb48: Unknown result type (might be due to invalid IL or missing references)
		//IL_c058: Unknown result type (might be due to invalid IL or missing references)
		//IL_c05d: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf63: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf68: Unknown result type (might be due to invalid IL or missing references)
		//IL_bec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_becc: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_b205: Unknown result type (might be due to invalid IL or missing references)
		//IL_b25d: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc46: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb73: Unknown result type (might be due to invalid IL or missing references)
		//IL_c0d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_c0d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_c080: Unknown result type (might be due to invalid IL or missing references)
		//IL_c085: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf90: Unknown result type (might be due to invalid IL or missing references)
		//IL_bf95: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6db: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd39: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb96: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_c153: Unknown result type (might be due to invalid IL or missing references)
		//IL_c158: Unknown result type (might be due to invalid IL or missing references)
		//IL_c0fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_c0ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_c0aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_c0af: Unknown result type (might be due to invalid IL or missing references)
		//IL_bfb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_bfbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_cc96: Unknown result type (might be due to invalid IL or missing references)
		//IL_cbbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_cbc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_c1b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_c1bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_c182: Unknown result type (might be due to invalid IL or missing references)
		//IL_c187: Unknown result type (might be due to invalid IL or missing references)
		//IL_c124: Unknown result type (might be due to invalid IL or missing references)
		//IL_c129: Unknown result type (might be due to invalid IL or missing references)
		//IL_bfde: Unknown result type (might be due to invalid IL or missing references)
		//IL_bfe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_cdda: Unknown result type (might be due to invalid IL or missing references)
		//IL_cddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd80: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd85: Unknown result type (might be due to invalid IL or missing references)
		//IL_c81f: Unknown result type (might be due to invalid IL or missing references)
		//IL_c824: Unknown result type (might be due to invalid IL or missing references)
		//IL_c1ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_c1f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_c006: Unknown result type (might be due to invalid IL or missing references)
		//IL_c00b: Unknown result type (might be due to invalid IL or missing references)
		//IL_b75f: Unknown result type (might be due to invalid IL or missing references)
		//IL_b76a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b76f: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce31: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce36: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce02: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce07: Unknown result type (might be due to invalid IL or missing references)
		//IL_c215: Unknown result type (might be due to invalid IL or missing references)
		//IL_c030: Unknown result type (might be due to invalid IL or missing references)
		//IL_c035: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce60: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce65: Unknown result type (might be due to invalid IL or missing references)
		//IL_c22d: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf35: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf45: Unknown result type (might be due to invalid IL or missing references)
		//IL_cf5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_cfac: Unknown result type (might be due to invalid IL or missing references)
		//IL_cfc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_d116: Unknown result type (might be due to invalid IL or missing references)
		//IL_d14e: Unknown result type (might be due to invalid IL or missing references)
		//IL_d153: Unknown result type (might be due to invalid IL or missing references)
		//IL_c9aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_d174: Unknown result type (might be due to invalid IL or missing references)
		//IL_d179: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca37: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_a3c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_607a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6084: Unknown result type (might be due to invalid IL or missing references)
		//IL_6089: Unknown result type (might be due to invalid IL or missing references)
		//IL_a5a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_6201: Unknown result type (might be due to invalid IL or missing references)
		//IL_620b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6210: Unknown result type (might be due to invalid IL or missing references)
		//IL_6325: Unknown result type (might be due to invalid IL or missing references)
		//IL_632f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6334: Unknown result type (might be due to invalid IL or missing references)
		//IL_6489: Unknown result type (might be due to invalid IL or missing references)
		//IL_6493: Unknown result type (might be due to invalid IL or missing references)
		//IL_6498: Unknown result type (might be due to invalid IL or missing references)
		//IL_65ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_65f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_65fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_674e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6758: Unknown result type (might be due to invalid IL or missing references)
		//IL_675d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f56: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_6bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_6be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_6be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c16: Unknown result type (might be due to invalid IL or missing references)
		//IL_6eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ebd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ec2: Unknown result type (might be due to invalid IL or missing references)
		//IL_69ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_69b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_69bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_7039: Unknown result type (might be due to invalid IL or missing references)
		//IL_7043: Unknown result type (might be due to invalid IL or missing references)
		//IL_7048: Unknown result type (might be due to invalid IL or missing references)
		//IL_7149: Unknown result type (might be due to invalid IL or missing references)
		//IL_715a: Unknown result type (might be due to invalid IL or missing references)
		//IL_715f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7164: Unknown result type (might be due to invalid IL or missing references)
		//IL_7198: Unknown result type (might be due to invalid IL or missing references)
		//IL_71ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab14: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab19: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab30: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab45: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab55: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab62: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab68: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab82: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab89: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad50: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad57: Unknown result type (might be due to invalid IL or missing references)
		//IL_ac50: Unknown result type (might be due to invalid IL or missing references)
		//IL_ac7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_ace8: Unknown result type (might be due to invalid IL or missing references)
		//IL_acef: Unknown result type (might be due to invalid IL or missing references)
		//IL_aec9: Unknown result type (might be due to invalid IL or missing references)
		//IL_aed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae66: Unknown result type (might be due to invalid IL or missing references)
		//IL_aeb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_aebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_adb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_adc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_7521: Unknown result type (might be due to invalid IL or missing references)
		//IL_7527: Unknown result type (might be due to invalid IL or missing references)
		//IL_752c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7531: Unknown result type (might be due to invalid IL or missing references)
		//IL_765d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7667: Unknown result type (might be due to invalid IL or missing references)
		//IL_766c: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height == ((Entity)npc).position.Y + (float)((Entity)npc).height)
		{
			npc.directionY = -1;
		}
		bool flag = false;
		if (npc.type == 624 && npc.AI_003_Gnomes_ShouldTurnToStone())
		{
			int num = (int)(((Entity)npc).Center.X / 16f);
			int num2 = (int)(((Entity)npc).Bottom.Y / 16f);
			((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
			int num3 = Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 43, 0f, 0f, 254, Color.White, 0.5f);
			Dust obj = Main.dust[num3];
			obj.velocity *= 0.2f;
			((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			if (WorldGen.SolidTileAllowBottomSlope(num, num2))
			{
				for (int i = 0; i < 5; i++)
				{
					((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
					int num4 = Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 43, 0f, 0f, 254, Color.White, 0.5f);
					Dust obj2 = Main.dust[num4];
					obj2.velocity *= 0.2f;
					((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
				}
				TileObject val = default(TileObject);
				if (Main.netMode != 1 && TileObject.CanPlace(num, num2 - 1, 567, 0, ((Entity)npc).direction, ref val, true, (int?)null, false) && WorldGen.PlaceTile(num, num2 - 1, 567, false, false, -1, Main.rand.Next(5)))
				{
					if (Main.netMode == 2)
					{
						NetMessage.SendTileSquare(-1, num, num2 - 2, 1, 2, (TileChangeType)0);
					}
					if (Main.netMode != 1)
					{
						if (npc.IsNPCValidForBestiaryKillCredit())
						{
							Main.BestiaryTracker.Kills.RegisterKill(npc);
						}
						((object)npc).GetType().GetMethod("CountKillForBannersAndDropThem", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(npc, null);
					}
					npc.life = 0;
					((Entity)npc).active = false;
					AchievementsHelper.NotifyProgressionEvent(24);
					return false;
				}
			}
		}
		Vector2 val2;
		if (npc.type == 466)
		{
			int num5 = 200;
			if (npc.ai[2] == 0f)
			{
				npc.alpha = num5;
				npc.TargetClosest(true);
				if (!Main.player[npc.target].dead)
				{
					val2 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
					if (((Vector2)(ref val2)).Length() < 170f)
					{
						npc.ai[2] = -16f;
					}
				}
				if (((Entity)npc).velocity.X != 0f || ((Entity)npc).velocity.Y < 0f || ((Entity)npc).velocity.Y > 2f || npc.justHit)
				{
					npc.ai[2] = -16f;
				}
				return false;
			}
			if (npc.ai[2] < 0f)
			{
				if (npc.alpha > 0)
				{
					npc.alpha -= num5 / 16;
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] == 0f)
				{
					npc.ai[2] = 1f;
					((Entity)npc).velocity.X = ((Entity)npc).direction * 2;
				}
				return false;
			}
			npc.alpha = 0;
		}
		if (npc.type == 166)
		{
			if (Main.netMode != 1 && Utils.NextBool(Main.rand, 240))
			{
				npc.ai[2] = Main.rand.Next(-480, -60);
				npc.netUpdate = true;
			}
			if (npc.ai[2] < 0f)
			{
				npc.TargetClosest(true);
				if (npc.justHit)
				{
					npc.ai[2] = 0f;
				}
				if (Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
				{
					npc.ai[2] = 0f;
				}
			}
			if (npc.ai[2] < 0f)
			{
				((Entity)npc).velocity.X *= 0.9f;
				if ((double)((Entity)npc).velocity.X > -0.1 && (double)((Entity)npc).velocity.X < 0.1)
				{
					((Entity)npc).velocity.X = 0f;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] == 0f)
				{
					((Entity)npc).velocity.X = (float)((Entity)npc).direction * 0.1f;
				}
				return false;
			}
		}
		GameModeData gameModeInfo;
		if (npc.type == 461)
		{
			if (((Entity)npc).wet)
			{
				npc.knockBackResist = 0f;
				npc.ai[3] = -0.10101f;
				npc.noGravity = true;
				Vector2 center = ((Entity)npc).Center;
				((Entity)npc).width = 34;
				((Entity)npc).height = 24;
				((Entity)npc).position.X = center.X - (float)(((Entity)npc).width / 2);
				((Entity)npc).position.Y = center.Y - (float)(((Entity)npc).height / 2);
				npc.TargetClosest(true);
				if (npc.collideX)
				{
					((Entity)npc).velocity.X = 0f - ((Entity)npc).oldVelocity.X;
				}
				if (((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).direction = -1;
				}
				if (((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).direction = 1;
				}
				if (Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).Center, 1, 1))
				{
					Vector2 vector = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
					((Vector2)(ref vector)).Normalize();
					vector *= 5f;
					((Entity)npc).velocity = (((Entity)npc).velocity * 19f + vector) / 20f;
					return false;
				}
				float num6 = 5f;
				if (((Entity)npc).velocity.Y > 0f)
				{
					num6 = 3f;
				}
				if (((Entity)npc).velocity.Y < 0f)
				{
					num6 = 8f;
				}
				Vector2 vector2 = default(Vector2);
				((Vector2)(ref vector2))._002Ector((float)((Entity)npc).direction, -1f);
				((Vector2)(ref vector2)).Normalize();
				vector2 *= num6;
				if (num6 < 5f)
				{
					((Entity)npc).velocity = (((Entity)npc).velocity * 24f + vector2) / 25f;
				}
				else
				{
					((Entity)npc).velocity = (((Entity)npc).velocity * 9f + vector2) / 10f;
				}
				return false;
			}
			gameModeInfo = Main.GameModeInfo;
			npc.knockBackResist = 0.4f * ((GameModeData)(ref gameModeInfo)).KnockbackToEnemiesMultiplier;
			npc.noGravity = false;
			Vector2 center2 = ((Entity)npc).Center;
			((Entity)npc).width = 18;
			((Entity)npc).height = 40;
			((Entity)npc).position.X = center2.X - (float)(((Entity)npc).width / 2);
			((Entity)npc).position.Y = center2.Y - (float)(((Entity)npc).height / 2);
			if (npc.ai[3] == -0.10101f)
			{
				npc.ai[3] = 0f;
				float num7 = ((Vector2)(ref ((Entity)npc).velocity)).Length();
				num7 *= 2f;
				if (num7 > 10f)
				{
					num7 = 10f;
				}
				((Vector2)(ref ((Entity)npc).velocity)).Normalize();
				((Entity)npc).velocity = ((Entity)npc).velocity * num7;
				if (((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).direction = -1;
				}
				if (((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).direction = 1;
				}
				npc.spriteDirection = ((Entity)npc).direction;
			}
		}
		if (npc.type == 586)
		{
			if (npc.alpha == 255)
			{
				npc.TargetClosest(true);
				npc.spriteDirection = ((Entity)npc).direction;
				((Entity)npc).velocity.Y = -6f;
				npc.netUpdate = true;
				for (int j = 0; j < 35; j++)
				{
					Dust obj3 = Dust.NewDustDirect(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 5, 0f, 0f, 0, default(Color), 1f);
					obj3.velocity *= 1f;
					obj3.scale = 1f + Utils.NextFloat(Main.rand) * 0.5f;
					obj3.fadeIn = 1.5f + Utils.NextFloat(Main.rand) * 0.5f;
					obj3.velocity += ((Entity)npc).velocity * 0.5f;
				}
			}
			npc.alpha -= 15;
			if (npc.alpha < 0)
			{
				npc.alpha = 0;
			}
			((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
			if (npc.alpha != 0)
			{
				for (int k = 0; k < 2; k++)
				{
					Dust obj4 = Dust.NewDustDirect(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 5, 0f, 0f, 0, default(Color), 1f);
					obj4.velocity *= 1f;
					obj4.scale = 1f + Utils.NextFloat(Main.rand) * 0.5f;
					obj4.fadeIn = 1.5f + Utils.NextFloat(Main.rand) * 0.5f;
					obj4.velocity += ((Entity)npc).velocity * 0.3f;
				}
			}
			if (Main.rand.Next(3) == 0)
			{
				Dust obj5 = Dust.NewDustDirect(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 5, 0f, 0f, 0, default(Color), 1f);
				obj5.velocity *= 0f;
				obj5.alpha = 120;
				obj5.scale = 0.7f + Utils.NextFloat(Main.rand) * 0.5f;
				obj5.velocity += ((Entity)npc).velocity * 0.3f;
			}
			((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			if (((Entity)npc).wet)
			{
				npc.knockBackResist = 0f;
				npc.ai[3] = -0.10101f;
				npc.noGravity = true;
				Vector2 center3 = ((Entity)npc).Center;
				((Entity)npc).position.X = center3.X - (float)(((Entity)npc).width / 2);
				((Entity)npc).position.Y = center3.Y - (float)(((Entity)npc).height / 2);
				npc.TargetClosest(true);
				if (npc.collideX)
				{
					((Entity)npc).velocity.X = 0f - ((Entity)npc).oldVelocity.X;
				}
				if (((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).direction = -1;
				}
				if (((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).direction = 1;
				}
				if (Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).Center, 1, 1))
				{
					Vector2 vector3 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
					((Vector2)(ref vector3)).Normalize();
					float num8 = 1f;
					num8 += Math.Abs(((Entity)npc).Center.Y - ((Entity)Main.player[npc.target]).Center.Y) / 40f;
					num8 = MathHelper.Clamp(num8, 5f, 20f);
					vector3 *= num8;
					if (((Entity)npc).velocity.Y > 0f)
					{
						((Entity)npc).velocity = (((Entity)npc).velocity * 29f + vector3) / 30f;
					}
					else
					{
						((Entity)npc).velocity = (((Entity)npc).velocity * 4f + vector3) / 5f;
					}
					return false;
				}
				float num9 = 5f;
				if (((Entity)npc).velocity.Y > 0f)
				{
					num9 = 3f;
				}
				if (((Entity)npc).velocity.Y < 0f)
				{
					num9 = 8f;
				}
				Vector2 vector4 = default(Vector2);
				((Vector2)(ref vector4))._002Ector((float)((Entity)npc).direction, -1f);
				((Vector2)(ref vector4)).Normalize();
				vector4 *= num9;
				if (num9 < 5f)
				{
					((Entity)npc).velocity = (((Entity)npc).velocity * 24f + vector4) / 25f;
				}
				else
				{
					((Entity)npc).velocity = (((Entity)npc).velocity * 9f + vector4) / 10f;
				}
				return false;
			}
			npc.noGravity = false;
			Vector2 center4 = ((Entity)npc).Center;
			((Entity)npc).position.X = center4.X - (float)(((Entity)npc).width / 2);
			((Entity)npc).position.Y = center4.Y - (float)(((Entity)npc).height / 2);
			if (npc.ai[3] == -0.10101f)
			{
				npc.ai[3] = 0f;
				float num10 = ((Vector2)(ref ((Entity)npc).velocity)).Length();
				num10 *= 2f;
				if (num10 > 15f)
				{
					num10 = 15f;
				}
				((Vector2)(ref ((Entity)npc).velocity)).Normalize();
				((Entity)npc).velocity = ((Entity)npc).velocity * num10;
				if (((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).direction = -1;
				}
				if (((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).direction = 1;
				}
				npc.spriteDirection = ((Entity)npc).direction;
			}
		}
		if (npc.type == 379 || npc.type == 380)
		{
			if (npc.ai[3] < 0f)
			{
				npc.directionY = -1;
				flag = false;
				npc.damage = 0;
				((Entity)npc).velocity.X *= 0.93f;
				if ((double)((Entity)npc).velocity.X > -0.1 && (double)((Entity)npc).velocity.X < 0.1)
				{
					((Entity)npc).velocity.X = 0f;
				}
				int num11 = (int)(0f - npc.ai[3] - 1f);
				int num12 = Math.Sign(((Entity)Main.npc[num11]).Center.X - ((Entity)npc).Center.X);
				if (num12 != ((Entity)npc).direction)
				{
					((Entity)npc).velocity.X = 0f;
					((Entity)npc).direction = num12;
					npc.netUpdate = true;
				}
				if (npc.justHit && Main.netMode != 1 && Main.npc[num11].localAI[0] == 0f)
				{
					Main.npc[num11].localAI[0] = 1f;
				}
				if (npc.ai[0] < 1000f)
				{
					npc.ai[0] = 1000f;
				}
				if ((npc.ai[0] += 1f) >= 1300f)
				{
					npc.ai[0] = 1000f;
					npc.netUpdate = true;
				}
				return false;
			}
			if (npc.ai[0] >= 1000f)
			{
				npc.ai[0] = 0f;
			}
			npc.damage = npc.defDamage;
		}
		if (npc.type == 383 && npc.ai[2] == 0f && npc.localAI[0] == 0f && Main.netMode != 1)
		{
			int num13 = NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), (int)((Entity)npc).Center.X, (int)((Entity)npc).Center.Y, 384, ((Entity)npc).whoAmI, 0f, 0f, 0f, 0f, 255);
			npc.ai[2] = num13 + 1;
			npc.localAI[0] = -1f;
			npc.netUpdate = true;
			Main.npc[num13].ai[0] = ((Entity)npc).whoAmI;
			Main.npc[num13].netUpdate = true;
		}
		if (npc.type == 383)
		{
			int num14 = (int)npc.ai[2] - 1;
			if (num14 != -1 && ((Entity)Main.npc[num14]).active && Main.npc[num14].type == 384)
			{
				npc.dontTakeDamage = true;
			}
			else
			{
				npc.dontTakeDamage = false;
				npc.ai[2] = 0f;
				if (npc.localAI[0] == -1f)
				{
					npc.localAI[0] = 180f;
				}
				if (npc.localAI[0] > 0f)
				{
					npc.localAI[0] -= 1f;
				}
			}
		}
		if (npc.type == 482)
		{
			int num15 = 300;
			int num16 = 120;
			npc.dontTakeDamage = false;
			if (npc.ai[2] < 0f)
			{
				npc.dontTakeDamage = true;
				npc.ai[2] += 1f;
				((Entity)npc).velocity.X *= 0.9f;
				if ((double)Math.Abs(((Entity)npc).velocity.X) < 0.001)
				{
					((Entity)npc).velocity.X = 0.001f * (float)((Entity)npc).direction;
				}
				if (Math.Abs(((Entity)npc).velocity.Y) > 1f)
				{
					npc.ai[2] += 10f;
				}
				if (npc.ai[2] >= 0f)
				{
					npc.netUpdate = true;
					((Entity)npc).velocity.X += (float)((Entity)npc).direction * 0.3f;
				}
				return false;
			}
			if (npc.ai[2] < (float)num15)
			{
				if (npc.justHit)
				{
					npc.ai[2] += 15f;
				}
				npc.ai[2] += 1f;
			}
			else if (((Entity)npc).velocity.Y == 0f)
			{
				npc.ai[2] = -num16;
				npc.netUpdate = true;
			}
		}
		Rectangle hitbox;
		if (npc.type == 631)
		{
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !((Entity)Main.player[npc.target]).active)
			{
				npc.TargetClosest(npc.ai[2] > 0f);
			}
			Player player = Main.player[npc.target];
			bool flag2 = !player.dead && ((Entity)player).active && Utils.Distance(((Entity)npc).Center, ((Entity)player).Center) < 320f;
			int num17 = 100;
			int num18 = 32;
			if (npc.ai[2] == 0f)
			{
				npc.ai[3] = 65f;
				if (flag2 && Collision.CanHit((Entity)(object)player, (Entity)(object)npc))
				{
					npc.ai[2] = num17;
					npc.ai[3] = 0f;
					((Entity)npc).velocity.X = (float)((Entity)npc).direction * 0.01f;
					npc.netUpdate = true;
				}
			}
			else
			{
				if (npc.ai[2] < (float)num17)
				{
					npc.ai[2] += 1f;
					((Entity)npc).velocity.X *= 0.9f;
					if ((double)Math.Abs(((Entity)npc).velocity.X) < 0.001)
					{
						((Entity)npc).velocity.X = 0f;
					}
					if (Math.Abs(((Entity)npc).velocity.Y) > 1f)
					{
						npc.ai[2] = 0f;
					}
					if (npc.ai[2] == (float)(num17 - num18 / 2) && Main.netMode != 1)
					{
						hitbox = ((Entity)player).Hitbox;
						if (!((Rectangle)(ref hitbox)).Intersects(((Entity)npc).Hitbox) && Collision.CanHit((Entity)(object)player, (Entity)(object)npc))
						{
							float num19 = 8f;
							Vector2 center5 = ((Entity)npc).Center;
							Vector2 vector5 = ((Entity)npc).DirectionTo(((Entity)Main.player[npc.target]).Center) * num19;
							if (Utils.HasNaNs(vector5))
							{
								((Vector2)(ref vector5))._002Ector((float)((Entity)npc).direction * num19, 0f);
							}
							int num20 = 20;
							Vector2 v = vector5 + Utils.RandomVector2(Main.rand, -0.8f, 0.8f);
							v = Utils.SafeNormalize(v, Vector2.Zero);
							v *= num19;
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), center5.X, center5.Y, v.X, v.Y, 909, num20, 1f, Main.myPlayer, 0f, 0f, 0f);
						}
					}
					if (npc.ai[2] >= (float)num17)
					{
						npc.ai[2] = num17;
						npc.ai[3] = 0f;
						((Entity)npc).velocity.X = (float)((Entity)npc).direction * 0.01f;
						npc.netUpdate = true;
					}
					return false;
				}
				if (((Entity)npc).velocity.Y == 0f && flag2)
				{
					hitbox = ((Entity)player).Hitbox;
					if (((Rectangle)(ref hitbox)).Intersects(((Entity)npc).Hitbox) || Collision.CanHit((Entity)(object)player, (Entity)(object)npc))
					{
						npc.ai[2] = num17 - num18;
						npc.netUpdate = true;
					}
				}
			}
		}
		if (npc.type == 480)
		{
			int num21 = 180;
			int num22 = 300;
			int num23 = 180;
			int num24 = 60;
			int num25 = 20;
			if (npc.life < npc.lifeMax / 3)
			{
				num21 = 120;
				num22 = 240;
				num23 = 240;
				num24 = 90;
			}
			if (npc.ai[2] > 0f)
			{
				npc.ai[2] -= 1f;
			}
			else if (npc.ai[2] == 0f)
			{
				if (((((Entity)Main.player[npc.target]).Center.X < ((Entity)npc).Center.X && ((Entity)npc).direction < 0) || (((Entity)Main.player[npc.target]).Center.X > ((Entity)npc).Center.X && ((Entity)npc).direction > 0)) && ((Entity)npc).velocity.Y == 0f && ((Entity)npc).Distance(((Entity)Main.player[npc.target]).Center) < 900f && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
				{
					npc.ai[2] = -num23 - num25;
					npc.netUpdate = true;
				}
			}
			else
			{
				if (npc.ai[2] < 0f && npc.ai[2] < (float)(-num23))
				{
					((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
					((Entity)npc).velocity.X *= 0.9f;
					if (((Entity)npc).velocity.Y < -2f || ((Entity)npc).velocity.Y > 4f || npc.justHit)
					{
						npc.ai[2] = num21;
					}
					else
					{
						npc.ai[2] += 1f;
						if (npc.ai[2] == 0f)
						{
							npc.ai[2] = num22;
						}
					}
					float num26 = npc.ai[2] + (float)num23 + (float)num25;
					if (num26 == 1f)
					{
						SoundEngine.PlaySound(ref SoundID.NPCDeath17, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
					}
					if (num26 < (float)num25)
					{
						Vector2 vector6 = ((Entity)npc).Top + new Vector2((float)(npc.spriteDirection * 6), 6f);
						float num27 = MathHelper.Lerp(20f, 30f, (num26 * 3f + 50f) / 182f);
						Utils.NextFloat(Main.rand);
						for (float num28 = 0f; num28 < 2f; num28 += 1f)
						{
							Vector2 vector7 = Utils.RotatedByRandom(Vector2.UnitY, 6.2831854820251465) * (Utils.NextFloat(Main.rand) * 0.5f + 0.5f);
							Dust obj6 = Main.dust[Dust.NewDust(vector6, 0, 0, 228, 0f, 0f, 0, default(Color), 1f)];
							obj6.position = vector6 + vector7 * num27;
							obj6.noGravity = true;
							obj6.velocity = vector7 * 2f;
							obj6.scale = 0.5f + Utils.NextFloat(Main.rand) * 0.5f;
						}
					}
					Lighting.AddLight(((Entity)npc).Center, 0.9f, 0.75f, 0.1f);
					((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
					return false;
				}
				if (npc.ai[2] < 0f && npc.ai[2] >= (float)(-num23))
				{
					((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
					Lighting.AddLight(((Entity)npc).Center, 0.9f, 0.75f, 0.1f);
					((Entity)npc).velocity.X *= 0.9f;
					if (((Entity)npc).velocity.Y < -2f || ((Entity)npc).velocity.Y > 4f || npc.justHit)
					{
						npc.ai[2] = num21;
					}
					else
					{
						npc.ai[2] += 1f;
						if (npc.ai[2] == 0f)
						{
							npc.ai[2] = num22;
						}
					}
					float num29 = npc.ai[2] + (float)num23;
					if (num29 < 180f && (Main.rand.Next(3) == 0 || npc.ai[2] % 3f == 0f))
					{
						Vector2 vector8 = ((Entity)npc).Top + new Vector2((float)(npc.spriteDirection * 10), 10f);
						float num30 = MathHelper.Lerp(20f, 30f, (num29 * 3f + 50f) / 182f);
						Utils.NextFloat(Main.rand);
						for (float num31 = 0f; num31 < 1f; num31 += 1f)
						{
							Vector2 vector9 = Utils.RotatedByRandom(Vector2.UnitY, 6.2831854820251465) * (Utils.NextFloat(Main.rand) * 0.5f + 0.5f);
							Dust obj7 = Main.dust[Dust.NewDust(vector8, 0, 0, 228, 0f, 0f, 0, default(Color), 1f)];
							obj7.position = vector8 + vector9 * num30;
							obj7.noGravity = true;
							obj7.velocity = vector9 * 4f;
							obj7.scale = 0.5f + Utils.NextFloat(Main.rand);
						}
					}
					((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
					if (Main.netMode == 2)
					{
						return false;
					}
					Player player2 = Main.player[Main.myPlayer];
					_ = Main.myPlayer;
					if (player2.dead || !((Entity)player2).active || player2.FindBuffIndex(156) != -1)
					{
						return false;
					}
					Vector2 vector10 = ((Entity)player2).Center - ((Entity)npc).Center;
					if (!(((Vector2)(ref vector10)).Length() < 700f))
					{
						return false;
					}
					bool flag3 = ((Vector2)(ref vector10)).Length() < 30f;
					if (!flag3)
					{
						float x = Utils.ToRotationVector2((float)Math.PI / 4f).X;
						Vector2 vector11 = Vector2.Normalize(vector10);
						if (vector11.X > x || vector11.X < 0f - x)
						{
							flag3 = true;
						}
					}
					if (((((Entity)player2).Center.X < ((Entity)npc).Center.X && ((Entity)npc).direction < 0 && ((Entity)player2).direction > 0) || (((Entity)player2).Center.X > ((Entity)npc).Center.X && ((Entity)npc).direction > 0 && ((Entity)player2).direction < 0)) && flag3 && (Collision.CanHitLine(((Entity)npc).Center, 1, 1, ((Entity)player2).Center, 1, 1) || Collision.CanHitLine(((Entity)npc).Center - Vector2.UnitY * 16f, 1, 1, ((Entity)player2).Center, 1, 1) || Collision.CanHitLine(((Entity)npc).Center + Vector2.UnitY * 8f, 1, 1, ((Entity)player2).Center, 1, 1)) && !player2.creativeGodMode)
					{
						player2.AddBuff(156, num24 + (int)npc.ai[2] * -1, true, false);
					}
					return false;
				}
			}
		}
		Tile val3;
		if (npc.type == 471)
		{
			if (npc.ai[3] < 0f)
			{
				npc.knockBackResist = 0f;
				npc.defense = (int)((double)npc.defDefense * 1.1);
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).direction = -1;
				}
				else if (((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).direction = 1;
				}
				npc.rotation = ((Entity)npc).velocity.X * 0.1f;
				if (Main.netMode != 1)
				{
					npc.localAI[3] += 1f;
					if (npc.localAI[3] > (float)Main.rand.Next(20, 180))
					{
						npc.localAI[3] = 0f;
						Vector2 center6 = ((Entity)npc).Center;
						center6 += ((Entity)npc).velocity;
						NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), (int)center6.X, (int)center6.Y, 30, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
			}
			else
			{
				npc.localAI[3] = 0f;
				gameModeInfo = Main.GameModeInfo;
				npc.knockBackResist = 0.35f * ((GameModeData)(ref gameModeInfo)).KnockbackToEnemiesMultiplier;
				npc.rotation *= 0.9f;
				npc.defense = npc.defDefense;
				npc.noGravity = false;
				npc.noTileCollide = false;
			}
			if (npc.ai[3] == 1f)
			{
				npc.knockBackResist = 0f;
				npc.defense += 10;
			}
			if (npc.ai[3] == -1f)
			{
				npc.TargetClosest(true);
				float num32 = 8f;
				float num33 = 40f;
				Vector2 vector12 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
				float num34 = ((Vector2)(ref vector12)).Length();
				num32 += num34 / 200f;
				((Vector2)(ref vector12)).Normalize();
				vector12 *= num32;
				((Entity)npc).velocity = (((Entity)npc).velocity * (num33 - 1f) + vector12) / num33;
				if (num34 < 500f && !Collision.SolidCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height))
				{
					npc.ai[3] = 0f;
					npc.ai[2] = 0f;
				}
				return false;
			}
			if (npc.ai[3] == -2f)
			{
				((Entity)npc).velocity.Y -= 0.2f;
				if (((Entity)npc).velocity.Y < -10f)
				{
					((Entity)npc).velocity.Y = -10f;
				}
				if (((Entity)Main.player[npc.target]).Center.Y - ((Entity)npc).Center.Y > 200f)
				{
					npc.TargetClosest(true);
					npc.ai[3] = -3f;
					if (((Entity)Main.player[npc.target]).Center.X > ((Entity)npc).Center.X)
					{
						npc.ai[2] = 1f;
					}
					else
					{
						npc.ai[2] = -1f;
					}
				}
				((Entity)npc).velocity.X *= 0.99f;
				return false;
			}
			if (npc.ai[3] == -3f)
			{
				if (((Entity)npc).direction == 0)
				{
					npc.TargetClosest(true);
				}
				if (npc.ai[2] == 0f)
				{
					npc.ai[2] = ((Entity)npc).direction;
				}
				((Entity)npc).velocity.Y *= 0.9f;
				((Entity)npc).velocity.X += npc.ai[2] * 0.3f;
				if (((Entity)npc).velocity.X > 10f)
				{
					((Entity)npc).velocity.X = 10f;
				}
				if (((Entity)npc).velocity.X < -10f)
				{
					((Entity)npc).velocity.X = -10f;
				}
				float num35 = ((Entity)Main.player[npc.target]).Center.X - ((Entity)npc).Center.X;
				if ((npc.ai[2] < 0f && num35 > 300f) || (npc.ai[2] > 0f && num35 < -300f))
				{
					npc.ai[3] = -4f;
					npc.ai[2] = 0f;
				}
				else if (Math.Abs(num35) > 800f)
				{
					npc.ai[3] = -1f;
					npc.ai[2] = 0f;
				}
				return false;
			}
			if (npc.ai[3] == -4f)
			{
				npc.ai[2] += 1f;
				((Entity)npc).velocity.Y += 0.1f;
				if (((Vector2)(ref ((Entity)npc).velocity)).Length() > 4f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.9f;
				}
				int num36 = (int)((Entity)npc).Center.X / 16;
				int num37 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 12f) / 16;
				bool flag4 = false;
				for (int l = num36 - 1; l <= num36 + 1; l++)
				{
					val3 = ((Tilemap)(ref Main.tile))[l, num37];
					if (((Tile)(ref val3)).HasTile)
					{
						bool[] tileSolid = Main.tileSolid;
						val3 = ((Tilemap)(ref Main.tile))[l, num37];
						if (tileSolid[((Tile)(ref val3)).TileType])
						{
							flag4 = true;
						}
					}
				}
				if (flag4 && !Collision.SolidCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height))
				{
					npc.ai[3] = 0f;
					npc.ai[2] = 0f;
				}
				else if (npc.ai[2] > 300f || ((Entity)npc).Center.Y > ((Entity)Main.player[npc.target]).Center.Y + 200f)
				{
					npc.ai[3] = -1f;
					npc.ai[2] = 0f;
				}
			}
			else
			{
				if (npc.ai[3] == 1f)
				{
					Vector2 center7 = ((Entity)npc).Center;
					center7.Y -= 70f;
					((Entity)npc).velocity.X *= 0.8f;
					npc.ai[2] += 1f;
					if (npc.ai[2] == 60f)
					{
						if (Main.netMode != 1)
						{
							NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), (int)center7.X, (int)center7.Y + 18, 472, 0, 0f, 0f, 0f, 0f, 255);
						}
					}
					else if (npc.ai[2] >= 90f)
					{
						npc.ai[3] = -2f;
						npc.ai[2] = 0f;
					}
					Vector2 vector14 = default(Vector2);
					for (int m = 0; m < 2; m++)
					{
						Vector2 val4 = center7;
						((Vector2)(ref vector14))._002Ector((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
						((Vector2)(ref vector14)).Normalize();
						vector14 *= (float)Main.rand.Next(0, 100) * 0.1f;
						Vector2 val5 = val4 + vector14;
						((Vector2)(ref vector14)).Normalize();
						vector14 *= (float)Main.rand.Next(50, 90) * 0.1f;
						int num38 = Dust.NewDust(val5, 1, 1, 27, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num38].velocity = -vector14 * 0.3f;
						Main.dust[num38].alpha = 100;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num38].noGravity = true;
							Dust obj8 = Main.dust[num38];
							obj8.scale += 0.3f;
						}
					}
					return false;
				}
				npc.ai[2] += 1f;
				int num39 = 10;
				if (((Entity)npc).velocity.Y == 0f && NPC.CountNPCS(472) < num39)
				{
					if (npc.ai[2] >= 180f)
					{
						npc.ai[2] = 0f;
						npc.ai[3] = 1f;
					}
				}
				else
				{
					if (NPC.CountNPCS(472) >= num39)
					{
						npc.ai[2] += 1f;
					}
					if (npc.ai[2] >= 360f)
					{
						npc.ai[2] = 0f;
						npc.ai[3] = -2f;
						((Entity)npc).velocity.Y -= 3f;
					}
				}
				if (npc.target >= 0 && !Main.player[npc.target].dead)
				{
					val2 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
					if (((Vector2)(ref val2)).Length() > 800f)
					{
						npc.ai[3] = -1f;
						npc.ai[2] = 0f;
					}
				}
			}
			if (Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].dead)
				{
					npc.EncourageDespawn(1);
				}
			}
		}
		if (npc.type == 419)
		{
			npc.reflectsProjectiles = false;
			npc.takenDamageMultiplier = 1f;
			int num40 = 6;
			int num41 = 10;
			float num42 = 16f;
			if (npc.ai[2] > 0f)
			{
				npc.ai[2] -= 1f;
			}
			if (npc.ai[2] == 0f)
			{
				if (((((Entity)Main.player[npc.target]).Center.X < ((Entity)npc).Center.X && ((Entity)npc).direction < 0) || (((Entity)Main.player[npc.target]).Center.X > ((Entity)npc).Center.X && ((Entity)npc).direction > 0)) && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
				{
					npc.ai[2] = -1f;
					npc.netUpdate = true;
					npc.TargetClosest(true);
				}
			}
			else
			{
				if (npc.ai[2] < 0f && npc.ai[2] > (float)(-num40))
				{
					npc.ai[2] -= 1f;
					((Entity)npc).velocity.X *= 0.9f;
					return false;
				}
				if (npc.ai[2] == (float)(-num40))
				{
					npc.ai[2] -= 1f;
					npc.TargetClosest(true);
					Vector2 vector16 = ((Entity)npc).DirectionTo(((Entity)Main.player[npc.target]).Top + new Vector2(0f, -30f));
					if (Utils.HasNaNs(vector16))
					{
						vector16 = Vector2.Normalize(new Vector2((float)npc.spriteDirection, -1f));
					}
					((Entity)npc).velocity = vector16 * num42;
					npc.netUpdate = true;
					return false;
				}
				if (npc.ai[2] < (float)(-num40))
				{
					npc.ai[2] -= 1f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						npc.ai[2] = 60f;
					}
					else if (npc.ai[2] < (float)(-num40 - num41))
					{
						((Entity)npc).velocity.Y += 0.15f;
						if (((Entity)npc).velocity.Y > 24f)
						{
							((Entity)npc).velocity.Y = 24f;
						}
					}
					npc.reflectsProjectiles = true;
					npc.takenDamageMultiplier = 3f;
					if (npc.justHit)
					{
						npc.ai[2] = 60f;
						npc.netUpdate = true;
					}
					return false;
				}
			}
		}
		if (npc.type == 415)
		{
			int num43 = 42;
			int num44 = 18;
			if (npc.justHit)
			{
				npc.ai[2] = 120f;
				npc.netUpdate = true;
			}
			if (npc.ai[2] > 0f)
			{
				npc.ai[2] -= 1f;
			}
			if (npc.ai[2] == 0f)
			{
				int num45 = 0;
				for (int n = 0; n < 200; n++)
				{
					if (((Entity)Main.npc[n]).active && Main.npc[n].type == 516)
					{
						num45++;
					}
				}
				if (num45 > 6)
				{
					npc.ai[2] = 90f;
				}
				else if (((((Entity)Main.player[npc.target]).Center.X < ((Entity)npc).Center.X && ((Entity)npc).direction < 0) || (((Entity)Main.player[npc.target]).Center.X > ((Entity)npc).Center.X && ((Entity)npc).direction > 0)) && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
				{
					npc.ai[2] = -1f;
					npc.netUpdate = true;
					npc.TargetClosest(true);
				}
			}
			else if (npc.ai[2] < 0f && npc.ai[2] > (float)(-num43))
			{
				npc.ai[2] -= 1f;
				if (npc.ai[2] == (float)(-num43))
				{
					npc.ai[2] = 180 + 30 * Main.rand.Next(10);
				}
				((Entity)npc).velocity.X *= 0.8f;
				if (npc.ai[2] == (float)(-num44) || npc.ai[2] == (float)(-num44 - 8) || npc.ai[2] == (float)(-num44 - 16))
				{
					((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
					for (int num46 = 0; num46 < 20; num46++)
					{
						Vector2 vector17 = ((Entity)npc).Center + Vector2.UnitX * (float)npc.spriteDirection * 40f;
						Dust obj9 = Main.dust[Dust.NewDust(vector17, 0, 0, 259, 0f, 0f, 0, default(Color), 1f)];
						Vector2 vector18 = Utils.RotatedByRandom(Vector2.UnitY, 6.2831854820251465);
						obj9.position = vector17 + vector18 * 4f;
						obj9.velocity = vector18 * 2f + Vector2.UnitX * Utils.NextFloat(Main.rand) * (float)npc.spriteDirection * 3f;
						obj9.scale = 0.3f + vector18.X * (float)(-npc.spriteDirection);
						obj9.fadeIn = 0.7f;
						obj9.noGravity = true;
					}
					((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
					if (((Entity)npc).velocity.X > -0.5f && ((Entity)npc).velocity.X < 0.5f)
					{
						((Entity)npc).velocity.X = 0f;
					}
					if (Main.netMode != 1)
					{
						NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), (int)((Entity)npc).Center.X + npc.spriteDirection * 45, (int)((Entity)npc).Center.Y + 8, 516, 0, 0f, 0f, 0f, 0f, npc.target);
					}
				}
				return false;
			}
		}
		if (npc.type == 428)
		{
			npc.localAI[0] += 1f;
			if (npc.localAI[0] >= 300f)
			{
				int num47 = (int)((Entity)npc).Center.X / 16 - 1;
				int num48 = (int)((Entity)npc).Center.Y / 16 - 1;
				if (!Collision.SolidTiles(num47, num47 + 2, num48, num48 + 1) && Main.netMode != 1)
				{
					npc.Transform(427);
					npc.life = npc.lifeMax;
					npc.localAI[0] = 0f;
					return false;
				}
			}
			int num49 = 0;
			num49 = ((npc.localAI[0] < 60f) ? 16 : ((npc.localAI[0] < 120f) ? 8 : ((npc.localAI[0] < 180f) ? 4 : ((npc.localAI[0] < 240f) ? 2 : ((!(npc.localAI[0] < 300f)) ? 1 : 1)))));
			if (Main.rand.Next(num49) == 0)
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				Dust dust4 = Main.dust[Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 229, 0f, 0f, 0, default(Color), 1f)];
				dust4.noGravity = true;
				dust4.scale = 1f;
				dust4.noLight = true;
				dust4.velocity = ((Entity)npc).DirectionFrom(dust4.position) * ((Vector2)(ref dust4.velocity)).Length();
				dust4.position -= dust4.velocity * 5f;
				dust4.position.X += ((Entity)npc).direction * 6;
				dust4.position.Y += 4f;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		if (npc.type == 427)
		{
			npc.localAI[0] += 1f;
			npc.localAI[0] += Math.Abs(((Entity)npc).velocity.X) / 2f;
			if (npc.localAI[0] >= 1200f && Main.netMode != 1)
			{
				int num50 = (int)((Entity)npc).Center.X / 16 - 2;
				int num51 = (int)((Entity)npc).Center.Y / 16 - 3;
				if (!Collision.SolidTiles(num50, num50 + 4, num51, num51 + 4))
				{
					npc.Transform(426);
					npc.life = npc.lifeMax;
					npc.localAI[0] = 0f;
					return false;
				}
			}
			int num52 = 0;
			num52 = ((npc.localAI[0] < 360f) ? 32 : ((npc.localAI[0] < 720f) ? 16 : ((npc.localAI[0] < 1080f) ? 6 : ((npc.localAI[0] < 1440f) ? 2 : ((!(npc.localAI[0] < 1800f)) ? 1 : 1)))));
			if (Main.rand.Next(num52) == 0)
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				Dust obj10 = Main.dust[Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 229, 0f, 0f, 0, default(Color), 1f)];
				obj10.noGravity = true;
				obj10.scale = 1f;
				obj10.noLight = true;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		if (npc.type == 590)
		{
			((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
			int num53 = (int)(((Entity)npc).position.Y + 6f) / 16;
			if (npc.spriteDirection < 0)
			{
				int num54 = (int)(((Entity)npc).Center.X - 22f) / 16;
				Tile tileSafely = Framing.GetTileSafely(num54, num53);
				Tile tileSafely2 = Framing.GetTileSafely(num54 + 1, num53);
				if (WorldGen.InWorld(num54, num53, 0) && ((Tile)(ref tileSafely2)).LiquidAmount == 0 && ((Tile)(ref tileSafely)).LiquidAmount == 0)
				{
					Lighting.AddLight(num54, num53, 1f, 0.95f, 0.8f);
					if (Main.rand.Next(30) == 0)
					{
						Dust.NewDust(new Vector2(((Entity)npc).Center.X - 22f, ((Entity)npc).position.Y + 6f), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);
					}
				}
			}
			else
			{
				int num55 = (int)(((Entity)npc).Center.X + 14f) / 16;
				Tile tileSafely3 = Framing.GetTileSafely(num55, num53);
				Tile tileSafely4 = Framing.GetTileSafely(num55 - 1, num53);
				if (WorldGen.InWorld(num55, num53, 0) && ((Tile)(ref tileSafely4)).LiquidAmount == 0 && ((Tile)(ref tileSafely3)).LiquidAmount == 0)
				{
					Lighting.AddLight(num55, num53, 1f, 0.95f, 0.8f);
					if (Main.rand.Next(30) == 0)
					{
						Dust.NewDust(new Vector2(((Entity)npc).Center.X + 14f, ((Entity)npc).position.Y + 6f), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);
					}
				}
			}
			((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
		}
		else if (npc.type == 591)
		{
			((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
			if (!((Entity)npc).wet)
			{
				if (npc.spriteDirection < 0)
				{
					Lighting.AddLight(new Vector2(((Entity)npc).Center.X - 36f, ((Entity)npc).position.Y + 24f), 1f, 0.95f, 0.8f);
					if (npc.ai[2] == 0f && Main.rand.Next(30) == 0)
					{
						Dust.NewDust(new Vector2(((Entity)npc).Center.X - 36f, ((Entity)npc).position.Y + 24f), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);
					}
				}
				else
				{
					Lighting.AddLight(new Vector2(((Entity)npc).Center.X + 28f, ((Entity)npc).position.Y + 24f), 1f, 0.95f, 0.8f);
					if (npc.ai[2] == 0f && Main.rand.Next(30) == 0)
					{
						Dust.NewDust(new Vector2(((Entity)npc).Center.X + 28f, ((Entity)npc).position.Y + 24f), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);
					}
				}
			}
			((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
		}
		bool flag5 = false;
		bool flag6 = false;
		if (((Entity)npc).velocity.X == 0f)
		{
			flag6 = true;
		}
		if (npc.justHit)
		{
			flag6 = false;
		}
		if (Main.netMode != 1 && npc.type == 198 && (double)npc.life <= (double)npc.lifeMax * 0.55)
		{
			npc.Transform(199);
		}
		if (Main.netMode != 1 && npc.type == 348 && (double)npc.life <= (double)npc.lifeMax * 0.55)
		{
			npc.Transform(349);
		}
		int num56 = 60;
		if (npc.type == 120)
		{
			num56 = 180;
			if (npc.ai[3] == -120f)
			{
				((Entity)npc).velocity = ((Entity)npc).velocity * 0f;
				npc.ai[3] = 0f;
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				SoundEngine.PlaySound(ref SoundID.Item8, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				Vector2 vector19 = default(Vector2);
				((Vector2)(ref vector19))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
				float num57 = npc.oldPos[2].X + (float)((Entity)npc).width * 0.5f - vector19.X;
				float num58 = npc.oldPos[2].Y + (float)((Entity)npc).height * 0.5f - vector19.Y;
				float num59 = (float)Math.Sqrt(num57 * num57 + num58 * num58);
				num59 = 2f / num59;
				num57 *= num59;
				num58 *= num59;
				for (int num60 = 0; num60 < 20; num60++)
				{
					int num61 = Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 71, num57, num58, 200, default(Color), 2f);
					Main.dust[num61].noGravity = true;
					Main.dust[num61].velocity.X *= 2f;
				}
				for (int num62 = 0; num62 < 20; num62++)
				{
					int num63 = Dust.NewDust(npc.oldPos[2], ((Entity)npc).width, ((Entity)npc).height, 71, 0f - num57, 0f - num58, 200, default(Color), 2f);
					Main.dust[num63].noGravity = true;
					Main.dust[num63].velocity.X *= 2f;
				}
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		bool flag7 = false;
		bool flag8 = true;
		int type = npc.type;
		if (type >= 494)
		{
			if (type >= 524)
			{
				if (type <= 527)
				{
					goto IL_3aac;
				}
				if (type <= 580)
				{
					if ((uint)(type - 528) <= 2u || type == 532 || type == 580)
					{
						goto IL_3aac;
					}
				}
				else if (type <= 591)
				{
					if (type == 582 || type == 591)
					{
						goto IL_3aac;
					}
				}
				else if (type == 624 || type == 631)
				{
					goto IL_3aac;
				}
			}
			else if (type <= 506 || type == 508 || type == 520)
			{
				goto IL_3aac;
			}
			goto IL_3ab1;
		}
		switch (type)
		{
		case 47:
		case 67:
		case 109:
		case 110:
		case 111:
		case 120:
		case 163:
		case 164:
		case 166:
		case 168:
		case 199:
		case 206:
		case 214:
		case 215:
		case 216:
		case 217:
		case 218:
		case 219:
		case 220:
		case 226:
		case 239:
		case 243:
		case 251:
		case 257:
		case 258:
		case 290:
		case 291:
		case 292:
		case 293:
		case 305:
		case 306:
		case 307:
		case 308:
		case 309:
		case 343:
		case 348:
		case 349:
		case 350:
		case 351:
		case 379:
		case 380:
		case 381:
		case 382:
		case 383:
		case 386:
		case 391:
		case 409:
		case 411:
		case 415:
		case 419:
		case 424:
		case 425:
		case 426:
		case 427:
		case 428:
		case 430:
		case 431:
		case 432:
		case 433:
		case 434:
		case 435:
		case 436:
		case 449:
		case 450:
		case 451:
		case 452:
		case 464:
		case 466:
		case 468:
		case 469:
		case 470:
		case 471:
		case 480:
		case 481:
		case 482:
			break;
		default:
			goto IL_3ab1;
		}
		goto IL_3aac;
		IL_d766:
		if (Main.netMode != 1 && npc.type == 120 && npc.ai[3] >= (float)num56)
		{
			int targetTileX = (int)((Entity)Main.player[npc.target]).Center.X / 16;
			int targetTileY = (int)((Entity)Main.player[npc.target]).Center.Y / 16;
			Vector2 chosenTile = Vector2.Zero;
			if (npc.AI_AttemptToFindTeleportSpot(ref chosenTile, targetTileX, targetTileY, 20, 9, 1, false, false))
			{
				((Entity)npc).position.X = chosenTile.X * 16f - (float)(((Entity)npc).width / 2);
				((Entity)npc).position.Y = chosenTile.Y * 16f - (float)((Entity)npc).height;
				npc.ai[3] = -120f;
				npc.netUpdate = true;
			}
		}
		return false;
		IL_3aac:
		bool flag9 = true;
		goto IL_3ab4;
		IL_3ab1:
		flag9 = false;
		goto IL_3ab4;
		IL_c31e:
		if (flag5)
		{
			int num194 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
			int num195 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 15f) / 16f);
			if (npc.type == 109 || npc.type == 163 || npc.type == 164 || npc.type == 199 || npc.type == 236 || npc.type == 239 || npc.type == 257 || npc.type == 258 || npc.type == 290 || npc.type == 391 || npc.type == 425 || npc.type == 427 || npc.type == 426 || npc.type == 580 || npc.type == 508 || npc.type == 415 || npc.type == 530 || npc.type == 532 || npc.type == 582)
			{
				num194 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)((((Entity)npc).width / 2 + 16) * ((Entity)npc).direction)) / 16f);
			}
			Tile tile = ((Tilemap)(ref Main.tile))[num194, num195 + 1];
			((Tile)(ref tile)).IsHalfBlock = false;
			val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
			int num196;
			if (((Tile)(ref val3)).HasUnactuatedTile)
			{
				if (!TileLoader.IsClosedDoor(((Tilemap)(ref Main.tile))[num194, num195 - 1]))
				{
					val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
					num196 = ((((Tile)(ref val3)).TileType == 388) ? 1 : 0);
				}
				else
				{
					num196 = 1;
				}
			}
			else
			{
				num196 = 0;
			}
			if (((uint)num196 & (flag8 ? 1u : 0u)) == 0)
			{
				int num197 = npc.spriteDirection;
				if (npc.type == 425)
				{
					num197 *= -1;
				}
				if ((((Entity)npc).velocity.X < 0f && num197 == -1) || (((Entity)npc).velocity.X > 0f && num197 == 1))
				{
					if (((Entity)npc).height >= 32)
					{
						val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 2];
						if (((Tile)(ref val3)).HasUnactuatedTile)
						{
							bool[] tileSolid2 = Main.tileSolid;
							val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 2];
							if (tileSolid2[((Tile)(ref val3)).TileType])
							{
								val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 3];
								if (((Tile)(ref val3)).HasUnactuatedTile)
								{
									bool[] tileSolid3 = Main.tileSolid;
									val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 3];
									if (tileSolid3[((Tile)(ref val3)).TileType])
									{
										((Entity)npc).velocity.Y = -8f;
										npc.netUpdate = true;
										goto IL_cebd;
									}
								}
								((Entity)npc).velocity.Y = -7f;
								npc.netUpdate = true;
								goto IL_cebd;
							}
						}
					}
					val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
					if (((Tile)(ref val3)).HasUnactuatedTile)
					{
						bool[] tileSolid4 = Main.tileSolid;
						val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
						if (tileSolid4[((Tile)(ref val3)).TileType])
						{
							if (npc.type == 624)
							{
								((Entity)npc).velocity.Y = -8f;
								int num198 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height) / 16;
								if (WorldGen.SolidTile((int)((Entity)npc).Center.X / 16, num198 - 8, false))
								{
									((Entity)npc).direction = ((Entity)npc).direction * -1;
									npc.spriteDirection = ((Entity)npc).direction;
									((Entity)npc).velocity.X = 3 * ((Entity)npc).direction;
								}
							}
							else
							{
								((Entity)npc).velocity.Y = -6f;
							}
							npc.netUpdate = true;
							goto IL_cebd;
						}
					}
					if (((Entity)npc).position.Y + (float)((Entity)npc).height - (float)(num195 * 16) > 20f)
					{
						val3 = ((Tilemap)(ref Main.tile))[num194, num195];
						if (((Tile)(ref val3)).HasUnactuatedTile)
						{
							val3 = ((Tilemap)(ref Main.tile))[num194, num195];
							if (!((Tile)(ref val3)).TopSlope)
							{
								bool[] tileSolid5 = Main.tileSolid;
								val3 = ((Tilemap)(ref Main.tile))[num194, num195];
								if (tileSolid5[((Tile)(ref val3)).TileType])
								{
									((Entity)npc).velocity.Y = -5f;
									npc.netUpdate = true;
									goto IL_cebd;
								}
							}
						}
					}
					if (npc.directionY >= 0 || npc.type == 67)
					{
						goto IL_ce9f;
					}
					val3 = ((Tilemap)(ref Main.tile))[num194, num195 + 1];
					if (((Tile)(ref val3)).HasUnactuatedTile)
					{
						bool[] tileSolid6 = Main.tileSolid;
						val3 = ((Tilemap)(ref Main.tile))[num194, num195 + 1];
						if (tileSolid6[((Tile)(ref val3)).TileType])
						{
							goto IL_ce9f;
						}
					}
					val3 = ((Tilemap)(ref Main.tile))[num194 + ((Entity)npc).direction, num195 + 1];
					if (((Tile)(ref val3)).HasUnactuatedTile)
					{
						bool[] tileSolid7 = Main.tileSolid;
						val3 = ((Tilemap)(ref Main.tile))[num194 + ((Entity)npc).direction, num195 + 1];
						if (tileSolid7[((Tile)(ref val3)).TileType])
						{
							goto IL_ce9f;
						}
					}
					((Entity)npc).velocity.Y = -8f;
					((Entity)npc).velocity.X *= 1.5f;
					npc.netUpdate = true;
					goto IL_cebd;
				}
				goto IL_d1bb;
			}
			npc.ai[2] += 1f;
			npc.ai[3] = 0f;
			if (npc.ai[2] >= 60f)
			{
				bool flag23 = npc.type == 3 || npc.type == 430 || npc.type == 590 || npc.type == 331 || npc.type == 332 || npc.type == 132 || npc.type == 161 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 200 || npc.type == 223 || npc.type == 320 || npc.type == 321 || npc.type == 319 || npc.type == 21 || npc.type == 324 || npc.type == 323 || npc.type == 322 || npc.type == 44 || npc.type == 196 || npc.type == 167 || npc.type == 77 || npc.type == 197 || npc.type == 202 || npc.type == 203 || npc.type == 449 || npc.type == 450 || npc.type == 451 || npc.type == 452 || npc.type == 481 || npc.type == 201 || npc.type == 635;
				bool flag24 = Main.player[npc.target].ZoneGraveyard && Main.rand.Next(60) == 0;
				if ((!Main.bloodMoon || Main.getGoodWorld) && !flag24 && flag23)
				{
					npc.ai[1] = 0f;
				}
				((Entity)npc).velocity.X = 0.5f * (float)(-((Entity)npc).direction);
				int num199 = 5;
				val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
				if (((Tile)(ref val3)).TileType == 388)
				{
					num199 = 2;
				}
				npc.ai[1] += num199;
				if (npc.type == 27)
				{
					npc.ai[1] += 1f;
				}
				if (npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296)
				{
					npc.ai[1] += 6f;
				}
				npc.ai[2] = 0f;
				bool flag25 = false;
				if (npc.ai[1] >= 10f)
				{
					flag25 = true;
					npc.ai[1] = 10f;
				}
				if (npc.type == 460)
				{
					flag25 = true;
				}
				WorldGen.KillTile(num194, num195 - 1, true, false, false);
				if ((Main.netMode != 1 || !flag25) && flag25 && Main.netMode != 1)
				{
					if (npc.type == 26)
					{
						WorldGen.KillTile(num194, num195 - 1, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(17, -1, -1, (NetworkText)null, 0, (float)num194, (float)(num195 - 1), 0f, 0, 0, 0);
						}
					}
					else
					{
						if (TileLoader.IsClosedDoor(((Tilemap)(ref Main.tile))[num194, num195 - 1]))
						{
							bool flag26 = WorldGen.OpenDoor(num194, num195 - 1, ((Entity)npc).direction);
							if (!flag26)
							{
								npc.ai[3] = num56;
								npc.netUpdate = true;
							}
							if (Main.netMode == 2 && flag26)
							{
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 0, (float)num194, (float)(num195 - 1), (float)((Entity)npc).direction, 0, 0, 0);
							}
						}
						val3 = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
						if (((Tile)(ref val3)).TileType == 388)
						{
							bool flag27 = WorldGen.ShiftTallGate(num194, num195 - 1, false, false);
							if (!flag27)
							{
								npc.ai[3] = num56;
								npc.netUpdate = true;
							}
							if (Main.netMode == 2 && flag27)
							{
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 4, (float)num194, (float)(num195 - 1), 0f, 0, 0, 0);
							}
						}
					}
				}
			}
		}
		else if (flag8)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
		goto IL_d766;
		IL_bf25:
		int num200;
		int num201;
		val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
		if (((Tile)(ref val3)).HasUnactuatedTile)
		{
			bool[] tileSolid8 = Main.tileSolid;
			val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
			if (tileSolid8[((Tile)(ref val3)).TileType])
			{
				bool[] tileSolidTop = Main.tileSolidTop;
				val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
				if (!tileSolidTop[((Tile)(ref val3)).TileType])
				{
					val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
					if (!((Tile)(ref val3)).IsHalfBlock)
					{
						goto IL_c31e;
					}
					val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 4];
					if (((Tile)(ref val3)).HasUnactuatedTile)
					{
						bool[] tileSolid9 = Main.tileSolid;
						val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 4];
						if (tileSolid9[((Tile)(ref val3)).TileType])
						{
							bool[] tileSolidTop2 = Main.tileSolidTop;
							val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 4];
							if (!tileSolidTop2[((Tile)(ref val3)).TileType])
							{
								goto IL_c31e;
							}
						}
					}
				}
			}
		}
		val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 2];
		if (((Tile)(ref val3)).HasUnactuatedTile)
		{
			bool[] tileSolid10 = Main.tileSolid;
			val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 2];
			if (tileSolid10[((Tile)(ref val3)).TileType])
			{
				bool[] tileSolidTop3 = Main.tileSolidTop;
				val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 2];
				if (!tileSolidTop3[((Tile)(ref val3)).TileType])
				{
					goto IL_c31e;
				}
			}
		}
		val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 3];
		if (((Tile)(ref val3)).HasUnactuatedTile)
		{
			bool[] tileSolid11 = Main.tileSolid;
			val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 3];
			if (tileSolid11[((Tile)(ref val3)).TileType])
			{
				bool[] tileSolidTop4 = Main.tileSolidTop;
				val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 3];
				if (!tileSolidTop4[((Tile)(ref val3)).TileType])
				{
					goto IL_c31e;
				}
			}
		}
		int num202;
		val3 = ((Tilemap)(ref Main.tile))[num200 - num202, num201 - 3];
		if (((Tile)(ref val3)).HasUnactuatedTile)
		{
			bool[] tileSolid12 = Main.tileSolid;
			val3 = ((Tilemap)(ref Main.tile))[num200 - num202, num201 - 3];
			if (tileSolid12[((Tile)(ref val3)).TileType])
			{
				goto IL_c31e;
			}
		}
		float num203 = num201 * 16;
		val3 = ((Tilemap)(ref Main.tile))[num200, num201];
		if (((Tile)(ref val3)).IsHalfBlock)
		{
			num203 += 8f;
		}
		val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
		if (((Tile)(ref val3)).IsHalfBlock)
		{
			num203 -= 8f;
		}
		Vector2 vector39;
		if (num203 < vector39.Y + (float)((Entity)npc).height)
		{
			float num204 = vector39.Y + (float)((Entity)npc).height - num203;
			float num205 = 16.1f;
			if (npc.type == 163 || npc.type == 164 || npc.type == 236 || npc.type == 239 || npc.type == 530)
			{
				num205 += 8f;
			}
			if (num204 <= num205)
			{
				npc.gfxOffY += ((Entity)npc).position.Y + (float)((Entity)npc).height - num203;
				((Entity)npc).position.Y = num203 - (float)((Entity)npc).height;
				if (num204 < 9f)
				{
					npc.stepSpeed = 1f;
				}
				else
				{
					npc.stepSpeed = 2f;
				}
			}
		}
		goto IL_c31e;
		IL_3ab4:
		if (flag9)
		{
			flag8 = false;
		}
		bool flag28 = false;
		int num206 = npc.type;
		if (num206 == 425 || num206 == 471)
		{
			flag28 = true;
		}
		bool flag29 = true;
		switch (npc.type)
		{
		case 110:
		case 111:
		case 206:
		case 214:
		case 215:
		case 216:
		case 291:
		case 292:
		case 293:
		case 350:
		case 379:
		case 380:
		case 381:
		case 382:
		case 409:
		case 411:
		case 424:
		case 426:
		case 466:
		case 498:
		case 499:
		case 500:
		case 501:
		case 502:
		case 503:
		case 504:
		case 505:
		case 506:
		case 520:
			if (npc.ai[2] > 0f)
			{
				flag29 = false;
			}
			break;
		}
		if (!flag28 && flag29)
		{
			if (((Entity)npc).velocity.Y == 0f && ((((Entity)npc).velocity.X > 0f && ((Entity)npc).direction < 0) || (((Entity)npc).velocity.X < 0f && ((Entity)npc).direction > 0)))
			{
				flag7 = true;
			}
			if (((Entity)npc).position.X == ((Entity)npc).oldPosition.X || npc.ai[3] >= (float)num56 || flag7)
			{
				npc.ai[3] += 1f;
			}
			else if ((double)Math.Abs(((Entity)npc).velocity.X) > 0.9 && npc.ai[3] > 0f)
			{
				npc.ai[3] -= 1f;
			}
			if (npc.ai[3] > (float)(num56 * 10))
			{
				npc.ai[3] = 0f;
			}
			if (npc.justHit)
			{
				npc.ai[3] = 0f;
			}
			if (npc.ai[3] == (float)num56)
			{
				npc.netUpdate = true;
			}
			hitbox = ((Entity)Main.player[npc.target]).Hitbox;
			if (((Rectangle)(ref hitbox)).Intersects(((Entity)npc).Hitbox))
			{
				npc.ai[3] = 0f;
			}
		}
		if (npc.type == 463 && Main.netMode != 1)
		{
			if (npc.localAI[3] > 0f)
			{
				npc.localAI[3] -= 1f;
			}
			if (npc.justHit && npc.localAI[3] <= 0f && Main.rand.Next(3) == 0)
			{
				npc.localAI[3] = 30f;
				int num207 = Main.rand.Next(3, 6);
				int[] array = new int[num207];
				int num208 = 0;
				for (int num209 = 0; num209 < 255; num209++)
				{
					if (((Entity)Main.player[num209]).active && !Main.player[num209].dead && Collision.CanHitLine(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[num209]).position, ((Entity)Main.player[num209]).width, ((Entity)Main.player[num209]).height))
					{
						array[num208] = num209;
						num208++;
						if (num208 == num207)
						{
							break;
						}
					}
				}
				if (num208 > 1)
				{
					for (int num210 = 0; num210 < 100; num210++)
					{
						int num211 = Main.rand.Next(num208);
						int num212;
						for (num212 = num211; num212 == num211; num212 = Main.rand.Next(num208))
						{
						}
						int num213 = array[num211];
						array[num211] = array[num212];
						array[num212] = num213;
					}
				}
				Vector2 vector40 = default(Vector2);
				((Vector2)(ref vector40))._002Ector(-1f, -1f);
				for (int num214 = 0; num214 < num208; num214++)
				{
					Vector2 vector41 = ((Entity)Main.npc[array[num214]]).Center - ((Entity)npc).Center;
					((Vector2)(ref vector41)).Normalize();
					vector40 += vector41;
				}
				((Vector2)(ref vector40)).Normalize();
				Vector2 vector42 = default(Vector2);
				for (int num215 = 0; num215 < num207; num215++)
				{
					float num216 = Main.rand.Next(8, 13);
					((Vector2)(ref vector42))._002Ector((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
					((Vector2)(ref vector42)).Normalize();
					if (num208 > 0)
					{
						vector42 += vector40;
						((Vector2)(ref vector42)).Normalize();
					}
					vector42 *= num216;
					if (num208 > 0)
					{
						num208--;
						vector42 = ((Entity)Main.player[array[num208]]).Center - ((Entity)npc).Center;
						((Vector2)(ref vector42)).Normalize();
						vector42 *= num216;
					}
					Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X, ((Entity)npc).position.Y + (float)(((Entity)npc).width / 4), vector42.X, vector42.Y, 498, (int)((double)npc.damage * 0.15), 1f, Main.myPlayer, 0f, 0f, 0f);
				}
			}
		}
		if (npc.type == 460)
		{
			if (((Entity)npc).velocity.Y < 0f - npc.gravity || ((Entity)npc).velocity.Y > npc.gravity)
			{
				npc.knockBackResist = 0f;
			}
			else
			{
				gameModeInfo = Main.GameModeInfo;
				npc.knockBackResist = 0.25f * ((GameModeData)(ref gameModeInfo)).KnockbackToEnemiesMultiplier;
			}
		}
		if (npc.type == 469)
		{
			gameModeInfo = Main.GameModeInfo;
			npc.knockBackResist = 0.45f * ((GameModeData)(ref gameModeInfo)).KnockbackToEnemiesMultiplier;
			if (npc.ai[2] == 1f)
			{
				npc.knockBackResist = 0f;
			}
			bool flag30 = false;
			int num217 = (int)((Entity)npc).Center.X / 16;
			int num218 = (int)((Entity)npc).Center.Y / 16;
			for (int num219 = num217 - 1; num219 <= num217 + 1; num219++)
			{
				for (int num220 = num218 - 1; num220 <= num218 + 1; num220++)
				{
					val3 = ((Tilemap)(ref Main.tile))[num219, num220];
					if (((Tile)(ref val3)).WallType > 0)
					{
						flag30 = true;
						break;
					}
				}
				if (flag30)
				{
					break;
				}
			}
			if (npc.ai[2] == 0f && flag30)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					flag = true;
					((Entity)npc).velocity.Y = -4.6f;
					((Entity)npc).velocity.X *= 1.3f;
				}
				else if (((Entity)npc).velocity.Y > 0f && !Main.player[npc.target].dead)
				{
					npc.ai[2] = 1f;
				}
			}
			if (flag30 && npc.ai[2] == 1f && !Main.player[npc.target].dead && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
			{
				Vector2 vector43 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
				float num221 = ((Vector2)(ref vector43)).Length();
				((Vector2)(ref vector43)).Normalize();
				vector43 *= 4.5f + num221 / 300f;
				((Entity)npc).velocity = (((Entity)npc).velocity * 29f + vector43) / 30f;
				npc.noGravity = true;
				npc.ai[2] = 1f;
				return false;
			}
			npc.noGravity = false;
			npc.ai[2] = 0f;
		}
		if (npc.type == 462 && ((Entity)npc).velocity.Y == 0f)
		{
			val2 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
			if (((Vector2)(ref val2)).Length() < 150f && Math.Abs(((Entity)npc).velocity.X) > 3f && ((((Entity)npc).velocity.X < 0f && ((Entity)npc).Center.X > ((Entity)Main.player[npc.target]).Center.X) || (((Entity)npc).velocity.X > 0f && ((Entity)npc).Center.X < ((Entity)Main.player[npc.target]).Center.X)))
			{
				flag = true;
				((Entity)npc).velocity.X *= 1.75f;
				((Entity)npc).velocity.Y -= 4.5f;
				if (((Entity)npc).Center.Y - ((Entity)Main.player[npc.target]).Center.Y > 20f)
				{
					((Entity)npc).velocity.Y -= 0.5f;
				}
				if (((Entity)npc).Center.Y - ((Entity)Main.player[npc.target]).Center.Y > 40f)
				{
					((Entity)npc).velocity.Y -= 1f;
				}
				if (((Entity)npc).Center.Y - ((Entity)Main.player[npc.target]).Center.Y > 80f)
				{
					((Entity)npc).velocity.Y -= 1.5f;
				}
				if (((Entity)npc).Center.Y - ((Entity)Main.player[npc.target]).Center.Y > 100f)
				{
					((Entity)npc).velocity.Y -= 1.5f;
				}
				if (Math.Abs(((Entity)npc).velocity.X) > 7f)
				{
					if (((Entity)npc).velocity.X < 0f)
					{
						((Entity)npc).velocity.X = -7f;
					}
					else
					{
						((Entity)npc).velocity.X = 7f;
					}
				}
			}
		}
		if (npc.type == 624 && npc.target < 255)
		{
			if (!Main.remixWorld && !Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				npc.ai[3] = num56;
				npc.directionY = -1;
				if (npc.type == 624 && !npc.AI_003_Gnomes_ShouldTurnToStone())
				{
					val2 = ((Entity)npc).Center - ((Entity)Main.player[npc.target]).Center;
					if (((Vector2)(ref val2)).Length() > 500f)
					{
						((Entity)npc).velocity.X *= 0.95f;
						if ((double)((Entity)npc).velocity.X > -0.1 && (double)((Entity)npc).velocity.X < 0.1)
						{
							((Entity)npc).velocity.X = 0f;
						}
						return false;
					}
				}
			}
			else if (((Entity)Main.player[npc.target]).Center.Y > ((Entity)npc).Center.Y - 128f)
			{
				npc.ai[3] = 0f;
			}
		}
		if (npc.ai[3] < (float)num56 && NPC.DespawnEncouragement_AIStyle3_Fighters_NotDiscouraged(npc.type, ((Entity)npc).position, npc))
		{
			if (npc.shimmerTransparency < 1f)
			{
				if ((npc.type == 3 || npc.type == 591 || npc.type == 590 || npc.type == 331 || npc.type == 332 || npc.type == 21 || (npc.type >= 449 && npc.type <= 452) || npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 77 || npc.type == 110 || npc.type == 132 || npc.type == 167 || npc.type == 161 || npc.type == 162 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 197 || npc.type == 200 || npc.type == 201 || npc.type == 202 || npc.type == 203 || npc.type == 223 || npc.type == 291 || npc.type == 292 || npc.type == 293 || npc.type == 320 || npc.type == 321 || npc.type == 319 || npc.type == 481 || npc.type == 632 || npc.type == 635) && Main.rand.Next(1000) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.ZombieMoan, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if ((npc.type == 489 || npc.type == 586) && Main.rand.Next(800) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.BloodZombie, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if ((npc.type == 78 || npc.type == 79 || npc.type == 80 || npc.type == 630) && Main.rand.Next(500) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.Mummy, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if (npc.type == 159 && Main.rand.Next(500) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.Zombie7, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if (npc.type == 162 && Main.rand.Next(500) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.Zombie6, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if (npc.type == 181 && Main.rand.Next(500) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.Zombie8, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
				if (npc.type >= 269 && npc.type <= 280 && Main.rand.Next(1000) == 0)
				{
					SoundEngine.PlaySound(ref SoundID.ZombieMoan, (Vector2?)((Entity)npc).position, (SoundUpdateCallback)null);
				}
			}
			npc.TargetClosest(true);
			if (npc.directionY > 0 && ((Entity)Main.player[npc.target]).Center.Y <= ((Entity)npc).Bottom.Y)
			{
				npc.directionY = -1;
			}
		}
		else if (!(npc.ai[2] > 0f) || !NPC.DespawnEncouragement_AIStyle3_Fighters_CanBeBusyWithAction(npc.type))
		{
			if (Main.IsItDay() && (double)(((Entity)npc).position.Y / 16f) < Main.worldSurface && npc.type != 624 && npc.type != 631)
			{
				npc.EncourageDespawn(10);
			}
			if (((Entity)npc).velocity.X == 0f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] += 1f;
					if (npc.ai[0] >= 2f)
					{
						((Entity)npc).direction = ((Entity)npc).direction * -1;
						npc.spriteDirection = ((Entity)npc).direction;
						npc.ai[0] = 0f;
					}
				}
			}
			else
			{
				npc.ai[0] = 0f;
			}
			if (((Entity)npc).direction == 0)
			{
				((Entity)npc).direction = 1;
			}
		}
		if (npc.type == 159 || npc.type == 349)
		{
			if (npc.type == 159 && ((((Entity)npc).velocity.X > 0f && ((Entity)npc).direction < 0) || (((Entity)npc).velocity.X < 0f && ((Entity)npc).direction > 0)))
			{
				((Entity)npc).velocity.X *= 0.95f;
			}
			if (((Entity)npc).velocity.X < -6f || ((Entity)npc).velocity.X > 6f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < 6f && ((Entity)npc).direction == 1)
			{
				if (((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).velocity.X *= 0.99f;
				}
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > 6f)
				{
					((Entity)npc).velocity.X = 6f;
				}
			}
			else if (((Entity)npc).velocity.X > -6f && ((Entity)npc).direction == -1)
			{
				if (((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).velocity.X *= 0.99f;
				}
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < -6f)
				{
					((Entity)npc).velocity.X = -6f;
				}
			}
		}
		else if (npc.type == 199)
		{
			if (((Entity)npc).velocity.X < -4f || ((Entity)npc).velocity.X > 4f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < 4f && ((Entity)npc).direction == 1)
			{
				if (((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).velocity.X *= 0.8f;
				}
				((Entity)npc).velocity.X += 0.1f;
				if (((Entity)npc).velocity.X > 4f)
				{
					((Entity)npc).velocity.X = 4f;
				}
			}
			else if (((Entity)npc).velocity.X > -4f && ((Entity)npc).direction == -1)
			{
				if (((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).velocity.X *= 0.8f;
				}
				((Entity)npc).velocity.X -= 0.1f;
				if (((Entity)npc).velocity.X < -4f)
				{
					((Entity)npc).velocity.X = -4f;
				}
			}
		}
		else if (npc.type == 120 || npc.type == 166 || npc.type == 213 || npc.type == 258 || npc.type == 528 || npc.type == 529)
		{
			if (((Entity)npc).velocity.X < -3f || ((Entity)npc).velocity.X > 3f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < 3f && ((Entity)npc).direction == 1)
			{
				if (((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).velocity.X *= 0.99f;
				}
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > 3f)
				{
					((Entity)npc).velocity.X = 3f;
				}
			}
			else if (((Entity)npc).velocity.X > -3f && ((Entity)npc).direction == -1)
			{
				if (((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).velocity.X *= 0.99f;
				}
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < -3f)
				{
					((Entity)npc).velocity.X = -3f;
				}
			}
		}
		else if (npc.type == 461 || npc.type == 27 || npc.type == 77 || npc.type == 104 || npc.type == 163 || npc.type == 162 || npc.type == 196 || npc.type == 197 || npc.type == 212 || npc.type == 257 || npc.type == 326 || npc.type == 343 || npc.type == 348 || npc.type == 351 || (npc.type >= 524 && npc.type <= 527) || npc.type == 530 || npc.type == 236)
		{
			if (((Entity)npc).velocity.X < -2f || ((Entity)npc).velocity.X > 2f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < 2f && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > 2f)
				{
					((Entity)npc).velocity.X = 2f;
				}
			}
			else if (((Entity)npc).velocity.X > -2f && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < -2f)
				{
					((Entity)npc).velocity.X = -2f;
				}
			}
		}
		else if (npc.type == 109)
		{
			if (((Entity)npc).velocity.X < -2f || ((Entity)npc).velocity.X > 2f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < 2f && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += 0.04f;
				if (((Entity)npc).velocity.X > 2f)
				{
					((Entity)npc).velocity.X = 2f;
				}
			}
			else if (((Entity)npc).velocity.X > -2f && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= 0.04f;
				if (((Entity)npc).velocity.X < -2f)
				{
					((Entity)npc).velocity.X = -2f;
				}
			}
		}
		else if (npc.type == 21 || npc.type == 26 || npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 47 || npc.type == 73 || npc.type == 140 || npc.type == 164 || npc.type == 239 || npc.type == 167 || npc.type == 168 || npc.type == 185 || npc.type == 198 || npc.type == 201 || npc.type == 202 || npc.type == 203 || npc.type == 217 || npc.type == 218 || npc.type == 219 || npc.type == 226 || npc.type == 181 || npc.type == 254 || npc.type == 338 || npc.type == 339 || npc.type == 340 || npc.type == 342 || npc.type == 385 || npc.type == 389 || npc.type == 462 || npc.type == 463 || npc.type == 466 || npc.type == 464 || npc.type == 469 || npc.type == 470 || npc.type == 480 || npc.type == 482 || npc.type == 425 || npc.type == 429 || npc.type == 586 || npc.type == 631 || npc.type == 635)
		{
			float num222 = 1.5f;
			if (npc.type == 181 && Main.remixWorld)
			{
				num222 = 3.75f;
			}
			else if (npc.type == 294)
			{
				num222 = 2f;
			}
			else if (npc.type == 295)
			{
				num222 = 1.75f;
			}
			else if (npc.type == 296)
			{
				num222 = 1.25f;
			}
			else if (npc.type == 201)
			{
				num222 = 1.1f;
			}
			else if (npc.type == 202)
			{
				num222 = 0.9f;
			}
			else if (npc.type == 203)
			{
				num222 = 1.2f;
			}
			else if (npc.type == 338)
			{
				num222 = 1.75f;
			}
			else if (npc.type == 339)
			{
				num222 = 1.25f;
			}
			else if (npc.type == 340)
			{
				num222 = 2f;
			}
			else if (npc.type == 385)
			{
				num222 = 1.8f;
			}
			else if (npc.type == 389)
			{
				num222 = 2.25f;
			}
			else if (npc.type == 462)
			{
				num222 = 4f;
			}
			else if (npc.type == 463)
			{
				num222 = 0.75f;
			}
			else if (npc.type == 466)
			{
				num222 = 3.75f;
			}
			else if (npc.type == 469)
			{
				num222 = 3.25f;
			}
			else if (npc.type == 480)
			{
				num222 = 1.5f + (1f - (float)npc.life / (float)npc.lifeMax) * 2f;
			}
			else if (npc.type == 425)
			{
				num222 = 6f;
			}
			else if (npc.type == 429)
			{
				num222 = 4f;
			}
			else if (npc.type == 631)
			{
				num222 = 0.9f;
			}
			else if (npc.type == 586)
			{
				num222 = 1.5f + (1f - (float)npc.life / (float)npc.lifeMax) * 3.5f;
			}
			if (npc.type == 21 || npc.type == 201 || npc.type == 202 || npc.type == 203 || npc.type == 342 || npc.type == 635)
			{
				num222 *= 1f + (1f - npc.scale);
			}
			if (((Entity)npc).velocity.X < 0f - num222 || ((Entity)npc).velocity.X > num222)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < num222 && ((Entity)npc).direction == 1)
			{
				if (npc.type == 466 && ((Entity)npc).velocity.X < -2f)
				{
					((Entity)npc).velocity.X *= 0.9f;
				}
				if (npc.type == 586 && ((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X < -1f)
				{
					((Entity)npc).velocity.X *= 0.9f;
				}
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > num222)
				{
					((Entity)npc).velocity.X = num222;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num222 && ((Entity)npc).direction == -1)
			{
				if (npc.type == 466 && ((Entity)npc).velocity.X > 2f)
				{
					((Entity)npc).velocity.X *= 0.9f;
				}
				if (npc.type == 586 && ((Entity)npc).velocity.Y == 0f && ((Entity)npc).velocity.X > 1f)
				{
					((Entity)npc).velocity.X *= 0.9f;
				}
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < 0f - num222)
				{
					((Entity)npc).velocity.X = 0f - num222;
				}
			}
			if (((Entity)npc).velocity.Y == 0f && npc.type == 462 && ((((Entity)npc).direction > 0 && ((Entity)npc).velocity.X < 0f) || (((Entity)npc).direction < 0 && ((Entity)npc).velocity.X > 0f)))
			{
				((Entity)npc).velocity.X *= 0.9f;
			}
		}
		else if (npc.type >= 269 && npc.type <= 280)
		{
			float num223 = 1.5f;
			if (npc.type == 269)
			{
				num223 = 2f;
			}
			if (npc.type == 270)
			{
				num223 = 1f;
			}
			if (npc.type == 271)
			{
				num223 = 1.5f;
			}
			if (npc.type == 272)
			{
				num223 = 3f;
			}
			if (npc.type == 273)
			{
				num223 = 1.25f;
			}
			if (npc.type == 274)
			{
				num223 = 3f;
			}
			if (npc.type == 275)
			{
				num223 = 3.25f;
			}
			if (npc.type == 276)
			{
				num223 = 2f;
			}
			if (npc.type == 277)
			{
				num223 = 2.75f;
			}
			if (npc.type == 278)
			{
				num223 = 1.8f;
			}
			if (npc.type == 279)
			{
				num223 = 1.3f;
			}
			if (npc.type == 280)
			{
				num223 = 2.5f;
			}
			num223 *= 1f + (1f - npc.scale);
			if (((Entity)npc).velocity.X < 0f - num223 || ((Entity)npc).velocity.X > num223)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < num223 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > num223)
				{
					((Entity)npc).velocity.X = num223;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num223 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < 0f - num223)
				{
					((Entity)npc).velocity.X = 0f - num223;
				}
			}
		}
		else if (npc.type >= 305 && npc.type <= 314)
		{
			float num224 = 1.5f;
			if (npc.type == 305 || npc.type == 310)
			{
				num224 = 2f;
			}
			if (npc.type == 306 || npc.type == 311)
			{
				num224 = 1.25f;
			}
			if (npc.type == 307 || npc.type == 312)
			{
				num224 = 2.25f;
			}
			if (npc.type == 308 || npc.type == 313)
			{
				num224 = 1.5f;
			}
			if (npc.type == 309 || npc.type == 314)
			{
				num224 = 1f;
			}
			if (npc.type < 310)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity.X *= 0.85f;
					if ((double)((Entity)npc).velocity.X > -0.3 && (double)((Entity)npc).velocity.X < 0.3)
					{
						flag = true;
						((Entity)npc).velocity.Y = -7f;
						((Entity)npc).velocity.X = num224 * (float)((Entity)npc).direction;
					}
				}
				else if (npc.spriteDirection == ((Entity)npc).direction)
				{
					((Entity)npc).velocity.X = (((Entity)npc).velocity.X * 10f + num224 * (float)((Entity)npc).direction) / 11f;
				}
			}
			else if (((Entity)npc).velocity.X < 0f - num224 || ((Entity)npc).velocity.X > num224)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < num224 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > num224)
				{
					((Entity)npc).velocity.X = num224;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num224 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < 0f - num224)
				{
					((Entity)npc).velocity.X = 0f - num224;
				}
			}
		}
		else if (npc.type == 67 || npc.type == 220 || npc.type == 428)
		{
			if (((Entity)npc).velocity.X < -0.5f || ((Entity)npc).velocity.X > 0.5f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else if (((Entity)npc).velocity.X < 0.5f && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += 0.03f;
				if (((Entity)npc).velocity.X > 0.5f)
				{
					((Entity)npc).velocity.X = 0.5f;
				}
			}
			else if (((Entity)npc).velocity.X > -0.5f && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= 0.03f;
				if (((Entity)npc).velocity.X < -0.5f)
				{
					((Entity)npc).velocity.X = -0.5f;
				}
			}
		}
		else if (npc.type == 78 || npc.type == 79 || npc.type == 80 || npc.type == 630)
		{
			float num225 = 1f;
			float num226 = 0.05f;
			if (npc.life < npc.lifeMax / 2)
			{
				num225 = 2f;
				num226 = 0.1f;
			}
			if (npc.type == 79 || npc.type == 630)
			{
				num225 *= 1.5f;
			}
			if (((Entity)npc).velocity.X < 0f - num225 || ((Entity)npc).velocity.X > num225)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else if (((Entity)npc).velocity.X < num225 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += num226;
				if (((Entity)npc).velocity.X > num225)
				{
					((Entity)npc).velocity.X = num225;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num225 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= num226;
				if (((Entity)npc).velocity.X < 0f - num225)
				{
					((Entity)npc).velocity.X = 0f - num225;
				}
			}
		}
		else if (npc.type == 287)
		{
			float num227 = 5f;
			float num228 = 0.2f;
			if (((Entity)npc).velocity.X < 0f - num227 || ((Entity)npc).velocity.X > num227)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else if (((Entity)npc).velocity.X < num227 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += num228;
				if (((Entity)npc).velocity.X > num227)
				{
					((Entity)npc).velocity.X = num227;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num227 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= num228;
				if (((Entity)npc).velocity.X < 0f - num227)
				{
					((Entity)npc).velocity.X = 0f - num227;
				}
			}
		}
		else if (npc.type == 243)
		{
			float num229 = 1f;
			float num230 = 0.07f;
			num229 += (1f - (float)npc.life / (float)npc.lifeMax) * 1.5f;
			num230 += (1f - (float)npc.life / (float)npc.lifeMax) * 0.15f;
			if (((Entity)npc).velocity.X < 0f - num229 || ((Entity)npc).velocity.X > num229)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else if (((Entity)npc).velocity.X < num229 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += num230;
				if (((Entity)npc).velocity.X > num229)
				{
					((Entity)npc).velocity.X = num229;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num229 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= num230;
				if (((Entity)npc).velocity.X < 0f - num229)
				{
					((Entity)npc).velocity.X = 0f - num229;
				}
			}
		}
		else if (npc.type == 251)
		{
			float num231 = 1f;
			float num232 = 0.08f;
			num231 += (1f - (float)npc.life / (float)npc.lifeMax) * 2f;
			num232 += (1f - (float)npc.life / (float)npc.lifeMax) * 0.2f;
			if (((Entity)npc).velocity.X < 0f - num231 || ((Entity)npc).velocity.X > num231)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else if (((Entity)npc).velocity.X < num231 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += num232;
				if (((Entity)npc).velocity.X > num231)
				{
					((Entity)npc).velocity.X = num231;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num231 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= num232;
				if (((Entity)npc).velocity.X < 0f - num231)
				{
					((Entity)npc).velocity.X = 0f - num231;
				}
			}
		}
		else if (npc.type == 386)
		{
			if (npc.ai[2] > 0f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity.X *= 0.8f;
				}
			}
			else
			{
				float num233 = 0.15f;
				float num234 = 1.5f;
				if (((Entity)npc).velocity.X < 0f - num234 || ((Entity)npc).velocity.X > num234)
				{
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
					}
				}
				else if (((Entity)npc).velocity.X < num234 && ((Entity)npc).direction == 1)
				{
					((Entity)npc).velocity.X += num233;
					if (((Entity)npc).velocity.X > num234)
					{
						((Entity)npc).velocity.X = num234;
					}
				}
				else if (((Entity)npc).velocity.X > 0f - num234 && ((Entity)npc).direction == -1)
				{
					((Entity)npc).velocity.X -= num233;
					if (((Entity)npc).velocity.X < 0f - num234)
					{
						((Entity)npc).velocity.X = 0f - num234;
					}
				}
			}
		}
		else if (npc.type == 460)
		{
			float num235 = 3f;
			float num236 = 0.1f;
			if (Math.Abs(((Entity)npc).velocity.X) > 2f)
			{
				num236 *= 0.8f;
			}
			if ((double)Math.Abs(((Entity)npc).velocity.X) > 2.5)
			{
				num236 *= 0.8f;
			}
			if (Math.Abs(((Entity)npc).velocity.X) > 3f)
			{
				num236 *= 0.8f;
			}
			if ((double)Math.Abs(((Entity)npc).velocity.X) > 3.5)
			{
				num236 *= 0.8f;
			}
			if (Math.Abs(((Entity)npc).velocity.X) > 4f)
			{
				num236 *= 0.8f;
			}
			if ((double)Math.Abs(((Entity)npc).velocity.X) > 4.5)
			{
				num236 *= 0.8f;
			}
			if (Math.Abs(((Entity)npc).velocity.X) > 5f)
			{
				num236 *= 0.8f;
			}
			if ((double)Math.Abs(((Entity)npc).velocity.X) > 5.5)
			{
				num236 *= 0.8f;
			}
			num235 += (1f - (float)npc.life / (float)npc.lifeMax) * 3f;
			if (((Entity)npc).velocity.X < 0f - num235 || ((Entity)npc).velocity.X > num235)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else if (((Entity)npc).velocity.X < num235 && ((Entity)npc).direction == 1)
			{
				if (((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).velocity.X *= 0.93f;
				}
				((Entity)npc).velocity.X += num236;
				if (((Entity)npc).velocity.X > num235)
				{
					((Entity)npc).velocity.X = num235;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num235 && ((Entity)npc).direction == -1)
			{
				if (((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).velocity.X *= 0.93f;
				}
				((Entity)npc).velocity.X -= num236;
				if (((Entity)npc).velocity.X < 0f - num235)
				{
					((Entity)npc).velocity.X = 0f - num235;
				}
			}
		}
		else if (npc.type == 508 || npc.type == 580 || npc.type == 582)
		{
			float num237 = 2.5f;
			float num238 = 10f;
			float num239 = Math.Abs(((Entity)npc).velocity.X);
			if (npc.type == 582)
			{
				num237 = 2.25f;
				num238 = 7f;
				if (num239 > 2.5f)
				{
					num237 = 3f;
					num238 += 75f;
				}
				else if (num239 > 2f)
				{
					num237 = 2.75f;
					num238 += 55f;
				}
			}
			else if (num239 > 2.75f)
			{
				num237 = 3.5f;
				num238 += 80f;
			}
			else if ((double)num239 > 2.25)
			{
				num237 = 3f;
				num238 += 60f;
			}
			if ((double)Math.Abs(((Entity)npc).velocity.Y) < 0.5)
			{
				if (((Entity)npc).velocity.X > 0f && ((Entity)npc).direction < 0)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.95f;
				}
				if (((Entity)npc).velocity.X < 0f && ((Entity)npc).direction > 0)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.95f;
				}
			}
			if (Math.Abs(((Entity)npc).velocity.Y) > npc.gravity)
			{
				float num240 = 3f;
				if (npc.type == 582)
				{
					num240 = 2f;
				}
				num238 *= num240;
			}
			if (((Entity)npc).velocity.X <= 0f && ((Entity)npc).direction < 0)
			{
				((Entity)npc).velocity.X = (((Entity)npc).velocity.X * num238 - num237) / (num238 + 1f);
			}
			else if (((Entity)npc).velocity.X >= 0f && ((Entity)npc).direction > 0)
			{
				((Entity)npc).velocity.X = (((Entity)npc).velocity.X * num238 + num237) / (num238 + 1f);
			}
			else if (Math.Abs(((Entity)npc).Center.X - ((Entity)Main.player[npc.target]).Center.X) > 20f && Math.Abs(((Entity)npc).velocity.Y) <= npc.gravity)
			{
				((Entity)npc).velocity.X *= 0.99f;
				((Entity)npc).velocity.X += (float)((Entity)npc).direction * 0.025f;
			}
		}
		else if (npc.type == 391 || npc.type == 427 || npc.type == 415 || npc.type == 419 || npc.type == 518 || npc.type == 532)
		{
			float num241 = 5f;
			float num242 = 0.25f;
			float num243 = 0.7f;
			if (npc.type == 427)
			{
				num241 = 6f;
				num242 = 0.2f;
				num243 = 0.8f;
			}
			else if (npc.type == 415)
			{
				num241 = 4f;
				num242 = 0.1f;
				num243 = 0.95f;
			}
			else if (npc.type == 419)
			{
				num241 = 6f;
				num242 = 0.15f;
				num243 = 0.85f;
			}
			else if (npc.type == 518)
			{
				num241 = 5f;
				num242 = 0.1f;
				num243 = 0.95f;
			}
			else if (npc.type == 532)
			{
				num241 = 5f;
				num242 = 0.15f;
				num243 = 0.98f;
			}
			if (((Entity)npc).velocity.X < 0f - num241 || ((Entity)npc).velocity.X > num241)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * num243;
				}
			}
			else if (((Entity)npc).velocity.X < num241 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += num242;
				if (((Entity)npc).velocity.X > num241)
				{
					((Entity)npc).velocity.X = num241;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num241 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= num242;
				if (((Entity)npc).velocity.X < 0f - num241)
				{
					((Entity)npc).velocity.X = 0f - num241;
				}
			}
		}
		else if ((npc.type >= 430 && npc.type <= 436) || npc.type == 494 || npc.type == 495 || npc.type == 591)
		{
			if (npc.ai[2] == 0f)
			{
				npc.damage = npc.defDamage;
				float num244 = 1f;
				num244 *= 1f + (1f - npc.scale);
				if (((Entity)npc).velocity.X < 0f - num244 || ((Entity)npc).velocity.X > num244)
				{
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
					}
				}
				else if (((Entity)npc).velocity.X < num244 && ((Entity)npc).direction == 1)
				{
					((Entity)npc).velocity.X += 0.07f;
					if (((Entity)npc).velocity.X > num244)
					{
						((Entity)npc).velocity.X = num244;
					}
				}
				else if (((Entity)npc).velocity.X > 0f - num244 && ((Entity)npc).direction == -1)
				{
					((Entity)npc).velocity.X -= 0.07f;
					if (((Entity)npc).velocity.X < 0f - num244)
					{
						((Entity)npc).velocity.X = 0f - num244;
					}
				}
				if (((Entity)npc).velocity.Y == 0f && (!Main.IsItDay() || (double)((Entity)npc).position.Y > Main.worldSurface * 16.0) && !Main.player[npc.target].dead)
				{
					Vector2 vector44 = ((Entity)npc).Center - ((Entity)Main.player[npc.target]).Center;
					int num245 = 50;
					if (npc.type >= 494 && npc.type <= 495)
					{
						num245 = 42;
					}
					if (((Vector2)(ref vector44)).Length() < (float)num245 && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
					{
						((Entity)npc).velocity.X *= 0.7f;
						npc.ai[2] = 1f;
					}
				}
			}
			else
			{
				npc.damage = (int)((double)npc.defDamage * 1.5);
				npc.ai[3] = 1f;
				((Entity)npc).velocity.X *= 0.9f;
				if ((double)Math.Abs(((Entity)npc).velocity.X) < 0.1)
				{
					((Entity)npc).velocity.X = 0f;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= 20f || ((Entity)npc).velocity.Y != 0f || (Main.IsItDay() && (double)((Entity)npc).position.Y < Main.worldSurface * 16.0))
				{
					npc.ai[2] = 0f;
				}
			}
		}
		else if (npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 214 && npc.type != 215 && npc.type != 216 && npc.type != 290 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350 && npc.type != 379 && npc.type != 380 && npc.type != 381 && npc.type != 382 && (npc.type < 449 || npc.type > 452) && npc.type != 468 && npc.type != 481 && npc.type != 411 && npc.type != 409 && (npc.type < 498 || npc.type > 506) && npc.type != 424 && npc.type != 426 && npc.type != 520)
		{
			float num246 = 1f;
			if (npc.type == 624)
			{
				num246 = 2.5f;
			}
			if (npc.type == 186)
			{
				num246 = 1.1f;
			}
			if (npc.type == 187)
			{
				num246 = 0.9f;
			}
			if (npc.type == 188)
			{
				num246 = 1.2f;
			}
			if (npc.type == 189)
			{
				num246 = 0.8f;
			}
			if (npc.type == 132)
			{
				num246 = 0.95f;
			}
			if (npc.type == 200)
			{
				num246 = 0.87f;
			}
			if (npc.type == 223)
			{
				num246 = 1.05f;
			}
			if (npc.type == 632)
			{
				num246 = 0.8f;
			}
			if (npc.type == 489)
			{
				val2 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
				float num247 = ((Vector2)(ref val2)).Length();
				num247 *= 0.0025f;
				if ((double)num247 > 1.5)
				{
					num247 = 1.5f;
				}
				num246 = ((!Main.expertMode) ? (2.5f - num247) : (3f - num247));
				num246 *= 0.8f;
			}
			if (npc.type == 489 || npc.type == 3 || npc.type == 132 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 200 || npc.type == 223 || npc.type == 331 || npc.type == 332)
			{
				num246 *= 1f + (1f - npc.scale);
			}
			if (((Entity)npc).velocity.X < 0f - num246 || ((Entity)npc).velocity.X > num246)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
				}
			}
			else if (((Entity)npc).velocity.X < num246 && ((Entity)npc).direction == 1)
			{
				((Entity)npc).velocity.X += 0.07f;
				if (((Entity)npc).velocity.X > num246)
				{
					((Entity)npc).velocity.X = num246;
				}
			}
			else if (((Entity)npc).velocity.X > 0f - num246 && ((Entity)npc).direction == -1)
			{
				((Entity)npc).velocity.X -= 0.07f;
				if (((Entity)npc).velocity.X < 0f - num246)
				{
					((Entity)npc).velocity.X = 0f - num246;
				}
			}
		}
		if (npc.type >= 277 && npc.type <= 280)
		{
			Lighting.AddLight((int)((Entity)npc).Center.X / 16, (int)((Entity)npc).Center.Y / 16, 0.2f, 0.1f, 0f);
		}
		else if (npc.type == 520)
		{
			Lighting.AddLight(((Entity)npc).Top + new Vector2(0f, 20f), 0.3f, 0.3f, 0.7f);
		}
		else if (npc.type == 525)
		{
			Vector3 rgb = new Vector3(0.7f, 1f, 0.2f) * 0.5f;
			Lighting.AddLight(((Entity)npc).Top + new Vector2(0f, 15f), rgb);
		}
		else if (npc.type == 526)
		{
			Vector3 rgb2 = new Vector3(1f, 1f, 0.5f) * 0.4f;
			Lighting.AddLight(((Entity)npc).Top + new Vector2(0f, 15f), rgb2);
		}
		else if (npc.type == 527)
		{
			Vector3 rgb3 = new Vector3(0.6f, 0.3f, 1f) * 0.4f;
			Lighting.AddLight(((Entity)npc).Top + new Vector2(0f, 15f), rgb3);
		}
		else if (npc.type == 415)
		{
			npc.hide = false;
			for (int num248 = 0; num248 < 200; num248++)
			{
				if (((Entity)Main.npc[num248]).active && Main.npc[num248].type == 416 && Main.npc[num248].ai[0] == (float)((Entity)npc).whoAmI)
				{
					npc.hide = true;
					break;
				}
			}
		}
		else if (npc.type == 258)
		{
			if (((Entity)npc).velocity.Y != 0f)
			{
				npc.TargetClosest(true);
				npc.spriteDirection = ((Entity)npc).direction;
				if (((Entity)Main.player[npc.target]).Center.X < ((Entity)npc).position.X && ((Entity)npc).velocity.X > 0f)
				{
					((Entity)npc).velocity.X *= 0.95f;
				}
				else if (((Entity)Main.player[npc.target]).Center.X > ((Entity)npc).position.X + (float)((Entity)npc).width && ((Entity)npc).velocity.X < 0f)
				{
					((Entity)npc).velocity.X *= 0.95f;
				}
				if (((Entity)Main.player[npc.target]).Center.X < ((Entity)npc).position.X && ((Entity)npc).velocity.X > -5f)
				{
					((Entity)npc).velocity.X -= 0.1f;
				}
				else if (((Entity)Main.player[npc.target]).Center.X > ((Entity)npc).position.X + (float)((Entity)npc).width && ((Entity)npc).velocity.X < 5f)
				{
					((Entity)npc).velocity.X += 0.1f;
				}
			}
			else if (((Entity)Main.player[npc.target]).Center.Y + 50f < ((Entity)npc).position.Y && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				flag = true;
				((Entity)npc).velocity.Y = -7f;
			}
		}
		else if (npc.type == 425)
		{
			if (npc.localAI[3] == 0f)
			{
				npc.localAI[3] = 1f;
				npc.ai[3] = -120f;
			}
			if (((Entity)npc).velocity.Y == 0f)
			{
				npc.ai[2] = 0f;
			}
			if (((Entity)npc).velocity.Y != 0f && npc.ai[2] == 1f)
			{
				npc.TargetClosest(true);
				npc.spriteDirection = -((Entity)npc).direction;
				if (Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.player[npc.target]).Center, 0, 0))
				{
					float num249 = 0.3f;
					float num250 = 8f;
					float num251 = 0.3f;
					float num252 = 7f;
					float num253 = ((Entity)Main.player[npc.target]).Center.X - (float)(((Entity)npc).direction * 300) - ((Entity)npc).Center.X;
					float num254 = ((Entity)Main.player[npc.target]).Bottom.Y - ((Entity)npc).Bottom.Y;
					if (num253 < 0f && ((Entity)npc).velocity.X > 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					else if (num253 > 0f && ((Entity)npc).velocity.X < 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (num253 < 0f && ((Entity)npc).velocity.X > 0f - num252)
					{
						((Entity)npc).velocity.X -= num251;
					}
					else if (num253 > 0f && ((Entity)npc).velocity.X < num252)
					{
						((Entity)npc).velocity.X += num251;
					}
					if (((Entity)npc).velocity.X > num252)
					{
						((Entity)npc).velocity.X = num252;
					}
					if (((Entity)npc).velocity.X < 0f - num252)
					{
						((Entity)npc).velocity.X = 0f - num252;
					}
					if (num254 < -20f && ((Entity)npc).velocity.Y > 0f)
					{
						((Entity)npc).velocity.Y *= 0.8f;
					}
					else if (num254 > 20f && ((Entity)npc).velocity.Y < 0f)
					{
						((Entity)npc).velocity.Y *= 0.8f;
					}
					if (num254 < -20f && ((Entity)npc).velocity.Y > 0f - num250)
					{
						((Entity)npc).velocity.Y -= num249;
					}
					else if (num254 > 20f && ((Entity)npc).velocity.Y < num250)
					{
						((Entity)npc).velocity.Y += num249;
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
					Vector2 vector45 = ((Entity)npc).Center + new Vector2((float)(((Entity)npc).direction * -14), -8f) - Vector2.One * 4f;
					Vector2 vector46 = new Vector2((float)(((Entity)npc).direction * -6), 12f) * 0.2f + Utils.RandomVector2(Main.rand, -1f, 1f) * 0.1f;
					Dust obj11 = Main.dust[Dust.NewDust(vector45, 8, 8, 229, vector46.X, vector46.Y, 100, Color.Transparent, 1f + Utils.NextFloat(Main.rand) * 0.5f)];
					obj11.noGravity = true;
					obj11.velocity = vector46;
					obj11.customData = npc;
					((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
				}
				for (int num255 = 0; num255 < 200; num255++)
				{
					if (num255 != ((Entity)npc).whoAmI && ((Entity)Main.npc[num255]).active && Main.npc[num255].type == npc.type && Math.Abs(((Entity)npc).position.X - ((Entity)Main.npc[num255]).position.X) + Math.Abs(((Entity)npc).position.Y - ((Entity)Main.npc[num255]).position.Y) < (float)((Entity)npc).width)
					{
						if (((Entity)npc).position.X < ((Entity)Main.npc[num255]).position.X)
						{
							((Entity)npc).velocity.X -= 0.15f;
						}
						else
						{
							((Entity)npc).velocity.X += 0.15f;
						}
						if (((Entity)npc).position.Y < ((Entity)Main.npc[num255]).position.Y)
						{
							((Entity)npc).velocity.Y -= 0.15f;
						}
						else
						{
							((Entity)npc).velocity.Y += 0.15f;
						}
					}
				}
			}
			else if (((Entity)Main.player[npc.target]).Center.Y + 100f < ((Entity)npc).position.Y && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				flag = true;
				((Entity)npc).velocity.Y = -5f;
				npc.ai[2] = 1f;
			}
			if (npc.ai[3] < 0f)
			{
				npc.ai[3] += 1f;
			}
			int num256 = 30;
			int num257 = 10;
			int num258 = 180;
			if (npc.ai[3] >= 0f && npc.ai[3] <= (float)num256)
			{
				Vector2 vector47 = ((Entity)npc).DirectionTo(((Entity)Main.player[npc.target]).Center);
				bool flag31 = Math.Abs(vector47.Y) <= Math.Abs(vector47.X);
				bool flag32 = ((Entity)npc).Distance(((Entity)Main.player[npc.target]).Center) < 800f && flag31 && Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.player[npc.target]).Center, 0, 0);
				npc.ai[3] = MathHelper.Clamp(npc.ai[3] + (float)Utils.ToDirectionInt(flag32), 0f, (float)num256);
			}
			if (npc.ai[3] >= (float)(num256 + 1) && (npc.ai[3] += 1f) >= (float)(num256 + num257))
			{
				npc.ai[3] = num256 - num258;
				npc.netUpdate = true;
			}
			if (Main.netMode != 1 && npc.ai[3] == (float)num256)
			{
				npc.ai[3] += 1f;
				npc.netUpdate = true;
				int num259 = 20;
				Vector2 chaserPosition = ((Entity)npc).Center + new Vector2((float)(((Entity)npc).direction * 30), 2f);
				Vector2 vector48 = ((Entity)npc).DirectionTo(((Entity)Main.player[npc.target]).Center) * (float)num259;
				if (Utils.HasNaNs(vector48))
				{
					((Vector2)(ref vector48))._002Ector((float)(((Entity)npc).direction * num259), 0f);
				}
				int num260 = 2;
				ChaseResults chaseResults = Utils.GetChaseResults(chaserPosition, (float)num259, ((Entity)Main.player[npc.target]).Center, ((Entity)Main.player[npc.target]).velocity * 0.5f / (float)num260);
				if (chaseResults.InterceptionHappens)
				{
					Vector2 vector49 = chaseResults.ChaserVelocity / (float)num260;
					vector48.X = vector49.X;
					vector48.Y = vector49.Y;
				}
				int attackDamage_ForProjectiles = npc.GetAttackDamage_ForProjectiles(75f, 50f);
				for (int num261 = 0; num261 < 4; num261++)
				{
					Vector2 vector50 = vector48 + Utils.RandomVector2(Main.rand, -0.8f, 0.8f) * (float)((num261 != 0) ? 1 : 0);
					Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), chaserPosition.X, chaserPosition.Y, vector50.X, vector50.Y, 577, attackDamage_ForProjectiles, 1f, Main.myPlayer, 0f, 0f, 0f);
				}
			}
		}
		else if (npc.type == 427)
		{
			if (((Entity)npc).velocity.Y == 0f)
			{
				npc.ai[2] = 0f;
				npc.rotation = 0f;
			}
			else
			{
				npc.rotation = ((Entity)npc).velocity.X * 0.1f;
			}
			if (((Entity)npc).velocity.Y != 0f && npc.ai[2] == 1f)
			{
				npc.TargetClosest(true);
				npc.spriteDirection = -((Entity)npc).direction;
				if (Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.player[npc.target]).Center, 0, 0))
				{
					float num262 = ((Entity)Main.player[npc.target]).Center.X - ((Entity)npc).Center.X;
					float num263 = ((Entity)Main.player[npc.target]).Center.Y - ((Entity)npc).Center.Y;
					if (num262 < 0f && ((Entity)npc).velocity.X > 0f)
					{
						((Entity)npc).velocity.X *= 0.98f;
					}
					else if (num262 > 0f && ((Entity)npc).velocity.X < 0f)
					{
						((Entity)npc).velocity.X *= 0.98f;
					}
					if (num262 < -20f && ((Entity)npc).velocity.X > -6f)
					{
						((Entity)npc).velocity.X -= 0.015f;
					}
					else if (num262 > 20f && ((Entity)npc).velocity.X < 6f)
					{
						((Entity)npc).velocity.X += 0.015f;
					}
					if (((Entity)npc).velocity.X > 6f)
					{
						((Entity)npc).velocity.X = 6f;
					}
					if (((Entity)npc).velocity.X < -6f)
					{
						((Entity)npc).velocity.X = -6f;
					}
					if (num263 < -20f && ((Entity)npc).velocity.Y > 0f)
					{
						((Entity)npc).velocity.Y *= 0.98f;
					}
					else if (num263 > 20f && ((Entity)npc).velocity.Y < 0f)
					{
						((Entity)npc).velocity.Y *= 0.98f;
					}
					if (num263 < -20f && ((Entity)npc).velocity.Y > -6f)
					{
						((Entity)npc).velocity.Y -= 0.15f;
					}
					else if (num263 > 20f && ((Entity)npc).velocity.Y < 6f)
					{
						((Entity)npc).velocity.Y += 0.15f;
					}
				}
				for (int num264 = 0; num264 < 200; num264++)
				{
					if (num264 != ((Entity)npc).whoAmI && ((Entity)Main.npc[num264]).active && Main.npc[num264].type == npc.type && Math.Abs(((Entity)npc).position.X - ((Entity)Main.npc[num264]).position.X) + Math.Abs(((Entity)npc).position.Y - ((Entity)Main.npc[num264]).position.Y) < (float)((Entity)npc).width)
					{
						if (((Entity)npc).position.X < ((Entity)Main.npc[num264]).position.X)
						{
							((Entity)npc).velocity.X -= 0.05f;
						}
						else
						{
							((Entity)npc).velocity.X += 0.05f;
						}
						if (((Entity)npc).position.Y < ((Entity)Main.npc[num264]).position.Y)
						{
							((Entity)npc).velocity.Y -= 0.05f;
						}
						else
						{
							((Entity)npc).velocity.Y += 0.05f;
						}
					}
				}
			}
			else if (((Entity)Main.player[npc.target]).Center.Y + 100f < ((Entity)npc).position.Y && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				flag = true;
				((Entity)npc).velocity.Y = -5f;
				npc.ai[2] = 1f;
			}
		}
		else if (npc.type == 426)
		{
			float num265 = 6f;
			float num266 = 0.2f;
			float num267 = 6f;
			if (npc.ai[1] > 0f && ((Entity)npc).velocity.Y > 0f)
			{
				((Entity)npc).velocity.Y *= 0.85f;
				if (((Entity)npc).velocity.Y == 0f)
				{
					((Entity)npc).velocity.Y = -0.4f;
				}
			}
			if (((Entity)npc).velocity.Y != 0f)
			{
				npc.TargetClosest(true);
				npc.spriteDirection = ((Entity)npc).direction;
				if (Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.player[npc.target]).Center, 0, 0))
				{
					float num268 = ((Entity)Main.player[npc.target]).Center.X - (float)(((Entity)npc).direction * 300) - ((Entity)npc).Center.X;
					if (num268 < 40f && ((Entity)npc).velocity.X > 0f)
					{
						((Entity)npc).velocity.X *= 0.98f;
					}
					else if (num268 > 40f && ((Entity)npc).velocity.X < 0f)
					{
						((Entity)npc).velocity.X *= 0.98f;
					}
					if (num268 < 40f && ((Entity)npc).velocity.X > 0f - num265)
					{
						((Entity)npc).velocity.X -= num266;
					}
					else if (num268 > 40f && ((Entity)npc).velocity.X < num265)
					{
						((Entity)npc).velocity.X += num266;
					}
					if (((Entity)npc).velocity.X > num265)
					{
						((Entity)npc).velocity.X = num265;
					}
					if (((Entity)npc).velocity.X < 0f - num265)
					{
						((Entity)npc).velocity.X = 0f - num265;
					}
				}
			}
			else if (((Entity)Main.player[npc.target]).Center.Y + 100f < ((Entity)npc).position.Y && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				flag = true;
				((Entity)npc).velocity.Y = 0f - num267;
			}
			for (int num269 = 0; num269 < 200; num269++)
			{
				if (num269 != ((Entity)npc).whoAmI && ((Entity)Main.npc[num269]).active && Main.npc[num269].type == npc.type && Math.Abs(((Entity)npc).position.X - ((Entity)Main.npc[num269]).position.X) + Math.Abs(((Entity)npc).position.Y - ((Entity)Main.npc[num269]).position.Y) < (float)((Entity)npc).width)
				{
					if (((Entity)npc).position.X < ((Entity)Main.npc[num269]).position.X)
					{
						((Entity)npc).velocity.X -= 0.1f;
					}
					else
					{
						((Entity)npc).velocity.X += 0.1f;
					}
					if (((Entity)npc).position.Y < ((Entity)Main.npc[num269]).position.Y)
					{
						((Entity)npc).velocity.Y -= 0.1f;
					}
					else
					{
						((Entity)npc).velocity.Y += 0.1f;
					}
				}
			}
			if (Main.rand.Next(6) == 0 && npc.ai[1] <= 20f)
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				Dust obj12 = Main.dust[Dust.NewDust(((Entity)npc).Center + new Vector2((float)((npc.spriteDirection == 1) ? 8 : (-20)), -20f), 8, 8, 229, ((Entity)npc).velocity.X, ((Entity)npc).velocity.Y, 100, default(Color), 1f)];
				obj12.velocity = obj12.velocity / 4f + ((Entity)npc).velocity / 2f;
				obj12.scale = 0.6f;
				obj12.noLight = true;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
			if (npc.ai[1] >= 57f)
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				int num270 = Utils.SelectRandom<int>(Main.rand, new int[2] { 161, 229 });
				Dust obj13 = Main.dust[Dust.NewDust(((Entity)npc).Center + new Vector2((float)((npc.spriteDirection == 1) ? 8 : (-20)), -20f), 8, 8, num270, ((Entity)npc).velocity.X, ((Entity)npc).velocity.Y, 100, default(Color), 1f)];
				obj13.velocity = obj13.velocity / 4f + ((Entity)npc).DirectionTo(((Entity)Main.player[npc.target]).Top);
				obj13.scale = 1.2f;
				obj13.noLight = true;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
			if (Main.rand.Next(6) == 0)
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				Dust dust5 = Main.dust[Dust.NewDust(((Entity)npc).Center, 2, 2, 229, 0f, 0f, 0, default(Color), 1f)];
				dust5.position = ((Entity)npc).Center + new Vector2((float)((npc.spriteDirection == 1) ? 26 : (-26)), 24f);
				dust5.velocity.X = 0f;
				if (dust5.velocity.Y < 0f)
				{
					dust5.velocity.Y = 0f;
				}
				dust5.noGravity = true;
				dust5.scale = 1f;
				dust5.noLight = true;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		else if (npc.type == 185)
		{
			if (((Entity)npc).velocity.Y == 0f)
			{
				npc.rotation = 0f;
				npc.localAI[0] = 0f;
			}
			else if (npc.localAI[0] == 1f)
			{
				npc.rotation += ((Entity)npc).velocity.X * 0.05f;
			}
		}
		else if (npc.type == 428)
		{
			if (((Entity)npc).velocity.Y == 0f)
			{
				npc.rotation = 0f;
			}
			else
			{
				npc.rotation += ((Entity)npc).velocity.X * 0.08f;
			}
		}
		if (npc.type == 159 && Main.netMode != 1)
		{
			Vector2 vector51 = default(Vector2);
			((Vector2)(ref vector51))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
			float num271 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector51.X;
			float num272 = ((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height * 0.5f - vector51.Y;
			if ((float)Math.Sqrt(num271 * num271 + num272 * num272) > 300f)
			{
				npc.Transform(158);
			}
		}
		if (Main.netMode != 1)
		{
			if (Main.expertMode && npc.target >= 0 && (npc.type == 163 || npc.type == 238 || npc.type == 236 || npc.type == 237) && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
			{
				npc.localAI[0] += 1f;
				if (npc.justHit)
				{
					npc.localAI[0] -= Main.rand.Next(20, 60);
					if (npc.localAI[0] < 0f)
					{
						npc.localAI[0] = 0f;
					}
				}
				if (npc.localAI[0] > (float)Main.rand.Next(180, 900))
				{
					npc.localAI[0] = 0f;
					Vector2 vector52 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
					((Vector2)(ref vector52)).Normalize();
					vector52 *= 8f;
					int attackDamage_ForProjectiles2 = npc.GetAttackDamage_ForProjectiles(18f, 18f);
					Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X, ((Entity)npc).Center.Y, vector52.X, vector52.Y, 472, attackDamage_ForProjectiles2, 0f, Main.myPlayer, 0f, 0f, 0f);
				}
			}
			if (((Entity)npc).velocity.Y == 0f)
			{
				int num273 = -1;
				switch (npc.type)
				{
				case 164:
					num273 = 165;
					break;
				case 236:
					num273 = 237;
					break;
				case 163:
					num273 = 238;
					break;
				case 239:
					num273 = 240;
					break;
				case 530:
					num273 = 531;
					break;
				}
				if (num273 != -1 && npc.NPCCanStickToWalls())
				{
					npc.Transform(num273);
				}
			}
		}
		if (npc.type == 243)
		{
			if (npc.justHit && Main.rand.Next(3) == 0)
			{
				npc.ai[2] -= Main.rand.Next(30);
			}
			if (npc.ai[2] < 0f)
			{
				npc.ai[2] = 0f;
			}
			if (npc.confused)
			{
				npc.ai[2] = 0f;
			}
			npc.ai[2] += 1f;
			float num274 = Main.rand.Next(30, 900);
			num274 *= (float)npc.life / (float)npc.lifeMax;
			num274 += 30f;
			if (Main.netMode != 1 && npc.ai[2] >= num274 && ((Entity)npc).velocity.Y == 0f && !Main.player[npc.target].dead && !Main.player[npc.target].frozen && ((((Entity)npc).direction > 0 && ((Entity)npc).Center.X < ((Entity)Main.player[npc.target]).Center.X) || (((Entity)npc).direction < 0 && ((Entity)npc).Center.X > ((Entity)Main.player[npc.target]).Center.X)) && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				Vector2 vector53 = default(Vector2);
				((Vector2)(ref vector53))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + 20f);
				vector53.X += 10 * ((Entity)npc).direction;
				float num275 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector53.X;
				float num276 = ((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height * 0.5f - vector53.Y;
				num275 += (float)Main.rand.Next(-40, 41);
				num276 += (float)Main.rand.Next(-40, 41);
				float num277 = (float)Math.Sqrt(num275 * num275 + num276 * num276);
				npc.netUpdate = true;
				num277 = 15f / num277;
				num275 *= num277;
				num276 *= num277;
				int num278 = 32;
				int num279 = 257;
				vector53.X += num275 * 3f;
				vector53.Y += num276 * 3f;
				Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector53.X, vector53.Y, num275, num276, num279, num278, 0f, Main.myPlayer, 0f, 0f, 0f);
				npc.ai[2] = 0f;
			}
		}
		if (npc.type == 251)
		{
			if (npc.justHit)
			{
				npc.ai[2] -= Main.rand.Next(30);
			}
			if (npc.ai[2] < 0f)
			{
				npc.ai[2] = 0f;
			}
			if (npc.confused)
			{
				npc.ai[2] = 0f;
			}
			npc.ai[2] += 1f;
			float num280 = Main.rand.Next(60, 1800);
			num280 *= (float)npc.life / (float)npc.lifeMax;
			num280 += 15f;
			if (Main.netMode != 1 && npc.ai[2] >= num280 && ((Entity)npc).velocity.Y == 0f && !Main.player[npc.target].dead && !Main.player[npc.target].frozen && ((((Entity)npc).direction > 0 && ((Entity)npc).Center.X < ((Entity)Main.player[npc.target]).Center.X) || (((Entity)npc).direction < 0 && ((Entity)npc).Center.X > ((Entity)Main.player[npc.target]).Center.X)) && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height))
			{
				Vector2 vector54 = default(Vector2);
				((Vector2)(ref vector54))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + 12f);
				vector54.X += 6 * ((Entity)npc).direction;
				float num281 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector54.X;
				float num282 = ((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height * 0.5f - vector54.Y;
				num281 += (float)Main.rand.Next(-40, 41);
				num282 += (float)Main.rand.Next(-30, 0);
				float num283 = (float)Math.Sqrt(num281 * num281 + num282 * num282);
				npc.netUpdate = true;
				num283 = 15f / num283;
				num281 *= num283;
				num282 *= num283;
				int num284 = 30;
				int num285 = 83;
				vector54.X += num281 * 3f;
				vector54.Y += num282 * 3f;
				Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector54.X, vector54.Y, num281, num282, num285, num284, 0f, Main.myPlayer, 0f, 0f, 0f);
				npc.ai[2] = 0f;
			}
		}
		if (npc.type == 386)
		{
			if (npc.confused)
			{
				npc.ai[2] = -60f;
			}
			else
			{
				if (npc.ai[2] < 60f)
				{
					npc.ai[2] += 1f;
				}
				if (npc.ai[2] > 0f && NPC.CountNPCS(387) >= 4 * NPC.CountNPCS(386))
				{
					npc.ai[2] = 0f;
				}
				if (npc.justHit)
				{
					npc.ai[2] = -30f;
				}
				if (npc.ai[2] == 30f)
				{
					int num286 = (int)((Entity)npc).position.X / 16;
					int num287 = (int)((Entity)npc).position.Y / 16;
					int num288 = (int)((Entity)npc).position.X / 16;
					int num289 = (int)((Entity)npc).position.Y / 16;
					int num290 = 5;
					int num291 = 0;
					bool flag33 = false;
					int num292 = 2;
					int num293 = 0;
					while (!flag33 && num291 < 100)
					{
						num291++;
						int num294 = Main.rand.Next(num286 - num290, num286 + num290);
						for (int num295 = Main.rand.Next(num287 - num290, num287 + num290); num295 < num287 + num290; num295++)
						{
							if ((num295 >= num287 - num292 && num295 <= num287 + num292 && num294 >= num286 - num292 && num294 <= num286 + num292) || (num295 >= num289 - num293 && num295 <= num289 + num293 && num294 >= num288 - num293 && num294 <= num288 + num293))
							{
								continue;
							}
							val3 = ((Tilemap)(ref Main.tile))[num294, num295];
							if (!((Tile)(ref val3)).HasUnactuatedTile)
							{
								continue;
							}
							bool flag34 = true;
							val3 = ((Tilemap)(ref Main.tile))[num294, num295 - 1];
							if (((Tile)(ref val3)).LiquidAmount > 0)
							{
								val3 = ((Tilemap)(ref Main.tile))[num294, num295 - 1];
								if (((Tile)(ref val3)).LiquidType == 1)
								{
									flag34 = false;
								}
							}
							if (flag34)
							{
								bool[] tileSolid13 = Main.tileSolid;
								val3 = ((Tilemap)(ref Main.tile))[num294, num295];
								if (tileSolid13[((Tile)(ref val3)).TileType] && !Collision.SolidTiles(num294 - 1, num294 + 1, num295 - 4, num295 - 1))
								{
									int num296 = NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), num294 * 16 - ((Entity)npc).width / 2, num295 * 16, 387, 0, 0f, 0f, 0f, 0f, 255);
									((Entity)Main.npc[num296]).position.Y = num295 * 16 - ((Entity)Main.npc[num296]).height;
									flag33 = true;
									npc.netUpdate = true;
									break;
								}
							}
						}
					}
				}
				if (npc.ai[2] == 60f)
				{
					npc.ai[2] = -120f;
				}
			}
		}
		if (npc.type == 389)
		{
			if (npc.confused)
			{
				npc.ai[2] = -60f;
			}
			else
			{
				if (npc.ai[2] < 20f)
				{
					npc.ai[2] += 1f;
				}
				if (npc.justHit)
				{
					npc.ai[2] = -30f;
				}
				if (npc.ai[2] == 20f && Main.netMode != 1)
				{
					npc.ai[2] = -10 + Main.rand.Next(3) * -10;
					Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X, ((Entity)npc).Center.Y + 8f, (float)(((Entity)npc).direction * 6), 0f, 437, 25, 1f, Main.myPlayer, 0f, 0f, 0f);
				}
			}
		}
		if (npc.type == 110 || npc.type == 111 || npc.type == 206 || npc.type == 214 || npc.type == 215 || npc.type == 216 || npc.type == 290 || npc.type == 291 || npc.type == 292 || npc.type == 293 || npc.type == 350 || npc.type == 379 || npc.type == 380 || npc.type == 381 || npc.type == 382 || (npc.type >= 449 && npc.type <= 452) || npc.type == 468 || npc.type == 481 || npc.type == 411 || npc.type == 409 || (npc.type >= 498 && npc.type <= 506) || npc.type == 424 || npc.type == 426 || npc.type == 520)
		{
			bool flag35 = npc.type == 381 || npc.type == 382 || npc.type == 520;
			bool flag36 = npc.type == 426;
			bool flag37 = true;
			int num297 = -1;
			int num298 = -1;
			if (npc.type == 411)
			{
				flag35 = true;
				num297 = 120;
				num298 = 120;
				if (npc.ai[1] <= 220f)
				{
					flag37 = false;
				}
			}
			if (npc.ai[1] > 0f)
			{
				npc.ai[1] -= 1f;
			}
			if (npc.justHit)
			{
				npc.ai[1] = 30f;
				npc.ai[2] = 0f;
			}
			int num299 = 70;
			if (npc.type == 379 || npc.type == 380)
			{
				num299 = 80;
			}
			if (npc.type == 381 || npc.type == 382)
			{
				num299 = 80;
			}
			if (npc.type == 520)
			{
				num299 = 15;
			}
			if (npc.type == 350)
			{
				num299 = 110;
			}
			if (npc.type == 291)
			{
				num299 = 200;
			}
			if (npc.type == 292)
			{
				num299 = 120;
			}
			if (npc.type == 293)
			{
				num299 = 90;
			}
			if (npc.type == 111)
			{
				num299 = 180;
			}
			if (npc.type == 206)
			{
				num299 = 50;
			}
			if (npc.type == 481)
			{
				num299 = 100;
			}
			if (npc.type == 214)
			{
				num299 = 40;
			}
			if (npc.type == 215)
			{
				num299 = 80;
			}
			if (npc.type == 290)
			{
				num299 = 30;
			}
			if (npc.type == 411)
			{
				num299 = 330;
			}
			if (npc.type == 409)
			{
				num299 = 60;
			}
			if (npc.type == 424)
			{
				num299 = 180;
			}
			if (npc.type == 426)
			{
				num299 = 60;
			}
			bool flag38 = false;
			if (npc.type == 216)
			{
				if (npc.localAI[2] >= 20f)
				{
					flag38 = true;
				}
				num299 = ((!flag38) ? 8 : 60);
			}
			int num300 = num299 / 2;
			if (npc.type == 424)
			{
				num300 = num299 - 1;
			}
			if (npc.type == 426)
			{
				num300 = num299 - 1;
			}
			if (npc.type == 411)
			{
				num300 = 220;
			}
			if (npc.confused)
			{
				npc.ai[2] = 0f;
			}
			if (npc.ai[2] > 0f)
			{
				if (flag37)
				{
					npc.TargetClosest(true);
				}
				if (npc.ai[1] == (float)num300)
				{
					if (npc.type == 216)
					{
						npc.localAI[2] += 1f;
					}
					float num301 = 11f;
					if (npc.type == 111)
					{
						num301 = 9f;
					}
					if (npc.type == 206)
					{
						num301 = 7f;
					}
					if (npc.type == 290)
					{
						num301 = 9f;
					}
					if (npc.type == 293)
					{
						num301 = 4f;
					}
					if (npc.type == 214)
					{
						num301 = 14f;
					}
					if (npc.type == 215)
					{
						num301 = 16f;
					}
					if (npc.type == 382)
					{
						num301 = 7f;
					}
					if (npc.type == 520)
					{
						num301 = 8f;
					}
					if (npc.type == 409)
					{
						num301 = 4f;
					}
					if (npc.type >= 449 && npc.type <= 452)
					{
						num301 = 7f;
					}
					if (npc.type == 481)
					{
						num301 = 8f;
					}
					if (npc.type == 468)
					{
						num301 = 7.5f;
					}
					if (npc.type == 411)
					{
						num301 = 1f;
					}
					if (npc.type >= 498 && npc.type <= 506)
					{
						num301 = 7f;
					}
					Vector2 chaserPosition2 = default(Vector2);
					((Vector2)(ref chaserPosition2))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
					if (npc.type == 481)
					{
						chaserPosition2.Y -= 14f;
					}
					if (npc.type == 206)
					{
						chaserPosition2.Y -= 10f;
					}
					if (npc.type == 290)
					{
						chaserPosition2.Y -= 10f;
					}
					if (npc.type == 381 || npc.type == 382)
					{
						chaserPosition2.Y += 6f;
					}
					if (npc.type == 520)
					{
						chaserPosition2.Y = ((Entity)npc).position.Y + 20f;
					}
					if (npc.type >= 498 && npc.type <= 506)
					{
						chaserPosition2.Y -= 8f;
					}
					if (npc.type == 426)
					{
						chaserPosition2 += new Vector2((float)(npc.spriteDirection * 2), -12f);
						num301 = 7f;
					}
					float num302 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - chaserPosition2.X;
					float num303 = Math.Abs(num302) * 0.1f;
					if (npc.type == 291 || npc.type == 292)
					{
						num303 = 0f;
					}
					if (npc.type == 215)
					{
						num303 = Math.Abs(num302) * 0.08f;
					}
					if (npc.type == 214 || (npc.type == 216 && !flag38))
					{
						num303 = 0f;
					}
					if (npc.type == 381 || npc.type == 382 || npc.type == 520)
					{
						num303 = 0f;
					}
					if (npc.type >= 449 && npc.type <= 452)
					{
						num303 = Math.Abs(num302) * (float)Main.rand.Next(10, 50) * 0.01f;
					}
					if (npc.type == 468)
					{
						num303 = Math.Abs(num302) * (float)Main.rand.Next(10, 50) * 0.01f;
					}
					if (npc.type == 481)
					{
						num303 = Math.Abs(num302) * (float)Main.rand.Next(-10, 11) * 0.0035f;
					}
					if (npc.type >= 498 && npc.type <= 506)
					{
						num303 = Math.Abs(num302) * (float)Main.rand.Next(1, 11) * 0.0025f;
					}
					float num304 = ((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height * 0.5f - chaserPosition2.Y - num303;
					if (npc.type == 291)
					{
						num302 += (float)Main.rand.Next(-40, 41) * 0.2f;
						num304 += (float)Main.rand.Next(-40, 41) * 0.2f;
					}
					else if (npc.type == 381 || npc.type == 382 || npc.type == 520)
					{
						num302 += (float)Main.rand.Next(-100, 101) * 0.4f;
						num304 += (float)Main.rand.Next(-100, 101) * 0.4f;
						num302 *= (float)Main.rand.Next(85, 116) * 0.01f;
						num304 *= (float)Main.rand.Next(85, 116) * 0.01f;
						if (npc.type == 520)
						{
							num302 += (float)Main.rand.Next(-100, 101) * 0.6f;
							num304 += (float)Main.rand.Next(-100, 101) * 0.6f;
							num302 *= (float)Main.rand.Next(85, 116) * 0.015f;
							num304 *= (float)Main.rand.Next(85, 116) * 0.015f;
						}
					}
					else if (npc.type == 481)
					{
						num302 += (float)Main.rand.Next(-40, 41) * 0.4f;
						num304 += (float)Main.rand.Next(-40, 41) * 0.4f;
					}
					else if (npc.type >= 498 && npc.type <= 506)
					{
						num302 += (float)Main.rand.Next(-40, 41) * 0.3f;
						num304 += (float)Main.rand.Next(-40, 41) * 0.3f;
					}
					else if (npc.type == 426)
					{
						num302 += (float)Main.rand.Next(-30, 31) * 0.3f;
						num304 += (float)Main.rand.Next(-30, 31) * 0.3f;
					}
					else if (npc.type != 292)
					{
						num302 += (float)Main.rand.Next(-40, 41);
						num304 += (float)Main.rand.Next(-40, 41);
					}
					float num305 = (float)Math.Sqrt(num302 * num302 + num304 * num304);
					npc.netUpdate = true;
					num305 = num301 / num305;
					num302 *= num305;
					num304 *= num305;
					int num306 = 35;
					int num307 = 82;
					if (npc.type == 111)
					{
						num306 = 11;
					}
					if (npc.type == 206)
					{
						num306 = 37;
					}
					if (npc.type == 379 || npc.type == 380)
					{
						num306 = 40;
					}
					if (npc.type == 350)
					{
						num306 = 45;
					}
					if (npc.type == 468)
					{
						num306 = 50;
					}
					if (npc.type == 111)
					{
						num307 = 81;
					}
					if (npc.type == 379 || npc.type == 380)
					{
						num307 = 81;
					}
					if (npc.type == 381)
					{
						num307 = 436;
						num306 = 24;
					}
					if (npc.type == 382)
					{
						num307 = 438;
						num306 = 30;
					}
					if (npc.type == 520)
					{
						num307 = 592;
						num306 = 35;
					}
					if (npc.type >= 449 && npc.type <= 452)
					{
						num307 = 471;
						num306 = 15;
					}
					if (npc.type >= 498 && npc.type <= 506)
					{
						num307 = 572;
						num306 = 14;
					}
					if (npc.type == 481)
					{
						num307 = 508;
						num306 = 18;
					}
					if (npc.type == 206)
					{
						num307 = 177;
					}
					if (npc.type == 468)
					{
						num307 = 501;
					}
					if (npc.type == 411)
					{
						num307 = 537;
						num306 = npc.GetAttackDamage_ForProjectiles(60f, 45f);
					}
					if (npc.type == 424)
					{
						num307 = 573;
						num306 = npc.GetAttackDamage_ForProjectiles(60f, 45f);
					}
					if (npc.type == 426)
					{
						num307 = 581;
						num306 = npc.GetAttackDamage_ForProjectiles(60f, 45f);
					}
					if (npc.type == 291)
					{
						num307 = 302;
						num306 = 100;
					}
					if (npc.type == 290)
					{
						num307 = 300;
						num306 = 60;
					}
					if (npc.type == 293)
					{
						num307 = 303;
						num306 = 60;
					}
					if (npc.type == 214)
					{
						num307 = 180;
						num306 = 25;
					}
					if (npc.type == 215)
					{
						num307 = 82;
						num306 = 40;
					}
					if (npc.type == 292)
					{
						num306 = 50;
						num307 = 180;
					}
					if (npc.type == 216)
					{
						num307 = 180;
						num306 = 30;
						if (flag38)
						{
							num306 = 100;
							num307 = 240;
							npc.localAI[2] = 0f;
						}
					}
					Player player3 = Main.player[npc.target];
					Vector2? vector55 = null;
					if (npc.type == 426)
					{
						vector55 = Utils.NextVector2FromRectangle(Main.rand, ((Entity)player3).Hitbox);
					}
					if (vector55.HasValue)
					{
						ChaseResults chaseResults2 = Utils.GetChaseResults(chaserPosition2, num301, vector55.Value, ((Entity)player3).velocity);
						if (chaseResults2.InterceptionHappens)
						{
							Vector2 val6 = Utils.FactorAcceleration(chaseResults2.ChaserVelocity, chaseResults2.InterceptionTime, new Vector2(0f, 0.1f), 15);
							num302 = val6.X;
							num304 = val6.Y;
						}
					}
					chaserPosition2.X += num302;
					chaserPosition2.Y += num304;
					if (npc.type == 290)
					{
						num306 = npc.GetAttackDamage_ForProjectiles((float)num306, (float)num306 * 0.75f);
					}
					if (npc.type >= 381 && npc.type <= 392)
					{
						num306 = npc.GetAttackDamage_ForProjectiles((float)num306, (float)num306 * 0.8f);
					}
					if (Main.netMode != 1)
					{
						if (npc.type == 292)
						{
							for (int num308 = 0; num308 < 4; num308++)
							{
								num302 = ((Entity)player3).position.X + (float)((Entity)player3).width * 0.5f - chaserPosition2.X;
								num304 = ((Entity)player3).position.Y + (float)((Entity)player3).height * 0.5f - chaserPosition2.Y;
								num305 = (float)Math.Sqrt(num302 * num302 + num304 * num304);
								num305 = 12f / num305;
								num302 = (num302 += (float)Main.rand.Next(-40, 41));
								num304 = (num304 += (float)Main.rand.Next(-40, 41));
								num302 *= num305;
								num304 *= num305;
								Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), chaserPosition2.X, chaserPosition2.Y, num302, num304, num307, num306, 0f, Main.myPlayer, 0f, 0f, 0f);
							}
						}
						else if (npc.type == 411)
						{
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), chaserPosition2.X, chaserPosition2.Y, num302, num304, num307, num306, 0f, Main.myPlayer, 0f, (float)((Entity)npc).whoAmI, 0f);
						}
						else if (npc.type == 424)
						{
							for (int num309 = 0; num309 < 4; num309++)
							{
								Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X - (float)(npc.spriteDirection * 4), ((Entity)npc).Center.Y + 6f, (float)(-3 + 2 * num309) * 0.15f, (float)(-Main.rand.Next(0, 3)) * 0.2f - 0.1f, num307, num306, 0f, Main.myPlayer, 0f, (float)((Entity)npc).whoAmI, 0f);
							}
						}
						else if (npc.type == 409)
						{
							int num310 = NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), (int)((Entity)npc).Center.X, (int)((Entity)npc).Center.Y, 410, ((Entity)npc).whoAmI, 0f, 0f, 0f, 0f, 255);
							((Entity)Main.npc[num310]).velocity = new Vector2(num302, -6f + num304);
						}
						else
						{
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), chaserPosition2.X, chaserPosition2.Y, num302, num304, num307, num306, 0f, Main.myPlayer, 0f, 0f, 0f);
						}
					}
					if (Math.Abs(num304) > Math.Abs(num302) * 2f)
					{
						if (num304 > 0f)
						{
							npc.ai[2] = 1f;
						}
						else
						{
							npc.ai[2] = 5f;
						}
					}
					else if (Math.Abs(num302) > Math.Abs(num304) * 2f)
					{
						npc.ai[2] = 3f;
					}
					else if (num304 > 0f)
					{
						npc.ai[2] = 2f;
					}
					else
					{
						npc.ai[2] = 4f;
					}
				}
				if ((((Entity)npc).velocity.Y != 0f && !flag36) || npc.ai[1] <= 0f)
				{
					npc.ai[2] = 0f;
					npc.ai[1] = 0f;
				}
				else if (!flag35 || (num297 != -1 && npc.ai[1] >= (float)num297 && npc.ai[1] < (float)(num297 + num298) && (!flag36 || ((Entity)npc).velocity.Y == 0f)))
				{
					((Entity)npc).velocity.X *= 0.9f;
					npc.spriteDirection = ((Entity)npc).direction;
				}
			}
			if (npc.type == 468 && !Main.eclipse)
			{
				flag35 = true;
			}
			else if ((npc.ai[2] <= 0f || flag35) && (((Entity)npc).velocity.Y == 0f || flag36) && npc.ai[1] <= 0f && !Main.player[npc.target].dead)
			{
				bool flag39 = Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height);
				if (npc.type == 520)
				{
					flag39 = Collision.CanHitLine(((Entity)npc).Top + new Vector2(0f, 20f), 0, 0, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height);
				}
				if (Main.player[npc.target].stealth == 0f && Main.player[npc.target].itemAnimation == 0)
				{
					flag39 = false;
				}
				if (flag39)
				{
					float num311 = 10f;
					Vector2 vector56 = default(Vector2);
					((Vector2)(ref vector56))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
					float num312 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector56.X;
					float num313 = Math.Abs(num312) * 0.1f;
					float num314 = ((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height * 0.5f - vector56.Y - num313;
					num312 += (float)Main.rand.Next(-40, 41);
					num314 += (float)Main.rand.Next(-40, 41);
					float num315 = (float)Math.Sqrt(num312 * num312 + num314 * num314);
					float num316 = 700f;
					if (npc.type == 214)
					{
						num316 = 550f;
					}
					if (npc.type == 215)
					{
						num316 = 800f;
					}
					if (npc.type >= 498 && npc.type <= 506)
					{
						num316 = 190f;
					}
					if (npc.type >= 449 && npc.type <= 452)
					{
						num316 = 200f;
					}
					if (npc.type == 481)
					{
						num316 = 400f;
					}
					if (npc.type == 468)
					{
						num316 = 400f;
					}
					if (num315 < num316)
					{
						npc.netUpdate = true;
						((Entity)npc).velocity.X *= 0.5f;
						num315 = num311 / num315;
						num312 *= num315;
						num314 *= num315;
						npc.ai[2] = 3f;
						npc.ai[1] = num299;
						if (Math.Abs(num314) > Math.Abs(num312) * 2f)
						{
							if (num314 > 0f)
							{
								npc.ai[2] = 1f;
							}
							else
							{
								npc.ai[2] = 5f;
							}
						}
						else if (Math.Abs(num312) > Math.Abs(num314) * 2f)
						{
							npc.ai[2] = 3f;
						}
						else if (num314 > 0f)
						{
							npc.ai[2] = 2f;
						}
						else
						{
							npc.ai[2] = 4f;
						}
					}
				}
			}
			if (npc.ai[2] <= 0f || (flag35 && (num297 == -1 || !(npc.ai[1] >= (float)num297) || !(npc.ai[1] < (float)(num297 + num298)))))
			{
				float num317 = 1f;
				float num318 = 0.07f;
				float num319 = 0.8f;
				if (npc.type == 214)
				{
					num317 = 2f;
					num318 = 0.09f;
				}
				else if (npc.type == 215)
				{
					num317 = 1.5f;
					num318 = 0.08f;
				}
				else if (npc.type == 381 || npc.type == 382)
				{
					num317 = 2f;
					num318 = 0.5f;
				}
				else if (npc.type == 520)
				{
					num317 = 4f;
					num318 = 1f;
					num319 = 0.7f;
				}
				else if (npc.type == 411)
				{
					num317 = 2f;
					num318 = 0.5f;
				}
				else if (npc.type == 409)
				{
					num317 = 2f;
					num318 = 0.5f;
				}
				else if (npc.type == 426)
				{
					num317 = 4f;
					num318 = 0.6f;
					num319 = 0.95f;
				}
				bool flag40 = false;
				if ((npc.type == 381 || npc.type == 382) && Vector2.Distance(((Entity)npc).Center, ((Entity)Main.player[npc.target]).Center) < 300f && Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.player[npc.target]).Center, 0, 0))
				{
					flag40 = true;
					npc.ai[3] = 0f;
				}
				if (npc.type == 520 && Vector2.Distance(((Entity)npc).Center, ((Entity)Main.player[npc.target]).Center) < 400f && Collision.CanHitLine(((Entity)npc).Center, 0, 0, ((Entity)Main.player[npc.target]).Center, 0, 0))
				{
					flag40 = true;
					npc.ai[3] = 0f;
				}
				if (((Entity)npc).velocity.X < 0f - num317 || ((Entity)npc).velocity.X > num317 || flag40)
				{
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity = ((Entity)npc).velocity * num319;
					}
				}
				else if (((Entity)npc).velocity.X < num317 && ((Entity)npc).direction == 1)
				{
					((Entity)npc).velocity.X += num318;
					if (((Entity)npc).velocity.X > num317)
					{
						((Entity)npc).velocity.X = num317;
					}
				}
				else if (((Entity)npc).velocity.X > 0f - num317 && ((Entity)npc).direction == -1)
				{
					((Entity)npc).velocity.X -= num318;
					if (((Entity)npc).velocity.X < 0f - num317)
					{
						((Entity)npc).velocity.X = 0f - num317;
					}
				}
			}
			if (npc.type == 520)
			{
				npc.localAI[2] += 1f;
				if (npc.localAI[2] >= 6f)
				{
					npc.localAI[2] = 0f;
					npc.localAI[3] = Utils.ToRotation(((Entity)Main.player[npc.target]).DirectionFrom(((Entity)npc).Top + new Vector2(0f, 20f)));
				}
			}
		}
		if (npc.type == 109 && Main.netMode != 1 && !Main.player[npc.target].dead)
		{
			if (npc.justHit)
			{
				npc.ai[2] = 0f;
			}
			npc.ai[2] += 1f;
			if (npc.ai[2] > 60f)
			{
				Vector2 vector57 = default(Vector2);
				((Vector2)(ref vector57))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f - (float)(((Entity)npc).direction * 24), ((Entity)npc).position.Y + 4f);
				if (Main.rand.Next(5) != 0 || NPC.AnyNPCs(378))
				{
					int num320 = Main.rand.Next(3, 8) * ((Entity)npc).direction;
					int num321 = Main.rand.Next(-8, -5);
					int num322 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector57.X, vector57.Y, (float)num320, (float)num321, 75, 80, 0f, Main.myPlayer, 0f, 0f, 0f);
					Main.projectile[num322].timeLeft = 300;
					npc.ai[2] = 0f;
				}
				else
				{
					npc.ai[2] = -120f;
					int number = NPC.NewNPC(((Entity)npc).GetSource_FromAI((string)null), (int)vector57.X, (int)vector57.Y, 378, 0, 0f, 0f, 0f, 0f, 255);
					NetMessage.SendData(23, -1, -1, (NetworkText)null, number, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		if (((Entity)npc).velocity.Y == 0f || flag)
		{
			int num323 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 7f) / 16;
			int num324 = (int)(((Entity)npc).position.Y - 9f) / 16;
			int num325 = (int)((Entity)npc).position.X / 16;
			int num326 = (int)(((Entity)npc).position.X + (float)((Entity)npc).width) / 16;
			int num327 = (int)(((Entity)npc).position.X + 8f) / 16;
			int num328 = (int)(((Entity)npc).position.X + (float)((Entity)npc).width - 8f) / 16;
			bool flag41 = false;
			for (int num329 = num327; num329 <= num328; num329++)
			{
				if (num329 >= num325 && num329 <= num326 && ((Tilemap)(ref Main.tile))[num329, num323] == (ArgumentException)null)
				{
					flag41 = true;
					continue;
				}
				if (((Tilemap)(ref Main.tile))[num329, num324] != (ArgumentException)null)
				{
					val3 = ((Tilemap)(ref Main.tile))[num329, num324];
					if (((Tile)(ref val3)).HasUnactuatedTile)
					{
						bool[] tileSolid14 = Main.tileSolid;
						val3 = ((Tilemap)(ref Main.tile))[num329, num324];
						if (tileSolid14[((Tile)(ref val3)).TileType])
						{
							flag5 = false;
							break;
						}
					}
				}
				if (flag41 || num329 < num325 || num329 > num326)
				{
					continue;
				}
				val3 = ((Tilemap)(ref Main.tile))[num329, num323];
				if (((Tile)(ref val3)).HasUnactuatedTile)
				{
					bool[] tileSolid15 = Main.tileSolid;
					val3 = ((Tilemap)(ref Main.tile))[num329, num323];
					if (tileSolid15[((Tile)(ref val3)).TileType])
					{
						flag5 = true;
					}
				}
			}
			if (!flag5 && ((Entity)npc).velocity.Y < 0f)
			{
				((Entity)npc).velocity.Y = 0f;
			}
			if (flag41)
			{
				return false;
			}
		}
		if (npc.type == 428)
		{
			flag5 = false;
		}
		if (((Entity)npc).velocity.Y >= 0f && (npc.type != 580 || npc.directionY != 1))
		{
			num202 = 0;
			if (((Entity)npc).velocity.X < 0f)
			{
				num202 = -1;
			}
			if (((Entity)npc).velocity.X > 0f)
			{
				num202 = 1;
			}
			vector39 = ((Entity)npc).position;
			vector39.X += ((Entity)npc).velocity.X;
			num200 = (int)((vector39.X + (float)(((Entity)npc).width / 2) + (float)((((Entity)npc).width / 2 + 1) * num202)) / 16f);
			num201 = (int)((vector39.Y + (float)((Entity)npc).height - 1f) / 16f);
			if (WorldGen.InWorld(num200, num201, 4) && (float)(num200 * 16) < vector39.X + (float)((Entity)npc).width && (float)(num200 * 16 + 16) > vector39.X)
			{
				val3 = ((Tilemap)(ref Main.tile))[num200, num201];
				if (((Tile)(ref val3)).HasUnactuatedTile)
				{
					val3 = ((Tilemap)(ref Main.tile))[num200, num201];
					if (!((Tile)(ref val3)).TopSlope)
					{
						val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
						if (!((Tile)(ref val3)).TopSlope)
						{
							bool[] tileSolid16 = Main.tileSolid;
							val3 = ((Tilemap)(ref Main.tile))[num200, num201];
							if (tileSolid16[((Tile)(ref val3)).TileType])
							{
								bool[] tileSolidTop5 = Main.tileSolidTop;
								val3 = ((Tilemap)(ref Main.tile))[num200, num201];
								if (!tileSolidTop5[((Tile)(ref val3)).TileType])
								{
									goto IL_bf25;
								}
							}
						}
					}
				}
				val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
				if (((Tile)(ref val3)).IsHalfBlock)
				{
					val3 = ((Tilemap)(ref Main.tile))[num200, num201 - 1];
					if (((Tile)(ref val3)).HasUnactuatedTile)
					{
						goto IL_bf25;
					}
				}
			}
		}
		goto IL_c31e;
		IL_ce9f:
		if (flag8)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
		goto IL_cebd;
		IL_d1bb:
		if ((npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 47 || npc.type == 77 || npc.type == 104 || npc.type == 168 || npc.type == 196 || npc.type == 385 || npc.type == 389 || npc.type == 464 || npc.type == 470 || (npc.type >= 524 && npc.type <= 527)) && ((Entity)npc).velocity.Y == 0f)
		{
			int num330 = 100;
			int num331 = 50;
			if (npc.type == 586)
			{
				num330 = 150;
				num331 = 150;
			}
			if (Math.Abs(((Entity)npc).position.X + (float)(((Entity)npc).width / 2) - (((Entity)Main.player[npc.target]).position.X + (float)(((Entity)Main.player[npc.target]).width / 2))) < (float)num330 && Math.Abs(((Entity)npc).position.Y + (float)(((Entity)npc).height / 2) - (((Entity)Main.player[npc.target]).position.Y + (float)(((Entity)Main.player[npc.target]).height / 2))) < (float)num331 && ((((Entity)npc).direction > 0 && ((Entity)npc).velocity.X >= 1f) || (((Entity)npc).direction < 0 && ((Entity)npc).velocity.X <= -1f)))
			{
				if (npc.type == 586)
				{
					((Entity)npc).velocity.X += ((Entity)npc).direction;
					((Entity)npc).velocity.X *= 2f;
					if (((Entity)npc).velocity.X > 8f)
					{
						((Entity)npc).velocity.X = 8f;
					}
					if (((Entity)npc).velocity.X < -8f)
					{
						((Entity)npc).velocity.X = -8f;
					}
					((Entity)npc).velocity.Y = -4.5f;
					if (((Entity)npc).position.Y > ((Entity)Main.player[npc.target]).position.Y + 40f)
					{
						((Entity)npc).velocity.Y -= 2f;
					}
					if (((Entity)npc).position.Y > ((Entity)Main.player[npc.target]).position.Y + 80f)
					{
						((Entity)npc).velocity.Y -= 2f;
					}
					if (((Entity)npc).position.Y > ((Entity)Main.player[npc.target]).position.Y + 120f)
					{
						((Entity)npc).velocity.Y -= 2f;
					}
				}
				else
				{
					((Entity)npc).velocity.X *= 2f;
					if (((Entity)npc).velocity.X > 3f)
					{
						((Entity)npc).velocity.X = 3f;
					}
					if (((Entity)npc).velocity.X < -3f)
					{
						((Entity)npc).velocity.X = -3f;
					}
					((Entity)npc).velocity.Y = -4f;
				}
				npc.netUpdate = true;
			}
		}
		if (npc.type == 120 && ((Entity)npc).velocity.Y < 0f)
		{
			((Entity)npc).velocity.Y *= 1.1f;
		}
		if (npc.type == 287 && ((Entity)npc).velocity.Y == 0f && Math.Abs(((Entity)npc).position.X + (float)(((Entity)npc).width / 2) - (((Entity)Main.player[npc.target]).position.X + (float)(((Entity)Main.player[npc.target]).width / 2))) < 150f && Math.Abs(((Entity)npc).position.Y + (float)(((Entity)npc).height / 2) - (((Entity)Main.player[npc.target]).position.Y + (float)(((Entity)Main.player[npc.target]).height / 2))) < 50f && ((((Entity)npc).direction > 0 && ((Entity)npc).velocity.X >= 1f) || (((Entity)npc).direction < 0 && ((Entity)npc).velocity.X <= -1f)))
		{
			((Entity)npc).velocity.X = 8 * ((Entity)npc).direction;
			((Entity)npc).velocity.Y = -4f;
			npc.netUpdate = true;
		}
		if (npc.type == 287 && ((Entity)npc).velocity.Y < 0f)
		{
			((Entity)npc).velocity.X *= 1.2f;
			((Entity)npc).velocity.Y *= 1.1f;
		}
		if (npc.type == 460 && ((Entity)npc).velocity.Y < 0f)
		{
			((Entity)npc).velocity.X *= 1.3f;
			((Entity)npc).velocity.Y *= 1.1f;
		}
		goto IL_d766;
		IL_cebd:
		if (((Entity)npc).velocity.Y == 0f && flag6 && npc.ai[3] == 1f)
		{
			((Entity)npc).velocity.Y = -5f;
		}
		if (((Entity)npc).velocity.Y == 0f && (Main.expertMode || npc.type == 586) && ((Entity)Main.player[npc.target]).Bottom.Y < ((Entity)npc).Top.Y && Math.Abs(((Entity)npc).Center.X - ((Entity)Main.player[npc.target]).Center.X) < (float)(((Entity)Main.player[npc.target]).width * 3) && Collision.CanHit((Entity)(object)npc, (Entity)(object)Main.player[npc.target]))
		{
			if (npc.type == 586)
			{
				int num332 = (int)((((Entity)npc).Bottom.Y - 16f - ((Entity)Main.player[npc.target]).Bottom.Y) / 16f);
				if (num332 < 14 && Collision.CanHit((Entity)(object)npc, (Entity)(object)Main.player[npc.target]))
				{
					if (num332 < 7)
					{
						((Entity)npc).velocity.Y = -8.8f;
					}
					else if (num332 < 8)
					{
						((Entity)npc).velocity.Y = -9.2f;
					}
					else if (num332 < 9)
					{
						((Entity)npc).velocity.Y = -9.7f;
					}
					else if (num332 < 10)
					{
						((Entity)npc).velocity.Y = -10.3f;
					}
					else if (num332 < 11)
					{
						((Entity)npc).velocity.Y = -10.6f;
					}
					else
					{
						((Entity)npc).velocity.Y = -11f;
					}
				}
			}
			if (((Entity)npc).velocity.Y == 0f)
			{
				int num333 = 6;
				if (((Entity)Main.player[npc.target]).Bottom.Y > ((Entity)npc).Top.Y - (float)(num333 * 16))
				{
					((Entity)npc).velocity.Y = -7.9f;
				}
				else
				{
					int num334 = (int)(((Entity)npc).Center.X / 16f);
					int num335 = (int)(((Entity)npc).Bottom.Y / 16f) - 1;
					for (int num336 = num335; num336 > num335 - num333; num336--)
					{
						val3 = ((Tilemap)(ref Main.tile))[num334, num336];
						if (((Tile)(ref val3)).HasUnactuatedTile)
						{
							bool[] platforms = Sets.Platforms;
							val3 = ((Tilemap)(ref Main.tile))[num334, num336];
							if (platforms[((Tile)(ref val3)).TileType])
							{
								((Entity)npc).velocity.Y = -7.9f;
								break;
							}
						}
					}
				}
			}
		}
		goto IL_d1bb;
	}

	private static bool AI_003_Gnomes_ShouldTurnToStone(this NPC npc)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (Main.remixWorld)
		{
			return ((Entity)npc).position.Y / 16f > (float)(Main.maxTilesY - 350);
		}
		if (Main.dayTime)
		{
			return WorldGen.InAPlaceWithWind(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height);
		}
		return false;
	}
}
