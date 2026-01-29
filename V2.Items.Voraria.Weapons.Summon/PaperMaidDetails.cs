namespace V2.Items.Voraria.Weapons.Summon;

public static class PaperMaidDetails
{
	public static string Name => "Macheline";

	public static double NeededMinionSlots => 2.0;

	public static double PaperPlateDamage => 1.0;

	public static double SilverwarePerDamage => 0.8;

	public static double ForkArmorPen => 15.0;

	public static double SpoonInorganicDamageBonus => 0.2;

	public static int KnifeBleedProcDuration => V2Utils.SensibleTime(0, 0, 3);

	public static double StomachCapacity => 2.0;

	public static double StomachacheMeterCapacity => 250.0;

	public static double DigestionDamage => 0.7;

	public static double DigestionRate => 1.6;

	public static double DigestionBleedRatio => 0.5;

	public static double Health => 500.0;
}
