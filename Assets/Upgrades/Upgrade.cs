using System.Collections.Generic;
using Stats;

public enum UpgradeType
{
    Hull,
    Battery,
    Drill,
    Movement
}

public class Upgrade {
    public bool IsApplied;
    public StatModifier Modifier;
    public UpgradeType UpgradeType;

    public Upgrade(StatModifier modifier)
    {
        Modifier = modifier;
    }

    public Upgrade(StatModifier modifier, UpgradeType upgradeType) : this(modifier)
    {
        UpgradeType = upgradeType;
    }
}
