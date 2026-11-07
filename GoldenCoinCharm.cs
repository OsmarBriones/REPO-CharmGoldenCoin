using CharmCore.Api;

namespace CharmGoldenCoin
{
	/// <summary>Heads or Tails: when you are about to take damage a coin is flipped: heads and you take none, tails and you take it and the coin wears.</summary>
	internal sealed class GoldenCoinCharm : Charm
	{
		internal const string PrefabName = "Valuable Desert Golden Coin";

		internal GoldenCoinCharm()
			: base("GoldenCoin", "Golden Coin - Heads or Tails", defaultWearPercent: 15f, defaultCooldownSeconds: null, PrefabName)
		{
			// Extra host-synced numbers for this power go here, for example:
			// Amount = AddSetting("Amount", 30f, 1f, 100f, "Description for the config file.");
		}
	}
}
