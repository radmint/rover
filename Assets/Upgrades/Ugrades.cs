using Stats;
using System.Collections.Generic;

public class Upgrades {
    List<Upgrade> HullUpgrades = new List<Upgrade> {
        new Upgrade(new StatModifier(10, StatModType.Flat), UpgradeType.Hull),
        new Upgrade(new StatModifier(20, StatModType.Flat), UpgradeType.Hull),
        new Upgrade(new StatModifier(30, StatModType.Flat), UpgradeType.Hull)
    };
    List<Upgrade> BatteryUpgrades = new List<Upgrade> {
        new Upgrade(new StatModifier(10, StatModType.Flat), UpgradeType.Battery),
        new Upgrade(new StatModifier(20, StatModType.Flat), UpgradeType.Battery),
        new Upgrade(new StatModifier(30, StatModType.Flat), UpgradeType.Battery)
    };
    List<Upgrade> DrillUpgrades = new List<Upgrade> {
        new Upgrade(new StatModifier(10, StatModType.Flat), UpgradeType.Drill),
        new Upgrade(new StatModifier(20, StatModType.Flat), UpgradeType.Drill),
        new Upgrade(new StatModifier(30, StatModType.Flat), UpgradeType.Drill)
    };
    List<Upgrade> MovementUpgrades = new List<Upgrade> {
        new Upgrade(new StatModifier(10, StatModType.Flat), UpgradeType.Movement),
        new Upgrade(new StatModifier(20, StatModType.Flat), UpgradeType.Movement),
        new Upgrade(new StatModifier(30, StatModType.Flat), UpgradeType.Movement)
    };
}
