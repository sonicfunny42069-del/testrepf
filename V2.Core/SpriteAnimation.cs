using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace V2.Core;

public abstract class SpriteAnimation : ModTexturedType
{
	public abstract override string Texture { get; }

	public bool CanTransitionToNewAnim
	{
		get
		{
			if (FrameDictPos == 0)
			{
				return (double)FrameDelay == (double)Frames[0].rawDelay * 0.6;
			}
			return false;
		}
	}

	public abstract List<(int frame, int rawDelay)> Frames { get; }

	public int FrameDictPos { get; set; }

	public int FrameID
	{
		get
		{
			if (Frames == null)
			{
				return 0;
			}
			return Frames[FrameDictPos].frame;
		}
	}

	public int FrameDelay { get; set; }

	protected sealed override void Register()
	{
	}

	public abstract Rectangle? DecideFrame();

	public void Initialize()
	{
		FrameDictPos = 0;
		FrameDelay = (int)Math.Round((double)Frames[0].rawDelay * 0.6);
	}

	public void Advance(int speed = 1)
	{
		FrameDelay -= speed;
		if (FrameDelay <= 0)
		{
			FrameDictPos++;
			FrameDictPos %= Frames.Count;
			FrameDelay = (int)Math.Round((double)Frames[FrameDictPos].rawDelay * 0.6);
		}
	}
}
