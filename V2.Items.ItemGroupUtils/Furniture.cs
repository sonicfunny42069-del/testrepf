using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.Items.ItemGroupUtils;

public class Furniture : GlobalItem
{
	public enum FurnitureMaterial
	{
		OakWood,
		BorealWood,
		PalmWood,
		Ebonwood,
		Shadewood,
		JungleWood,
		Pearlwood,
		AshWood,
		SpookyWood,
		Bamboo,
		Cactus,
		Pumpkin,
		Mushroom,
		Marble,
		Granite,
		Sandstone,
		Ice,
		Coral,
		Golden,
		Crystal
	}

	public enum FurnitureType
	{
		Bathtub,
		Bed,
		Bookcase,
		Candelabra,
		Candle,
		Chair,
		Chandelier,
		Chest,
		ChestTrapped,
		Clock,
		Door,
		DoorTall,
		Dresser,
		Fence,
		Lamp,
		Lantern,
		Piano,
		Platform,
		Sink,
		Sofa,
		Table,
		Toilet,
		Wall,
		WorkBench
	}

	public static Dictionary<int, (FurnitureType Type, FurnitureMaterial Material)> FurnitureDefinitionMappings => new Dictionary<int, (FurnitureType, FurnitureMaterial)>
	{
		{
			224,
			(FurnitureType.Bed, FurnitureMaterial.OakWood)
		},
		{
			354,
			(FurnitureType.Bookcase, FurnitureMaterial.OakWood)
		},
		{
			34,
			(FurnitureType.Chair, FurnitureMaterial.OakWood)
		},
		{
			48,
			(FurnitureType.Chest, FurnitureMaterial.OakWood)
		},
		{
			3665,
			(FurnitureType.ChestTrapped, FurnitureMaterial.OakWood)
		},
		{
			359,
			(FurnitureType.Clock, FurnitureMaterial.OakWood)
		},
		{
			25,
			(FurnitureType.Door, FurnitureMaterial.OakWood)
		},
		{
			3240,
			(FurnitureType.DoorTall, FurnitureMaterial.OakWood)
		},
		{
			334,
			(FurnitureType.Dresser, FurnitureMaterial.OakWood)
		},
		{
			1447,
			(FurnitureType.Fence, FurnitureMaterial.OakWood)
		},
		{
			333,
			(FurnitureType.Piano, FurnitureMaterial.OakWood)
		},
		{
			94,
			(FurnitureType.Platform, FurnitureMaterial.OakWood)
		},
		{
			2827,
			(FurnitureType.Sink, FurnitureMaterial.OakWood)
		},
		{
			2397,
			(FurnitureType.Sofa, FurnitureMaterial.OakWood)
		},
		{
			32,
			(FurnitureType.Table, FurnitureMaterial.OakWood)
		},
		{
			93,
			(FurnitureType.Wall, FurnitureMaterial.OakWood)
		},
		{
			36,
			(FurnitureType.WorkBench, FurnitureMaterial.OakWood)
		},
		{
			2552,
			(FurnitureType.Bathtub, FurnitureMaterial.BorealWood)
		},
		{
			2553,
			(FurnitureType.Bed, FurnitureMaterial.BorealWood)
		},
		{
			2554,
			(FurnitureType.Bookcase, FurnitureMaterial.BorealWood)
		},
		{
			2555,
			(FurnitureType.Candelabra, FurnitureMaterial.BorealWood)
		},
		{
			2556,
			(FurnitureType.Candle, FurnitureMaterial.BorealWood)
		},
		{
			2557,
			(FurnitureType.Chair, FurnitureMaterial.BorealWood)
		},
		{
			2559,
			(FurnitureType.Chest, FurnitureMaterial.BorealWood)
		},
		{
			3689,
			(FurnitureType.ChestTrapped, FurnitureMaterial.BorealWood)
		},
		{
			2560,
			(FurnitureType.Clock, FurnitureMaterial.BorealWood)
		},
		{
			2561,
			(FurnitureType.Door, FurnitureMaterial.BorealWood)
		},
		{
			2562,
			(FurnitureType.Dresser, FurnitureMaterial.BorealWood)
		},
		{
			2507,
			(FurnitureType.Fence, FurnitureMaterial.BorealWood)
		},
		{
			2563,
			(FurnitureType.Lamp, FurnitureMaterial.BorealWood)
		},
		{
			2564,
			(FurnitureType.Lantern, FurnitureMaterial.BorealWood)
		},
		{
			2565,
			(FurnitureType.Piano, FurnitureMaterial.BorealWood)
		},
		{
			2566,
			(FurnitureType.Platform, FurnitureMaterial.BorealWood)
		},
		{
			2852,
			(FurnitureType.Sink, FurnitureMaterial.BorealWood)
		},
		{
			858,
			(FurnitureType.Sofa, FurnitureMaterial.BorealWood)
		},
		{
			677,
			(FurnitureType.Table, FurnitureMaterial.BorealWood)
		},
		{
			4119,
			(FurnitureType.Toilet, FurnitureMaterial.BorealWood)
		},
		{
			2505,
			(FurnitureType.Wall, FurnitureMaterial.BorealWood)
		},
		{
			673,
			(FurnitureType.WorkBench, FurnitureMaterial.BorealWood)
		},
		{
			2073,
			(FurnitureType.Bathtub, FurnitureMaterial.Ebonwood)
		},
		{
			644,
			(FurnitureType.Bed, FurnitureMaterial.Ebonwood)
		},
		{
			2021,
			(FurnitureType.Bookcase, FurnitureMaterial.Ebonwood)
		},
		{
			2093,
			(FurnitureType.Candelabra, FurnitureMaterial.Ebonwood)
		},
		{
			2046,
			(FurnitureType.Candle, FurnitureMaterial.Ebonwood)
		},
		{
			628,
			(FurnitureType.Chair, FurnitureMaterial.Ebonwood)
		},
		{
			625,
			(FurnitureType.Chest, FurnitureMaterial.Ebonwood)
		},
		{
			3668,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Ebonwood)
		},
		{
			2593,
			(FurnitureType.Clock, FurnitureMaterial.Ebonwood)
		},
		{
			650,
			(FurnitureType.Door, FurnitureMaterial.Ebonwood)
		},
		{
			647,
			(FurnitureType.Dresser, FurnitureMaterial.Ebonwood)
		},
		{
			2210,
			(FurnitureType.Fence, FurnitureMaterial.Ebonwood)
		},
		{
			2083,
			(FurnitureType.Lamp, FurnitureMaterial.Ebonwood)
		},
		{
			2033,
			(FurnitureType.Lantern, FurnitureMaterial.Ebonwood)
		},
		{
			641,
			(FurnitureType.Piano, FurnitureMaterial.Ebonwood)
		},
		{
			631,
			(FurnitureType.Platform, FurnitureMaterial.Ebonwood)
		},
		{
			2828,
			(FurnitureType.Sink, FurnitureMaterial.Ebonwood)
		},
		{
			2398,
			(FurnitureType.Sofa, FurnitureMaterial.Ebonwood)
		},
		{
			638,
			(FurnitureType.Table, FurnitureMaterial.Ebonwood)
		},
		{
			4096,
			(FurnitureType.Toilet, FurnitureMaterial.Ebonwood)
		},
		{
			622,
			(FurnitureType.Wall, FurnitureMaterial.Ebonwood)
		},
		{
			635,
			(FurnitureType.WorkBench, FurnitureMaterial.Ebonwood)
		},
		{
			2127,
			(FurnitureType.Bathtub, FurnitureMaterial.Shadewood)
		},
		{
			920,
			(FurnitureType.Bed, FurnitureMaterial.Shadewood)
		},
		{
			2136,
			(FurnitureType.Bookcase, FurnitureMaterial.Shadewood)
		},
		{
			2150,
			(FurnitureType.Candelabra, FurnitureMaterial.Shadewood)
		},
		{
			2154,
			(FurnitureType.Candle, FurnitureMaterial.Shadewood)
		},
		{
			915,
			(FurnitureType.Chair, FurnitureMaterial.Shadewood)
		},
		{
			914,
			(FurnitureType.Chest, FurnitureMaterial.Shadewood)
		},
		{
			3675,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Shadewood)
		},
		{
			2604,
			(FurnitureType.Clock, FurnitureMaterial.Shadewood)
		},
		{
			912,
			(FurnitureType.Door, FurnitureMaterial.Shadewood)
		},
		{
			918,
			(FurnitureType.Dresser, FurnitureMaterial.Shadewood)
		},
		{
			2213,
			(FurnitureType.Fence, FurnitureMaterial.Shadewood)
		},
		{
			2132,
			(FurnitureType.Lamp, FurnitureMaterial.Shadewood)
		},
		{
			2146,
			(FurnitureType.Lantern, FurnitureMaterial.Shadewood)
		},
		{
			919,
			(FurnitureType.Piano, FurnitureMaterial.Shadewood)
		},
		{
			913,
			(FurnitureType.Platform, FurnitureMaterial.Shadewood)
		},
		{
			2835,
			(FurnitureType.Sink, FurnitureMaterial.Shadewood)
		},
		{
			2401,
			(FurnitureType.Sofa, FurnitureMaterial.Shadewood)
		},
		{
			917,
			(FurnitureType.Table, FurnitureMaterial.Shadewood)
		},
		{
			4105,
			(FurnitureType.Toilet, FurnitureMaterial.Shadewood)
		},
		{
			927,
			(FurnitureType.Wall, FurnitureMaterial.Shadewood)
		},
		{
			916,
			(FurnitureType.WorkBench, FurnitureMaterial.Shadewood)
		},
		{
			2519,
			(FurnitureType.Bathtub, FurnitureMaterial.PalmWood)
		},
		{
			2520,
			(FurnitureType.Bed, FurnitureMaterial.PalmWood)
		},
		{
			2536,
			(FurnitureType.Bookcase, FurnitureMaterial.PalmWood)
		},
		{
			2522,
			(FurnitureType.Candelabra, FurnitureMaterial.PalmWood)
		},
		{
			2523,
			(FurnitureType.Candle, FurnitureMaterial.PalmWood)
		},
		{
			2524,
			(FurnitureType.Chair, FurnitureMaterial.PalmWood)
		},
		{
			2526,
			(FurnitureType.Chest, FurnitureMaterial.PalmWood)
		},
		{
			3687,
			(FurnitureType.ChestTrapped, FurnitureMaterial.PalmWood)
		},
		{
			2601,
			(FurnitureType.Clock, FurnitureMaterial.PalmWood)
		},
		{
			2528,
			(FurnitureType.Door, FurnitureMaterial.PalmWood)
		},
		{
			2529,
			(FurnitureType.Dresser, FurnitureMaterial.PalmWood)
		},
		{
			2508,
			(FurnitureType.Fence, FurnitureMaterial.PalmWood)
		},
		{
			2533,
			(FurnitureType.Lamp, FurnitureMaterial.PalmWood)
		},
		{
			2530,
			(FurnitureType.Lantern, FurnitureMaterial.PalmWood)
		},
		{
			2531,
			(FurnitureType.Piano, FurnitureMaterial.PalmWood)
		},
		{
			2518,
			(FurnitureType.Platform, FurnitureMaterial.PalmWood)
		},
		{
			2850,
			(FurnitureType.Sink, FurnitureMaterial.PalmWood)
		},
		{
			2527,
			(FurnitureType.Sofa, FurnitureMaterial.PalmWood)
		},
		{
			2532,
			(FurnitureType.Table, FurnitureMaterial.PalmWood)
		},
		{
			4118,
			(FurnitureType.Toilet, FurnitureMaterial.PalmWood)
		},
		{
			2506,
			(FurnitureType.Wall, FurnitureMaterial.PalmWood)
		},
		{
			2534,
			(FurnitureType.WorkBench, FurnitureMaterial.PalmWood)
		},
		{
			2077,
			(FurnitureType.Bathtub, FurnitureMaterial.JungleWood)
		},
		{
			645,
			(FurnitureType.Bed, FurnitureMaterial.JungleWood)
		},
		{
			2026,
			(FurnitureType.Bookcase, FurnitureMaterial.JungleWood)
		},
		{
			2098,
			(FurnitureType.Candelabra, FurnitureMaterial.JungleWood)
		},
		{
			2050,
			(FurnitureType.Candle, FurnitureMaterial.JungleWood)
		},
		{
			629,
			(FurnitureType.Chair, FurnitureMaterial.JungleWood)
		},
		{
			626,
			(FurnitureType.Chest, FurnitureMaterial.JungleWood)
		},
		{
			3669,
			(FurnitureType.ChestTrapped, FurnitureMaterial.JungleWood)
		},
		{
			2597,
			(FurnitureType.Clock, FurnitureMaterial.JungleWood)
		},
		{
			651,
			(FurnitureType.Door, FurnitureMaterial.JungleWood)
		},
		{
			648,
			(FurnitureType.Dresser, FurnitureMaterial.JungleWood)
		},
		{
			2211,
			(FurnitureType.Fence, FurnitureMaterial.JungleWood)
		},
		{
			2087,
			(FurnitureType.Lamp, FurnitureMaterial.JungleWood)
		},
		{
			2038,
			(FurnitureType.Lantern, FurnitureMaterial.JungleWood)
		},
		{
			642,
			(FurnitureType.Piano, FurnitureMaterial.JungleWood)
		},
		{
			632,
			(FurnitureType.Platform, FurnitureMaterial.JungleWood)
		},
		{
			2829,
			(FurnitureType.Sink, FurnitureMaterial.JungleWood)
		},
		{
			2399,
			(FurnitureType.Sofa, FurnitureMaterial.JungleWood)
		},
		{
			639,
			(FurnitureType.Table, FurnitureMaterial.JungleWood)
		},
		{
			4097,
			(FurnitureType.Toilet, FurnitureMaterial.JungleWood)
		},
		{
			623,
			(FurnitureType.Wall, FurnitureMaterial.JungleWood)
		},
		{
			636,
			(FurnitureType.WorkBench, FurnitureMaterial.JungleWood)
		},
		{
			2078,
			(FurnitureType.Bathtub, FurnitureMaterial.Pearlwood)
		},
		{
			646,
			(FurnitureType.Bed, FurnitureMaterial.Pearlwood)
		},
		{
			2027,
			(FurnitureType.Bookcase, FurnitureMaterial.Pearlwood)
		},
		{
			2099,
			(FurnitureType.Candelabra, FurnitureMaterial.Pearlwood)
		},
		{
			2051,
			(FurnitureType.Candle, FurnitureMaterial.Pearlwood)
		},
		{
			630,
			(FurnitureType.Chair, FurnitureMaterial.Pearlwood)
		},
		{
			627,
			(FurnitureType.Chest, FurnitureMaterial.Pearlwood)
		},
		{
			3670,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Pearlwood)
		},
		{
			2602,
			(FurnitureType.Clock, FurnitureMaterial.Pearlwood)
		},
		{
			652,
			(FurnitureType.Door, FurnitureMaterial.Pearlwood)
		},
		{
			649,
			(FurnitureType.Dresser, FurnitureMaterial.Pearlwood)
		},
		{
			2212,
			(FurnitureType.Fence, FurnitureMaterial.Pearlwood)
		},
		{
			2088,
			(FurnitureType.Lamp, FurnitureMaterial.Pearlwood)
		},
		{
			2039,
			(FurnitureType.Lantern, FurnitureMaterial.Pearlwood)
		},
		{
			643,
			(FurnitureType.Piano, FurnitureMaterial.Pearlwood)
		},
		{
			633,
			(FurnitureType.Platform, FurnitureMaterial.Pearlwood)
		},
		{
			2830,
			(FurnitureType.Sink, FurnitureMaterial.Pearlwood)
		},
		{
			2400,
			(FurnitureType.Sofa, FurnitureMaterial.Pearlwood)
		},
		{
			640,
			(FurnitureType.Table, FurnitureMaterial.Pearlwood)
		},
		{
			4098,
			(FurnitureType.Toilet, FurnitureMaterial.Pearlwood)
		},
		{
			624,
			(FurnitureType.Wall, FurnitureMaterial.Pearlwood)
		},
		{
			637,
			(FurnitureType.WorkBench, FurnitureMaterial.Pearlwood)
		},
		{
			5190,
			(FurnitureType.Bathtub, FurnitureMaterial.AshWood)
		},
		{
			5191,
			(FurnitureType.Bed, FurnitureMaterial.AshWood)
		},
		{
			5192,
			(FurnitureType.Bookcase, FurnitureMaterial.AshWood)
		},
		{
			5194,
			(FurnitureType.Candelabra, FurnitureMaterial.AshWood)
		},
		{
			5195,
			(FurnitureType.Candle, FurnitureMaterial.AshWood)
		},
		{
			5196,
			(FurnitureType.Chair, FurnitureMaterial.AshWood)
		},
		{
			5198,
			(FurnitureType.Chest, FurnitureMaterial.AshWood)
		},
		{
			5209,
			(FurnitureType.ChestTrapped, FurnitureMaterial.AshWood)
		},
		{
			5199,
			(FurnitureType.Clock, FurnitureMaterial.AshWood)
		},
		{
			5200,
			(FurnitureType.Door, FurnitureMaterial.AshWood)
		},
		{
			5193,
			(FurnitureType.Dresser, FurnitureMaterial.AshWood)
		},
		{
			5217,
			(FurnitureType.Fence, FurnitureMaterial.AshWood)
		},
		{
			5201,
			(FurnitureType.Lamp, FurnitureMaterial.AshWood)
		},
		{
			5202,
			(FurnitureType.Lantern, FurnitureMaterial.AshWood)
		},
		{
			5203,
			(FurnitureType.Piano, FurnitureMaterial.AshWood)
		},
		{
			5204,
			(FurnitureType.Platform, FurnitureMaterial.AshWood)
		},
		{
			5205,
			(FurnitureType.Sink, FurnitureMaterial.AshWood)
		},
		{
			5206,
			(FurnitureType.Sofa, FurnitureMaterial.AshWood)
		},
		{
			5207,
			(FurnitureType.Table, FurnitureMaterial.AshWood)
		},
		{
			5210,
			(FurnitureType.Toilet, FurnitureMaterial.AshWood)
		},
		{
			5216,
			(FurnitureType.Wall, FurnitureMaterial.AshWood)
		},
		{
			5208,
			(FurnitureType.WorkBench, FurnitureMaterial.AshWood)
		},
		{
			2081,
			(FurnitureType.Bathtub, FurnitureMaterial.SpookyWood)
		},
		{
			2071,
			(FurnitureType.Bed, FurnitureMaterial.SpookyWood)
		},
		{
			2028,
			(FurnitureType.Bookcase, FurnitureMaterial.SpookyWood)
		},
		{
			2103,
			(FurnitureType.Candelabra, FurnitureMaterial.SpookyWood)
		},
		{
			2650,
			(FurnitureType.Candle, FurnitureMaterial.SpookyWood)
		},
		{
			1814,
			(FurnitureType.Chair, FurnitureMaterial.SpookyWood)
		},
		{
			2620,
			(FurnitureType.Chest, FurnitureMaterial.SpookyWood)
		},
		{
			3699,
			(FurnitureType.ChestTrapped, FurnitureMaterial.SpookyWood)
		},
		{
			2605,
			(FurnitureType.Clock, FurnitureMaterial.SpookyWood)
		},
		{
			1815,
			(FurnitureType.Door, FurnitureMaterial.SpookyWood)
		},
		{
			2393,
			(FurnitureType.Dresser, FurnitureMaterial.SpookyWood)
		},
		{
			2091,
			(FurnitureType.Lamp, FurnitureMaterial.SpookyWood)
		},
		{
			2043,
			(FurnitureType.Lantern, FurnitureMaterial.SpookyWood)
		},
		{
			2383,
			(FurnitureType.Piano, FurnitureMaterial.SpookyWood)
		},
		{
			1818,
			(FurnitureType.Platform, FurnitureMaterial.SpookyWood)
		},
		{
			2847,
			(FurnitureType.Sink, FurnitureMaterial.SpookyWood)
		},
		{
			2409,
			(FurnitureType.Sofa, FurnitureMaterial.SpookyWood)
		},
		{
			1816,
			(FurnitureType.Table, FurnitureMaterial.SpookyWood)
		},
		{
			4116,
			(FurnitureType.Toilet, FurnitureMaterial.SpookyWood)
		},
		{
			1730,
			(FurnitureType.Wall, FurnitureMaterial.SpookyWood)
		},
		{
			1817,
			(FurnitureType.WorkBench, FurnitureMaterial.SpookyWood)
		},
		{
			4566,
			(FurnitureType.Bathtub, FurnitureMaterial.Bamboo)
		},
		{
			4567,
			(FurnitureType.Bed, FurnitureMaterial.Bamboo)
		},
		{
			4568,
			(FurnitureType.Bookcase, FurnitureMaterial.Bamboo)
		},
		{
			4570,
			(FurnitureType.Candelabra, FurnitureMaterial.Bamboo)
		},
		{
			4571,
			(FurnitureType.Candle, FurnitureMaterial.Bamboo)
		},
		{
			4572,
			(FurnitureType.Chair, FurnitureMaterial.Bamboo)
		},
		{
			4574,
			(FurnitureType.Chest, FurnitureMaterial.Bamboo)
		},
		{
			4585,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Bamboo)
		},
		{
			4575,
			(FurnitureType.Clock, FurnitureMaterial.Bamboo)
		},
		{
			4576,
			(FurnitureType.Door, FurnitureMaterial.Bamboo)
		},
		{
			4569,
			(FurnitureType.Dresser, FurnitureMaterial.Bamboo)
		},
		{
			4667,
			(FurnitureType.Fence, FurnitureMaterial.Bamboo)
		},
		{
			4577,
			(FurnitureType.Lamp, FurnitureMaterial.Bamboo)
		},
		{
			4578,
			(FurnitureType.Lantern, FurnitureMaterial.Bamboo)
		},
		{
			4579,
			(FurnitureType.Piano, FurnitureMaterial.Bamboo)
		},
		{
			4580,
			(FurnitureType.Platform, FurnitureMaterial.Bamboo)
		},
		{
			4581,
			(FurnitureType.Sink, FurnitureMaterial.Bamboo)
		},
		{
			4582,
			(FurnitureType.Sofa, FurnitureMaterial.Bamboo)
		},
		{
			4583,
			(FurnitureType.Table, FurnitureMaterial.Bamboo)
		},
		{
			4586,
			(FurnitureType.Toilet, FurnitureMaterial.Bamboo)
		},
		{
			4565,
			(FurnitureType.Wall, FurnitureMaterial.Bamboo)
		},
		{
			4584,
			(FurnitureType.WorkBench, FurnitureMaterial.Bamboo)
		},
		{
			2072,
			(FurnitureType.Bathtub, FurnitureMaterial.Cactus)
		},
		{
			2066,
			(FurnitureType.Bed, FurnitureMaterial.Cactus)
		},
		{
			2020,
			(FurnitureType.Bookcase, FurnitureMaterial.Cactus)
		},
		{
			2092,
			(FurnitureType.Candelabra, FurnitureMaterial.Cactus)
		},
		{
			2045,
			(FurnitureType.Candle, FurnitureMaterial.Cactus)
		},
		{
			807,
			(FurnitureType.Chair, FurnitureMaterial.Cactus)
		},
		{
			2616,
			(FurnitureType.Chest, FurnitureMaterial.Cactus)
		},
		{
			3695,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Cactus)
		},
		{
			2592,
			(FurnitureType.Clock, FurnitureMaterial.Cactus)
		},
		{
			816,
			(FurnitureType.Door, FurnitureMaterial.Cactus)
		},
		{
			2392,
			(FurnitureType.Dresser, FurnitureMaterial.Cactus)
		},
		{
			2082,
			(FurnitureType.Lamp, FurnitureMaterial.Cactus)
		},
		{
			2032,
			(FurnitureType.Lantern, FurnitureMaterial.Cactus)
		},
		{
			2382,
			(FurnitureType.Piano, FurnitureMaterial.Cactus)
		},
		{
			2744,
			(FurnitureType.Platform, FurnitureMaterial.Cactus)
		},
		{
			2854,
			(FurnitureType.Sink, FurnitureMaterial.Cactus)
		},
		{
			2408,
			(FurnitureType.Sofa, FurnitureMaterial.Cactus)
		},
		{
			2743,
			(FurnitureType.Table, FurnitureMaterial.Cactus)
		},
		{
			4100,
			(FurnitureType.Toilet, FurnitureMaterial.Cactus)
		},
		{
			750,
			(FurnitureType.Wall, FurnitureMaterial.Cactus)
		},
		{
			812,
			(FurnitureType.WorkBench, FurnitureMaterial.Cactus)
		},
		{
			2661,
			(FurnitureType.Bathtub, FurnitureMaterial.Pumpkin)
		},
		{
			2669,
			(FurnitureType.Bed, FurnitureMaterial.Pumpkin)
		},
		{
			2670,
			(FurnitureType.Bookcase, FurnitureMaterial.Pumpkin)
		},
		{
			2668,
			(FurnitureType.Candelabra, FurnitureMaterial.Pumpkin)
		},
		{
			2054,
			(FurnitureType.Candle, FurnitureMaterial.Pumpkin)
		},
		{
			1792,
			(FurnitureType.Chair, FurnitureMaterial.Pumpkin)
		},
		{
			2619,
			(FurnitureType.Chest, FurnitureMaterial.Pumpkin)
		},
		{
			3698,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Pumpkin)
		},
		{
			2603,
			(FurnitureType.Clock, FurnitureMaterial.Pumpkin)
		},
		{
			1793,
			(FurnitureType.Door, FurnitureMaterial.Pumpkin)
		},
		{
			2637,
			(FurnitureType.Dresser, FurnitureMaterial.Pumpkin)
		},
		{
			2643,
			(FurnitureType.Lamp, FurnitureMaterial.Pumpkin)
		},
		{
			2641,
			(FurnitureType.Lantern, FurnitureMaterial.Pumpkin)
		},
		{
			2671,
			(FurnitureType.Piano, FurnitureMaterial.Pumpkin)
		},
		{
			1796,
			(FurnitureType.Platform, FurnitureMaterial.Pumpkin)
		},
		{
			2846,
			(FurnitureType.Sink, FurnitureMaterial.Pumpkin)
		},
		{
			2415,
			(FurnitureType.Sofa, FurnitureMaterial.Pumpkin)
		},
		{
			1794,
			(FurnitureType.Table, FurnitureMaterial.Pumpkin)
		},
		{
			4115,
			(FurnitureType.Toilet, FurnitureMaterial.Pumpkin)
		},
		{
			1726,
			(FurnitureType.Wall, FurnitureMaterial.Pumpkin)
		},
		{
			1795,
			(FurnitureType.WorkBench, FurnitureMaterial.Pumpkin)
		},
		{
			2537,
			(FurnitureType.Bathtub, FurnitureMaterial.Mushroom)
		},
		{
			2538,
			(FurnitureType.Bed, FurnitureMaterial.Mushroom)
		},
		{
			2540,
			(FurnitureType.Bookcase, FurnitureMaterial.Mushroom)
		},
		{
			2541,
			(FurnitureType.Candelabra, FurnitureMaterial.Mushroom)
		},
		{
			2542,
			(FurnitureType.Candle, FurnitureMaterial.Mushroom)
		},
		{
			810,
			(FurnitureType.Chair, FurnitureMaterial.Mushroom)
		},
		{
			2544,
			(FurnitureType.Chest, FurnitureMaterial.Mushroom)
		},
		{
			3688,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Mushroom)
		},
		{
			2599,
			(FurnitureType.Clock, FurnitureMaterial.Mushroom)
		},
		{
			818,
			(FurnitureType.Door, FurnitureMaterial.Mushroom)
		},
		{
			2545,
			(FurnitureType.Dresser, FurnitureMaterial.Mushroom)
		},
		{
			2547,
			(FurnitureType.Lamp, FurnitureMaterial.Mushroom)
		},
		{
			2546,
			(FurnitureType.Lantern, FurnitureMaterial.Mushroom)
		},
		{
			2548,
			(FurnitureType.Piano, FurnitureMaterial.Mushroom)
		},
		{
			2549,
			(FurnitureType.Platform, FurnitureMaterial.Mushroom)
		},
		{
			2851,
			(FurnitureType.Sink, FurnitureMaterial.Mushroom)
		},
		{
			2413,
			(FurnitureType.Sofa, FurnitureMaterial.Mushroom)
		},
		{
			2550,
			(FurnitureType.Table, FurnitureMaterial.Mushroom)
		},
		{
			4103,
			(FurnitureType.Toilet, FurnitureMaterial.Mushroom)
		},
		{
			764,
			(FurnitureType.Wall, FurnitureMaterial.Mushroom)
		},
		{
			814,
			(FurnitureType.WorkBench, FurnitureMaterial.Mushroom)
		},
		{
			3160,
			(FurnitureType.Bathtub, FurnitureMaterial.Marble)
		},
		{
			3163,
			(FurnitureType.Bed, FurnitureMaterial.Marble)
		},
		{
			3166,
			(FurnitureType.Bookcase, FurnitureMaterial.Marble)
		},
		{
			3169,
			(FurnitureType.Candelabra, FurnitureMaterial.Marble)
		},
		{
			3172,
			(FurnitureType.Candle, FurnitureMaterial.Marble)
		},
		{
			3175,
			(FurnitureType.Chair, FurnitureMaterial.Marble)
		},
		{
			3181,
			(FurnitureType.Chest, FurnitureMaterial.Marble)
		},
		{
			3704,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Marble)
		},
		{
			3127,
			(FurnitureType.Clock, FurnitureMaterial.Marble)
		},
		{
			3130,
			(FurnitureType.Door, FurnitureMaterial.Marble)
		},
		{
			3133,
			(FurnitureType.Dresser, FurnitureMaterial.Marble)
		},
		{
			3136,
			(FurnitureType.Lamp, FurnitureMaterial.Marble)
		},
		{
			3139,
			(FurnitureType.Lantern, FurnitureMaterial.Marble)
		},
		{
			3142,
			(FurnitureType.Piano, FurnitureMaterial.Marble)
		},
		{
			3145,
			(FurnitureType.Platform, FurnitureMaterial.Marble)
		},
		{
			3148,
			(FurnitureType.Sink, FurnitureMaterial.Marble)
		},
		{
			3151,
			(FurnitureType.Sofa, FurnitureMaterial.Marble)
		},
		{
			3154,
			(FurnitureType.Table, FurnitureMaterial.Marble)
		},
		{
			4123,
			(FurnitureType.Toilet, FurnitureMaterial.Marble)
		},
		{
			3082,
			(FurnitureType.Wall, FurnitureMaterial.Marble)
		},
		{
			3157,
			(FurnitureType.WorkBench, FurnitureMaterial.Marble)
		},
		{
			3161,
			(FurnitureType.Bathtub, FurnitureMaterial.Granite)
		},
		{
			3164,
			(FurnitureType.Bed, FurnitureMaterial.Granite)
		},
		{
			3167,
			(FurnitureType.Bookcase, FurnitureMaterial.Granite)
		},
		{
			3170,
			(FurnitureType.Candelabra, FurnitureMaterial.Granite)
		},
		{
			3173,
			(FurnitureType.Candle, FurnitureMaterial.Granite)
		},
		{
			3176,
			(FurnitureType.Chair, FurnitureMaterial.Granite)
		},
		{
			3125,
			(FurnitureType.Chest, FurnitureMaterial.Granite)
		},
		{
			3703,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Granite)
		},
		{
			3128,
			(FurnitureType.Clock, FurnitureMaterial.Granite)
		},
		{
			3131,
			(FurnitureType.Door, FurnitureMaterial.Granite)
		},
		{
			3134,
			(FurnitureType.Dresser, FurnitureMaterial.Granite)
		},
		{
			3137,
			(FurnitureType.Lamp, FurnitureMaterial.Granite)
		},
		{
			3140,
			(FurnitureType.Lantern, FurnitureMaterial.Granite)
		},
		{
			3143,
			(FurnitureType.Piano, FurnitureMaterial.Granite)
		},
		{
			3146,
			(FurnitureType.Platform, FurnitureMaterial.Granite)
		},
		{
			3149,
			(FurnitureType.Sink, FurnitureMaterial.Granite)
		},
		{
			3152,
			(FurnitureType.Sofa, FurnitureMaterial.Granite)
		},
		{
			3155,
			(FurnitureType.Table, FurnitureMaterial.Granite)
		},
		{
			4122,
			(FurnitureType.Toilet, FurnitureMaterial.Granite)
		},
		{
			3088,
			(FurnitureType.Wall, FurnitureMaterial.Granite)
		},
		{
			3158,
			(FurnitureType.WorkBench, FurnitureMaterial.Granite)
		},
		{
			4298,
			(FurnitureType.Bathtub, FurnitureMaterial.Sandstone)
		},
		{
			4299,
			(FurnitureType.Bed, FurnitureMaterial.Sandstone)
		},
		{
			4300,
			(FurnitureType.Bookcase, FurnitureMaterial.Sandstone)
		},
		{
			4302,
			(FurnitureType.Candelabra, FurnitureMaterial.Sandstone)
		},
		{
			4303,
			(FurnitureType.Candle, FurnitureMaterial.Sandstone)
		},
		{
			4304,
			(FurnitureType.Chair, FurnitureMaterial.Sandstone)
		},
		{
			4267,
			(FurnitureType.Chest, FurnitureMaterial.Sandstone)
		},
		{
			4268,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Sandstone)
		},
		{
			4306,
			(FurnitureType.Clock, FurnitureMaterial.Sandstone)
		},
		{
			4307,
			(FurnitureType.Door, FurnitureMaterial.Sandstone)
		},
		{
			4301,
			(FurnitureType.Dresser, FurnitureMaterial.Sandstone)
		},
		{
			4308,
			(FurnitureType.Lamp, FurnitureMaterial.Sandstone)
		},
		{
			4309,
			(FurnitureType.Lantern, FurnitureMaterial.Sandstone)
		},
		{
			4310,
			(FurnitureType.Piano, FurnitureMaterial.Sandstone)
		},
		{
			4311,
			(FurnitureType.Platform, FurnitureMaterial.Sandstone)
		},
		{
			4312,
			(FurnitureType.Sink, FurnitureMaterial.Sandstone)
		},
		{
			4313,
			(FurnitureType.Sofa, FurnitureMaterial.Sandstone)
		},
		{
			4314,
			(FurnitureType.Table, FurnitureMaterial.Sandstone)
		},
		{
			4316,
			(FurnitureType.Toilet, FurnitureMaterial.Sandstone)
		},
		{
			3273,
			(FurnitureType.Wall, FurnitureMaterial.Sandstone)
		},
		{
			4315,
			(FurnitureType.WorkBench, FurnitureMaterial.Sandstone)
		},
		{
			2076,
			(FurnitureType.Bathtub, FurnitureMaterial.Ice)
		},
		{
			2068,
			(FurnitureType.Bed, FurnitureMaterial.Ice)
		},
		{
			2031,
			(FurnitureType.Bookcase, FurnitureMaterial.Ice)
		},
		{
			2100,
			(FurnitureType.Candelabra, FurnitureMaterial.Ice)
		},
		{
			2049,
			(FurnitureType.Candle, FurnitureMaterial.Ice)
		},
		{
			2288,
			(FurnitureType.Chair, FurnitureMaterial.Ice)
		},
		{
			1532,
			(FurnitureType.Chest, FurnitureMaterial.Ice)
		},
		{
			3683,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Ice)
		},
		{
			2594,
			(FurnitureType.Clock, FurnitureMaterial.Ice)
		},
		{
			2044,
			(FurnitureType.Door, FurnitureMaterial.Ice)
		},
		{
			3913,
			(FurnitureType.Dresser, FurnitureMaterial.Ice)
		},
		{
			2086,
			(FurnitureType.Lamp, FurnitureMaterial.Ice)
		},
		{
			2040,
			(FurnitureType.Lantern, FurnitureMaterial.Ice)
		},
		{
			2247,
			(FurnitureType.Piano, FurnitureMaterial.Ice)
		},
		{
			3908,
			(FurnitureType.Platform, FurnitureMaterial.Ice)
		},
		{
			2848,
			(FurnitureType.Sink, FurnitureMaterial.Ice)
		},
		{
			2635,
			(FurnitureType.Sofa, FurnitureMaterial.Ice)
		},
		{
			2248,
			(FurnitureType.Table, FurnitureMaterial.Ice)
		},
		{
			4111,
			(FurnitureType.Toilet, FurnitureMaterial.Ice)
		},
		{
			2252,
			(FurnitureType.WorkBench, FurnitureMaterial.Ice)
		},
		{
			5148,
			(FurnitureType.Bathtub, FurnitureMaterial.Coral)
		},
		{
			5149,
			(FurnitureType.Bed, FurnitureMaterial.Coral)
		},
		{
			5150,
			(FurnitureType.Bookcase, FurnitureMaterial.Coral)
		},
		{
			5152,
			(FurnitureType.Candelabra, FurnitureMaterial.Coral)
		},
		{
			5153,
			(FurnitureType.Candle, FurnitureMaterial.Coral)
		},
		{
			5154,
			(FurnitureType.Chair, FurnitureMaterial.Coral)
		},
		{
			5156,
			(FurnitureType.Chest, FurnitureMaterial.Coral)
		},
		{
			5167,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Coral)
		},
		{
			5157,
			(FurnitureType.Clock, FurnitureMaterial.Coral)
		},
		{
			5158,
			(FurnitureType.Door, FurnitureMaterial.Coral)
		},
		{
			5151,
			(FurnitureType.Dresser, FurnitureMaterial.Coral)
		},
		{
			5159,
			(FurnitureType.Lamp, FurnitureMaterial.Coral)
		},
		{
			5160,
			(FurnitureType.Lantern, FurnitureMaterial.Coral)
		},
		{
			5161,
			(FurnitureType.Piano, FurnitureMaterial.Coral)
		},
		{
			5162,
			(FurnitureType.Platform, FurnitureMaterial.Coral)
		},
		{
			5163,
			(FurnitureType.Sink, FurnitureMaterial.Coral)
		},
		{
			5164,
			(FurnitureType.Sofa, FurnitureMaterial.Coral)
		},
		{
			5165,
			(FurnitureType.Table, FurnitureMaterial.Coral)
		},
		{
			5168,
			(FurnitureType.Toilet, FurnitureMaterial.Coral)
		},
		{
			5307,
			(FurnitureType.Wall, FurnitureMaterial.Coral)
		},
		{
			5166,
			(FurnitureType.WorkBench, FurnitureMaterial.Coral)
		},
		{
			2663,
			(FurnitureType.Bathtub, FurnitureMaterial.Golden)
		},
		{
			1720,
			(FurnitureType.Bed, FurnitureMaterial.Golden)
		},
		{
			2137,
			(FurnitureType.Bookcase, FurnitureMaterial.Golden)
		},
		{
			2151,
			(FurnitureType.Candelabra, FurnitureMaterial.Golden)
		},
		{
			2155,
			(FurnitureType.Candle, FurnitureMaterial.Golden)
		},
		{
			1704,
			(FurnitureType.Chair, FurnitureMaterial.Golden)
		},
		{
			2143,
			(FurnitureType.Chandelier, FurnitureMaterial.Golden)
		},
		{
			3885,
			(FurnitureType.Chest, FurnitureMaterial.Golden)
		},
		{
			3887,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Golden)
		},
		{
			2238,
			(FurnitureType.Clock, FurnitureMaterial.Golden)
		},
		{
			1710,
			(FurnitureType.Door, FurnitureMaterial.Golden)
		},
		{
			2389,
			(FurnitureType.Dresser, FurnitureMaterial.Golden)
		},
		{
			2133,
			(FurnitureType.Lamp, FurnitureMaterial.Golden)
		},
		{
			2147,
			(FurnitureType.Lantern, FurnitureMaterial.Golden)
		},
		{
			2379,
			(FurnitureType.Piano, FurnitureMaterial.Golden)
		},
		{
			3904,
			(FurnitureType.Platform, FurnitureMaterial.Golden)
		},
		{
			2843,
			(FurnitureType.Sink, FurnitureMaterial.Golden)
		},
		{
			2405,
			(FurnitureType.Sofa, FurnitureMaterial.Golden)
		},
		{
			1716,
			(FurnitureType.Table, FurnitureMaterial.Golden)
		},
		{
			1705,
			(FurnitureType.Toilet, FurnitureMaterial.Golden)
		},
		{
			3910,
			(FurnitureType.WorkBench, FurnitureMaterial.Golden)
		},
		{
			3895,
			(FurnitureType.Bathtub, FurnitureMaterial.Crystal)
		},
		{
			3897,
			(FurnitureType.Bed, FurnitureMaterial.Crystal)
		},
		{
			3917,
			(FurnitureType.Bookcase, FurnitureMaterial.Crystal)
		},
		{
			3893,
			(FurnitureType.Candelabra, FurnitureMaterial.Crystal)
		},
		{
			3890,
			(FurnitureType.Candle, FurnitureMaterial.Crystal)
		},
		{
			3889,
			(FurnitureType.Chair, FurnitureMaterial.Crystal)
		},
		{
			3894,
			(FurnitureType.Chandelier, FurnitureMaterial.Crystal)
		},
		{
			3884,
			(FurnitureType.Chest, FurnitureMaterial.Crystal)
		},
		{
			3886,
			(FurnitureType.ChestTrapped, FurnitureMaterial.Crystal)
		},
		{
			3898,
			(FurnitureType.Clock, FurnitureMaterial.Crystal)
		},
		{
			3888,
			(FurnitureType.Door, FurnitureMaterial.Crystal)
		},
		{
			3911,
			(FurnitureType.Dresser, FurnitureMaterial.Crystal)
		},
		{
			3892,
			(FurnitureType.Lamp, FurnitureMaterial.Crystal)
		},
		{
			3891,
			(FurnitureType.Lantern, FurnitureMaterial.Crystal)
		},
		{
			3915,
			(FurnitureType.Piano, FurnitureMaterial.Crystal)
		},
		{
			3903,
			(FurnitureType.Platform, FurnitureMaterial.Crystal)
		},
		{
			3896,
			(FurnitureType.Sink, FurnitureMaterial.Crystal)
		},
		{
			3918,
			(FurnitureType.Sofa, FurnitureMaterial.Crystal)
		},
		{
			3920,
			(FurnitureType.Table, FurnitureMaterial.Crystal)
		},
		{
			4124,
			(FurnitureType.Toilet, FurnitureMaterial.Crystal)
		},
		{
			3238,
			(FurnitureType.Wall, FurnitureMaterial.Crystal)
		},
		{
			3909,
			(FurnitureType.WorkBench, FurnitureMaterial.Crystal)
		}
	};

	public static Dictionary<FurnitureMaterial, (double HealthMult, int AcidResist)> FurnitureMaterialMappings => new Dictionary<FurnitureMaterial, (double, int)>
	{
		{
			FurnitureMaterial.OakWood,
			(1.0, 0)
		},
		{
			FurnitureMaterial.BorealWood,
			(1.015, 0)
		},
		{
			FurnitureMaterial.PalmWood,
			(1.025, 0)
		},
		{
			FurnitureMaterial.Ebonwood,
			(1.05, 0)
		},
		{
			FurnitureMaterial.Shadewood,
			(1.05, 0)
		},
		{
			FurnitureMaterial.JungleWood,
			(1.08, 0)
		},
		{
			FurnitureMaterial.Pearlwood,
			(1.08, 0)
		},
		{
			FurnitureMaterial.AshWood,
			(0.925, 0)
		},
		{
			FurnitureMaterial.SpookyWood,
			(1.85, 0)
		},
		{
			FurnitureMaterial.Bamboo,
			(1.085, 0)
		},
		{
			FurnitureMaterial.Cactus,
			(1.1, 0)
		},
		{
			FurnitureMaterial.Pumpkin,
			(0.985, 0)
		},
		{
			FurnitureMaterial.Mushroom,
			(1.035, 0)
		},
		{
			FurnitureMaterial.Marble,
			(2.125, 1)
		},
		{
			FurnitureMaterial.Granite,
			(2.215, 1)
		},
		{
			FurnitureMaterial.Sandstone,
			(2.15, 0)
		},
		{
			FurnitureMaterial.Ice,
			(0.95, 0)
		},
		{
			FurnitureMaterial.Coral,
			(1.25, 0)
		},
		{
			FurnitureMaterial.Golden,
			(3.75, 2)
		},
		{
			FurnitureMaterial.Crystal,
			(1.4, 1)
		}
	};

	public static Dictionary<FurnitureType, (int BaseHealth, double Size)> FurnitureTypeMappings => new Dictionary<FurnitureType, (int, double)>
	{
		{
			FurnitureType.Bathtub,
			(600, 3.2)
		},
		{
			FurnitureType.Bed,
			(535, 2.7)
		},
		{
			FurnitureType.Bookcase,
			(725, 3.8)
		},
		{
			FurnitureType.Candelabra,
			(340, 0.725)
		},
		{
			FurnitureType.Candle,
			(85, 0.28)
		},
		{
			FurnitureType.Chair,
			(185, 1.075)
		},
		{
			FurnitureType.Chandelier,
			(485, 1.15)
		},
		{
			FurnitureType.Chest,
			(270, 1.12)
		},
		{
			FurnitureType.ChestTrapped,
			(270, 1.12)
		},
		{
			FurnitureType.Clock,
			(320, 3.2)
		},
		{
			FurnitureType.Door,
			(250, 1.0)
		},
		{
			FurnitureType.DoorTall,
			(500, 1.7)
		},
		{
			FurnitureType.Dresser,
			(680, 3.85)
		},
		{
			FurnitureType.Fence,
			(335, 1.35)
		},
		{
			FurnitureType.Lamp,
			(210, 0.65)
		},
		{
			FurnitureType.Lantern,
			(220, 0.675)
		},
		{
			FurnitureType.Piano,
			(1000, 3.65)
		},
		{
			FurnitureType.Platform,
			(40, 0.05)
		},
		{
			FurnitureType.Sink,
			(325, 1.85)
		},
		{
			FurnitureType.Sofa,
			(880, 4.0)
		},
		{
			FurnitureType.Table,
			(365, 2.15)
		},
		{
			FurnitureType.Toilet,
			(350, 1.44)
		},
		{
			FurnitureType.Wall,
			(500, 2.0)
		},
		{
			FurnitureType.WorkBench,
			(140, 0.55)
		}
	};

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return FurnitureDefinitionMappings.ContainsKey(entity.type);
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().Size = FurnitureTypeMappings[FurnitureDefinitionMappings[item.type].Type].Size;
		item.AsFood().MaxHealth = (int)Math.Round((double)FurnitureTypeMappings[FurnitureDefinitionMappings[item.type].Type].BaseHealth * FurnitureMaterialMappings[FurnitureDefinitionMappings[item.type].Material].HealthMult);
		item.AsFood().AcidResistTier = FurnitureMaterialMappings[FurnitureDefinitionMappings[item.type].Material].AcidResist;
		PreyItem preyItem = item.AsFood();
		preyItem.OnSwallow = (PreyItem.DelegateOnSwallow)Delegate.Combine(preyItem.OnSwallow, new PreyItem.DelegateOnSwallow(OnSwallow_GrantFurnitureGoals));
	}

	public static void OnSwallow_GrantFurnitureGoals(Item item, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<SwallowAnyFurniture>().TrySetCompletion(predPlayer);
		}
	}
}
