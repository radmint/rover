using Stats;
using UnityEngine;

public class Rover : MonoBehaviour
{
    public Stat HullHealth = new Stat();
    public Stat Battery = new Stat();
    public Stat Power = new Stat();
    public Stat Speed = new Stat();

    public Rover()
    {
        HullHealth.BaseValue = 100;
        Battery.BaseValue = 100;
        Power.BaseValue = 1;
        Speed.BaseValue = 1;
    }
}
