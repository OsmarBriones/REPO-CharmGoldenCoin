using System;
using CharmCore.Api;
using CharmGoldenCoin.Domain;

namespace CharmGoldenCoin
{
	/// <summary>
	/// Heads or Tails: every hit that is about to damage the local player flips the coin. Heads cancels the hit and the coin
	/// does not wear; tails lets the hit land and wears the coin. CharmCore owns the single patch on <c>PlayerHealth.Hurt</c>
	/// and only offers hits the game would really apply, so no flip or wear is wasted.
	/// </summary>
	internal static class HeadsOrTails
	{
		/// <summary>Priority 0 is the "cancelling effects" slot: the flip happens before any damage reduction.</summary>
		private const int HurtPriority = 0;

		private static readonly Random Rng = new Random();

		private static GoldenCoinCharm? charm;

		/// <summary>Registers the hurt handler. Call it once, after <c>CharmsApi.Register</c>.</summary>
		internal static void Register(GoldenCoinCharm coinCharm)
		{
			charm = coinCharm;
			CharmsApi.OnPlayerHurting(OnPlayerHurting, HurtPriority);
		}

		private static void OnPlayerHurting(PlayerHurtContext context)
		{
			GoldenCoinCharm? coin = charm;
			if (coin == null || !coin.IsActive)
			{
				return;
			}

			float chance = coin.HeadsChancePercent.Value;
			if (CoinFlip.Flip(chance, Rng))
			{
				context.Cancel = true;
				context.InvincibleSecondsAfter = coin.HeadsInvincibleSeconds.Value;
				coin.LogDebug($"Heads ({chance:0.#}%): hit of {context.Damage} cancelled, health stays {context.Health}/{context.MaxHealth}, coin does not wear");
			}
			else
			{
				coin.Wear(coin.WearPercent);
				coin.LogDebug($"Tails ({100f - chance:0.#}%): hit of {context.Damage} lands, coin wears {coin.WearPercent:0.#}%");
			}
		}
	}
}
