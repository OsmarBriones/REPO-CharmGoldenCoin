# Charm Golden Coin

Heads or Tails: when you are about to take damage a coin is flipped: heads and you take none, tails and you take it and the coin wears.

> **Everyone in the lobby must install this mod, together with Pockets and CharmCore.** The power changes what your own character can do and its state shows on your inventory slot, so friends without the mods would see an empty slot and be unable to use the pocket.

## How to Use

1. Find the **Golden Coin** valuable and store it in a free inventory slot with [Pockets](https://thunderstore.io/c/repo/p/OsmarBriones/Pockets/) (grab it, press the slot key).
2. From then on, every time something is about to hurt you, a coin is flipped. Heads: the hit does nothing to you and the coin is untouched. Tails: you take the hit as usual and the coin loses some of its value.
3. Take the valuable out of the pocket and the power stops.

## Features

- **Heads or Tails:** each hit you are about to take is a coin flip (50% by default): heads cancels it completely, even a hit that would have killed you; tails lets it land and wears the coin.
- **No pause:** there is no cooldown, every hit is flipped.
- **It costs the valuable:** each use wears away a share of its value, and a worn-out valuable breaks.
- **Everything is configurable:** wear, the chance of heads and the short protection after a heads. The host's choices apply to everyone.

## Requirements
- [BepInEx Pack for R.E.P.O.](https://thunderstore.io/c/repo/p/BepInEx/BepInExPack/)
- [Pockets](https://thunderstore.io/c/repo/p/OsmarBriones/Pockets/)
- [CharmCore](https://thunderstore.io/c/repo/p/OsmarBriones/CharmCore/)

## Installation
1. Install through r2modman / Thunderstore Mod Manager (Pockets and CharmCore come with it), or place `CharmGoldenCoin.dll` next to `Pockets.dll` and `CharmCore.dll` in `BepInEx/plugins`. **All players need it.**
2. Launch the game once; the configuration file is created inside `BepInEx/config`.

## Configuration
Settings are in `com.osmar.CharmGoldenCoin.cfg` inside `BepInEx/config`, section `Charm.GoldenCoin`. The host's choices apply to everyone.

- `Enabled` (default `true`): turn this charm on or off.
- `WearPercent` (default `15`): share of the valuable's original value lost on each tails.
- `HeadsChancePercent` (default `50`, 0 to 100): chance that a flip is heads. 0 never saves you, 100 always does.
- `HeadsInvincibleSeconds` (default `0.5`, 0 to 5): seconds you cannot be hurt after a heads, so a single attack is not flipped again and again. 0 flips every hit.

Section `Debug`: `DebugMode` (default `false`) places a Golden Coin on the floor in front of you when a level starts (host or singleplayer) and writes extra log lines. For testing.

## Good to know
- Instant kills that skip the normal damage (a scripted explosion kill, arena kills) are not covered by the coin.
- A cancelled hit can still push or tumble you.
- If you die or are out of the round, nothing is flipped.

## Issues & Bug Reports
The official way to report issues, suggest improvements, or submit feedback is by opening an issue on the official GitHub repository:
👉 [GitHub Issues](https://github.com/OsmarBriones/REPO-CharmGoldenCoin/issues)

## Credits
Developed by **Osmar Briones**
