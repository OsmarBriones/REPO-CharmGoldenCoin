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
			HeadsChancePercent = AddSetting("HeadsChancePercent", 50f, 0f, 100f, "Chance in percent that the coin lands heads and a hit is cancelled completely. 0 never saves you, 100 always does.");
			HeadsInvincibleSeconds = AddSetting("HeadsInvincibleSeconds", 0.5f, 0f, 5f, "Seconds of protection after a heads, so one attack is not flipped again and again. 0 flips every hit.");
		}

		/// <summary>Chance, in percent, that a flip is heads (the hit is cancelled and the coin does not wear).</summary>
		internal CharmSetting HeadsChancePercent { get; }

		/// <summary>Seconds the player cannot be hurt after a heads.</summary>
		internal CharmSetting HeadsInvincibleSeconds { get; }
	}
}
