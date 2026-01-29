using Terraria;
using Terraria.ModLoader;

namespace V2.Core;

public abstract class ArmorSetDefinition : ModType
{
	public abstract (int? head, int? body, int? legs) RequiredEquipment { get; }

	public abstract string SetBonusDescriptionKey { get; }

	public abstract object SetBonusDescriptionVariables { get; }

	public abstract void ApplySetBonus(Player player);

	public bool Active(Player player)
	{
		int? head = RequiredEquipment.head;
		int? body = RequiredEquipment.body;
		int? legs = RequiredEquipment.legs;
		if (head.HasValue && player.armor[0].type != head.Value)
		{
			return false;
		}
		if (body.HasValue && player.armor[1].type != body.Value)
		{
			return false;
		}
		if (legs.HasValue && player.armor[2].type != legs.Value)
		{
			return false;
		}
		return true;
	}

	protected sealed override void Register()
	{
		ModTypeLookup<ArmorSetDefinition>.Register(this);
		ArmorSetHandler.RegisterArmorSet(this);
	}
}
