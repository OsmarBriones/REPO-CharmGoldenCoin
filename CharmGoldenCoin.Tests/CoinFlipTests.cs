using System;
using CharmGoldenCoin.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharmGoldenCoin.Tests;

[TestClass]
public class CoinFlipTests
{
	[TestMethod]
	public void ChanceZero_IsNeverHeads()
	{
		Assert.IsFalse(CoinFlip.IsHeads(0f, 0d));
		Assert.IsFalse(CoinFlip.IsHeads(0f, 50d));
		Assert.IsFalse(CoinFlip.IsHeads(0f, 99.999999d));

		Random random = new Random(1);
		for (int i = 0; i < 10000; i++)
		{
			Assert.IsFalse(CoinFlip.Flip(0f, random));
		}
	}

	[TestMethod]
	public void ChanceHundred_IsAlwaysHeads()
	{
		Assert.IsTrue(CoinFlip.IsHeads(100f, 0d));
		Assert.IsTrue(CoinFlip.IsHeads(100f, 50d));
		Assert.IsTrue(CoinFlip.IsHeads(100f, 99.999999d));

		Random random = new Random(2);
		for (int i = 0; i < 10000; i++)
		{
			Assert.IsTrue(CoinFlip.Flip(100f, random));
		}
	}

	[TestMethod]
	public void Boundary_RollEqualToChanceIsTails()
	{
		Assert.IsTrue(CoinFlip.IsHeads(50f, 49.999d));
		Assert.IsFalse(CoinFlip.IsHeads(50f, 50d));
		Assert.IsFalse(CoinFlip.IsHeads(50f, 50.001d));
	}

	[TestMethod]
	public void FiftyPercent_IsRoughlyHalfHeads()
	{
		Random random = new Random(3);
		int heads = 0;
		const int Flips = 20000;
		for (int i = 0; i < Flips; i++)
		{
			if (CoinFlip.Flip(50f, random))
			{
				heads++;
			}
		}

		Assert.IsTrue(heads > Flips * 0.47 && heads < Flips * 0.53, $"Heads came up {heads} times out of {Flips}.");
	}
}
