using Terraria.ModLoader;

namespace V2.Items;

public class GeneralTaggableItem : GlobalItem
{
	public override bool InstancePerEntity => true;

	public bool Sword
	{
		get
		{
			if (!Broadsword)
			{
				return Shortsword;
			}
			return true;
		}
	}

	public bool Broadsword { get; set; }

	public bool Shortsword { get; set; }

	public bool Bow { get; set; }

	public bool Gun { get; set; }

	public bool NormalFood { get; set; }

	public bool NormalDrink { get; set; }

	public GeneralTaggableItem()
	{
		Broadsword = false;
		Shortsword = false;
		Bow = false;
		Gun = false;
		NormalFood = false;
		NormalDrink = false;
	}
}
