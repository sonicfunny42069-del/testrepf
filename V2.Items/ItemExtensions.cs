using Terraria;

namespace V2.Items;

public static class ItemExtensions
{
	public static GeneralItem AsAnItem(this Item item)
	{
		if (item.IsAir)
		{
			return null;
		}
		GeneralItem result = default(GeneralItem);
		if (item.TryGetGlobalItem<GeneralItem>(ref result))
		{
			return result;
		}
		return null;
	}

	public static GeneralTaggableItem AsTaggable(this Item item)
	{
		if (item.IsAir)
		{
			return null;
		}
		GeneralTaggableItem result = default(GeneralTaggableItem);
		if (item.TryGetGlobalItem<GeneralTaggableItem>(ref result))
		{
			return result;
		}
		return null;
	}
}
