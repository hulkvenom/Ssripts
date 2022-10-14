using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitCharacter : MonoBehaviour
{
  public CharacterProfile characterProfile;

    //Debug

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.characterProfile.unitType == UnitType.Enemy && characterProfile.bringIntoBattle != null)
        {
            TurnOrderScript.Instance.GatherUnits(characterProfile.bringIntoBattle);
        }
    }
}
