# QA battery: Heads or Tails (CharmGoldenCoin)

Deploy: Pockets, CharmCore and CharmGoldenCoin are in the r2modman `Debug` profile (compare hashes with the builds). Restart the game first.

## Quick start with debug mode
Set `DebugMode = true` in the `Debug` section of `BepInEx/config/com.osmar.CharmGoldenCoin.cfg` (off by default). When a level starts, a Golden Coin is placed on the floor about 2.5 m in front of you; the log then also shows the detailed lines. Any level works.

## Single player
- [ ] Log shows `Charm registered: Golden Coin - Heads or Tails` and `CharmGoldenCoin 1.0.0 loaded!`.
- [ ] Store the valuable in a slot: the slot shows its picture and value.
- [ ] Get hit by a monster or fall from a height with the coin pocketed (set `HeadsChancePercent = 100`): you take no damage, the coin does not wear, no cooldown veil appears; the log shows `Heads`.
- [ ] Set `HeadsChancePercent = 0`: every hit lands normally and the coin loses 15% of its value each time (check the slot value); the log shows `Tails`.
- [ ] Default 50%: over about 20 hits roughly half are cancelled; wear only happens on the others.
- [ ] A hit that would be lethal can be cancelled by heads and kills you on tails.
- [ ] After a heads you are protected for about `HeadsInvincibleSeconds`; with `0` every tick of a multi-hit attack is flipped.
- [ ] Known limit: a cancelled hit may still push or tumble you; instant kills (scripted explosion kill, arena) are not saved.
- [ ] Take the valuable out: the power stops.
- [ ] Use it until the valuable breaks: the slot empties, the power stops, no errors in the log.

## Settings
- [ ] There is no cooldown setting or veil. `WearPercent = 0`: tails does not wear. `HeadsChancePercent` and `HeadsInvincibleSeconds` are clamped to 0..100 and 0..5.
- [ ] Charm `Enabled = false`: no effect and no wear. CharmCore `Enabled = false`: nothing works.

## Multiplayer (host and client)
- [ ] The flip works on the client when the client is hit, the value drops on both machines on tails.
- [ ] Host settings override the client's.
- [ ] Client leaves and rejoins: no stuck veil.

Log patterns: `Charm registered`, `threw`, `Exception`.
