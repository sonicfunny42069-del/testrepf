using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace V2.Core;

public abstract class NPCBehaviorPattern
{
	public int PatternTimer;

	public int SecondaryTimer;

	public List<Vector2> TempData;

	public virtual int PatternLength { get; set; }

	public NPCBehaviorPattern()
	{
		PatternTimer = 0;
		SecondaryTimer = 0;
	}

	public void DoBehavior(NPC npc, Entity target)
	{
		if (PatternTimer == 0)
		{
			Initialize(npc, target);
		}
		AI(npc, target);
		PatternTimer++;
	}

	public virtual void Initialize(NPC npc, Entity target)
	{
	}

	public virtual void AI(NPC npc, Entity target)
	{
	}

	public virtual void VisualEffects(NPC npc, SpriteBatch spriteBatch)
	{
	}
}
