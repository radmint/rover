public static class UpgradeHelper {
    public static void Equip(this Upgrade upgrade, Rover rover)
    {
        if(upgrade.UpgradeType == UpgradeType.Battery)
        {
            rover.Battery.AddModifier(upgrade.Modifier);
        }
        else if (upgrade.UpgradeType == UpgradeType.Hull)
        {
            rover.HullHealth.AddModifier(upgrade.Modifier);
        } 
        else if (upgrade.UpgradeType == UpgradeType.Drill) 
        {
            rover.Power.AddModifier(upgrade.Modifier);
        }
        else if (upgrade.UpgradeType == UpgradeType.Movement) 
        {
            rover.Speed.AddModifier(upgrade.Modifier);
        }
    }
}
