## User Scenarios

### User Story 1 - Heads or Tails (Priority: P1)
A player stores the Golden Coin in a pocket and gets this power while it stays there: when you are about to take damage a coin is flipped: heads and you take none, tails and you take it and the coin wears.
**Acceptance**: with the valuable pocketed the power works; with it out of the pocket it does not; each use wears the valuable and shows the cooldown on the slot.

## Requirements
- FR-001: Registers a charm with CharmCore for the prefab Valuable Desert Golden Coin.
- FR-002: Settings through CharmCore: Enabled, WearPercent, CooldownSeconds, DebugMode; host-authoritative except DebugMode.
- FR-003: All players install it (Category 2); depends on Pockets and CharmCore.