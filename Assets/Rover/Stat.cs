using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stats { 
    public class Stat {
        public float BaseValue;
        public float Value
        {
            get
            {
                if (isDirty || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }
        protected readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;
        protected bool isDirty = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;

        public Stat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public Stat(float baseValue) : this() {
            BaseValue = baseValue;
        }

        public void AddModifier(StatModifier modifier)
        {
            isDirty = true;
            statModifiers.Add(modifier);
            statModifiers.Sort(CompareModifierOrder);
        }

        public bool RemoveModifier(StatModifier modifier)
        {
            if(statModifiers.Remove(modifier))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for(var i = statModifiers.Count-1; i >= 0; i++)
            {
                if(statModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if(a.Order < b.Order)
            {
                return -1;
            } if (a.Order > b.Order)
            {
                return 1;
            }
            return 0;
        }

        protected float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for(var i = 0; i < statModifiers.Count;i++)
            {
                StatModifier mod = statModifiers[i];
                if(mod.StatModType == StatModType.Flat) { 
                    finalValue += mod.Value;
                }
                else if (mod.StatModType == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;
                    if(i + 1 > statModifiers.Count || statModifiers[i + 1].StatModType != StatModType.PercentAdd)
                    {
                        finalValue *= 1 * sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.StatModType == StatModType.PercentMult)
                {
                    finalValue *= 1 * mod.Value;
                }
            }

            return (float)Math.Round(finalValue,4);
        }
        //   private float hullHealth;
        //   private float roverPower;

        //// Use this for initialization
        //void Start ()
        //   {
        //       hullHealth = 100;
        //       roverPower = 100;
        //}

        //// Update is called once per frame
        //void Update () {
        //}

        //public void UpdateHealth(float newValue)
        //{
        //    if(newValue > 0 && hullHealth < 100)
        //    {
        //        hullHealth += newValue;
        //        if(hullHealth > 100)
        //        {
        //            hullHealth = 100;
        //        }
        //    } 
        //    else if (newValue < 0 && hullHealth > 0)
        //    {
        //        hullHealth -= newValue;
        //        if(hullHealth < 0)
        //        {
        //            hullHealth = 0;
        //        }
        //    }
        //}

        //public void UpdatePower(float newValue)
        //{
        //    if (newValue > 0 && roverPower < 100)
        //    {
        //        roverPower += newValue;
        //        if (roverPower > 100)
        //        {
        //            roverPower = 100;
        //        }
        //    }
        //    else if (newValue < 0 && roverPower > 0)
        //    {
        //        roverPower -= newValue;
        //        if (roverPower < 0)
        //        {
        //            roverPower = 0;
        //        }
        //    }
        //}
    }
}
