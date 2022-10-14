using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnOrderScript : MonoBehaviour
{
    public static TurnOrderScript Instance { get; private set; }
    public List<GameObject> turnOrder = new List<GameObject>();
    public bool battleStarted;

    public void Awake()
    {
        //Our "GameController" Dependent Addition
        if (this.tag != "GameController")
        {
            Debug.Log("PartyManager on wrong GameObject!");
            Instance = GameObject.FindGameObjectWithTag("GameController").AddComponent<TurnOrderScript>();
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

    public void GatherUnits(List<GameObject> unitParty)
    {
        if (battleStarted == false)
        {

            //Debuging
            List<GameObject> partyHolder = new List<GameObject>();
            foreach (GameObject unit in unitParty)
            {
                GameObject unitClone = Instantiate(unit, transform.position, transform.rotation); //
                partyHolder.Add(unitClone);
            }
            //

            Debug.Log("Battle Start!");
            battleStarted = true;
            turnOrder.AddRange(partyHolder);
            turnOrder.AddRange(PartyManager.Instance.partyList);

            OrderByDiceRoll();
        }
        
    }

    public void OrderByDiceRoll()
    {
        foreach (var unit in turnOrder)
        {
            unit.GetComponent<UnitCharacter>().characterProfile.RollDice();
        }

        turnOrder = turnOrder.OrderBy(x => x.GetComponent<UnitCharacter>().characterProfile.diceRoll).ToList();
        turnOrder.Reverse();
    }
}
