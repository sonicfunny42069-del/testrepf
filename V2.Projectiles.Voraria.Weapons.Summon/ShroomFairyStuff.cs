namespace V2.Projectiles.Voraria.Weapons.Summon;

public static class ShroomFairyStuff
{
	public static int MaxHealth => 500;

	public static double Size => 0.88;

	public static double MaxStomachCapacity => 666.0;

	public static double Stomachache => 475.0;

	public static double DigestDamage => 11.0;

	public static double DigestRate => 1.0;

	public static double AbsorbRate => 1.0 / (double)V2Utils.SensibleTime(0, 1, 30);
}
