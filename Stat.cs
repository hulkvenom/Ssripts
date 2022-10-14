using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[System.Serializable]

public class Stat
{
    [SerializeField]
    private int baseValue;

    public List<int> modifiers = new List<int>();

    public int GetBaseValue()
    {
        return baseValue;

        
    }

    public int GetValue()
    {
        int totalValue = baseValue;
        modifiers.ForEach(x => totalValue += x);
        return totalValue;
    }

    public void AddModifiers(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }

}
