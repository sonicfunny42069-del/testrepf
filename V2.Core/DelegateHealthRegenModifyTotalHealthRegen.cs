using Terraria;

namespace V2.Core;

public delegate void DelegateHealthRegenModifyTotalHealthRegen(Player player, ref double naturalRegenAdditive, ref double naturalRegenMultiplicative, ref double artificialRegenAdditive, ref double artificialRegenMultiplicative);
