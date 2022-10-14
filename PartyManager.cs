using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class PartyManager : MonoBehaviour
{
    public static PartyManager Instance { get; private set; }
    public List<GameObject> partyList = new List<GameObject> ();

    private void Awake()
    {
        //Our "GameController" Dependent Addition
        if (this.tag != "GameController")
        {
            Debug.Log("PartyManager on wrong GameObject!");
            Instance = GameObject.FindGameObjectWithTag("GameController").AddComponent<PartyManager>();
            Debug.Log("PartyManager moved to GameController");
            Destroy(this);
        }
        //

        //Normal Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //
    }

    private void Start()
    {
        InitializeParty();
    }

    public void InitializeParty()
    {
        if (partyList.Count >= 0)
        {
            Debug.Log("Initialize Party");

            
            UnitCharacter[] listHolder;
            listHolder = UnitCharacter.FindObjectsOfType<UnitCharacter>();
            foreach (UnitCharacter unit in listHolder)
            {
                if (unit.characterProfile.unitType == UnitType.Player)
                {
                    partyList.Add(unit.gameObject);
                }
            }
        }
    }
    public void GatherParty(UnitCharacter partyMember)
    {
        //To utilize this we will have o make a saved later that we can grab from.
    }

    public void AddPartyMember(GameObject partyMember)
    {
        if (partyMember != null)
            partyList.Add(partyMember);
    }

    public void RemovePartyMember(GameObject partyMember)
    {
        if (partyMember != null)
            partyList.Remove(partyMember);
    }
}


