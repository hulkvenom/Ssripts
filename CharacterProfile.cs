using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterProfile" , menuName = "ScriptableObjects/CharacterProfile")]
public class CharacterProfile : ScriptableObject
{
    public string characterName;
    public Stat health;
    public Stat strength;
    public Stat dexterity;
    public Stat intelligence;
    public int diceRoll;

    public UnitType unitType;
    public List<GameObject> bringIntoBattle;

    public int RollDice()
    {
        diceRoll = Random.Range(1, 20 + 1);
        return diceRoll;
    }
}

public enum UnitType {Player, Ally, Enemy, NPC};
