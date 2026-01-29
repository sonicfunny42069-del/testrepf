namespace V2.Projectiles.Voraria.Pets;

public static class AstralFairyStuff
{
	public static int MaxHealth => 785000;

	public static double Size => 29.0;

	public static double MaxStomachCapacity => 42000.0;

	public static double Stomachache => 250000.0;

	public static double DigestDamage => 70.0;

	public static double DigestRate => 2.0;

	public static double AbsorbRate => 1.0 / (double)V2Utils.SensibleTime(0, 0, 10);
}
