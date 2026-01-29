using Terraria.ModLoader;

namespace V2.Compat;

public abstract class V2CompatModule
{
	public Mod compatMod;

	public V2CompatModule(Mod mod)
	{
		((Mod)V2.Instance).Logger.Info((object)$"Loading compat: {mod.Name} - {mod.Version}");
		compatMod = mod;
	}

	public abstract void ApplyCompatibility();

	public abstract void UnapplyCompatibility();
}
