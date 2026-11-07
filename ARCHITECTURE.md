# CharmGoldenCoin Architecture

A Charm mod (layer 3 of the PocketCharms family): one valuable, one power. It depends on **Pockets** (storage) and **CharmCore** (registry, wear, cooldown display, host settings, debug mode).

## The power: Heads or Tails

when you are about to take damage a coin is flipped: heads and you take none, tails and you take it and the coin wears.

- `GoldenCoinCharm : Charm` registers the prefab name `Valuable Desert Golden Coin`, the defaults (wear 15%, no cooldown) and two host-synced settings.
- `HeadsOrTails` (static class, no MonoBehaviour) registers one handler with `CharmsApi.OnPlayerHurting` at priority 0 (the "cancelling effects" slot, so the flip happens before any damage reduction). The plugin calls `HeadsOrTails.Register(charm)` once in `Awake`, right after `CharmsApi.Register`.
- `Domain/CoinFlip.cs` is the game-free flip: heads when a roll in [0, 100) is strictly below the chance. The roll is `System.Random.NextDouble() * 100`, which is in [0, 1) so chance 0 is never heads and chance 100 is always heads (`UnityEngine.Random.Range(float, float)` is inclusive at the top and would break that).
- No Harmony patch in this mod. CharmCore patches `PlayerHealth.Hurt` once and only creates the context for hits the game would really apply (not invincible, not dead, not in the menu, game in the main state), so no flip or wear is wasted.

Flow per hit, on the damaged player's machine, only while `Charm.IsActive`:
1. Heads: `context.Cancel = true` (also cancels lethal hits), `context.InvincibleSecondsAfter = HeadsInvincibleSeconds`, no wear.
2. Tails: the hit is untouched and `Charm.Wear(Charm.WearPercent)` is requested. `TryUse` is not used because the charm has no cooldown.

## Settings

| Key | Type | Range | Default | Meaning |
| --- | --- | --- | --- | --- |
| `HeadsChancePercent` | float, percent | 0 to 100 | 50 | Chance of heads. 0 and 100 are meaningful (never / always). |
| `HeadsInvincibleSeconds` | float, seconds | 0 to 5 | 0.5 | Protection after a heads. 0 is meaningful (flip every hit). Negative makes no sense; above 5 s would make the coin close to god mode. |
| `WearPercent` (CharmCore) | float, percent | CharmCore range | 15 | Wear on each tails. |

## Game members used

- `PlayerHealth.Hurt(int, bool, int, bool)`: patched by CharmCore, not by this mod; checked in `GameContractTests`.
- `ValuableObject.dollarValueCurrent`: read by CharmCore's wear; checked in `GameContractTests`.

They are checked by `CharmGoldenCoin.Tests/GameContractTests.cs`.

## Debug mode

Provided by CharmCore: the `Debug.DebugMode` setting (off by default) places the valuable on the floor at the start of each level and enables `Charm.LogDebug` output.

## Decisions

- Added `HeadsInvincibleSeconds` (default 0.5 s). A cancelled hit does not trigger the game's own post-hit invincibility, so without it one multi-tick attack could be flipped many times and wear the coin on every tails. Setting it to 0 gives the pure behaviour. CharmCore applies it in a postfix, which Harmony also runs when the prefix skips `Hurt`.
- The flip uses `System.Random` (one instance per process) rather than `UnityEngine.Random`, to keep the logic testable and the limits exact.
- No cooldown: `defaultCooldownSeconds` is null, as designed.

## Known limits

- Instant kills that bypass `PlayerHealth.Hurt` (scripted explosion kill, arena kills) are not covered.
- A cancelled hit may still push or tumble the player (the knockback does not go through `Hurt`).
- Verified only by build and unit tests; not exercised in game.

- Looked up by exact prefab name; a game update that renames the prefab needs a mod update.
