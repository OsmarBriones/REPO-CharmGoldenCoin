using System;

namespace CharmGoldenCoin.Domain
{
	/// <summary>The coin flip of Heads or Tails, free of game and Unity types so it can be unit tested.</summary>
	internal static class CoinFlip
	{
		/// <summary>
		/// Decides a flip. <paramref name="rollPercent"/> is a random number in [0, 100); the flip is heads when it is
		/// strictly below the chance. So a chance of 0 is never heads and a chance of 100 is always heads.
		/// </summary>
		internal static bool IsHeads(float headsChancePercent, double rollPercent)
		{
			return rollPercent < headsChancePercent;
		}

		/// <summary>Flips the coin with a random source. <see cref="Random.NextDouble"/> is in [0, 1), which keeps both limits exact.</summary>
		internal static bool Flip(float headsChancePercent, Random random)
		{
			return IsHeads(headsChancePercent, random.NextDouble() * 100d);
		}
	}
}
