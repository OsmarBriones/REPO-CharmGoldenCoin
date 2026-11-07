# Changelog

## [Unreleased]

### Added
- Heads or Tails: when you are about to take damage a coin is flipped: heads and you take none, tails and you take it and the coin wears.
- Settings `HeadsChancePercent` (0 to 100, default 50) and `HeadsInvincibleSeconds` (0 to 5, default 0.5).
- `Debug.DebugMode` (off by default): puts the Golden Coin on the floor at the start of each level and writes detailed logs.

### Changed
- Runtime hygiene pass: guarded the debug logs in the hurt handler; no per-level state, nothing else to change.
