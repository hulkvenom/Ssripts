using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public static TurnOrderScript Instance { get; private set; }
    public void TestEndTurn(int turnOrder)
    {
        int TurnOrderScript;
        int v = TurnOrderScript = 0;
        if (v == 0)
        {
            Debug.Log("Successful!");
            turnOrder++;
        }
        else if (TurnOrderScript == 1)
        {
            Debug.Log("Not Found!");
            turnOrder = 0;
        }
    }
}
