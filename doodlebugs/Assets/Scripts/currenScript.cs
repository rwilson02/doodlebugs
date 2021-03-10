using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currenScript : MonoBehaviour
{
    public int balance = 250;

    //returns true on buy [after pay], returns false when cannot buy
    public bool Buy(int cost)
    {
        if (balance >= cost)
        {
            balance -= cost;
            return true;
        }
        else return false;
    }

    //rewards you for murder
    public void Kill(int bounty)
    {
        balance += bounty;
    }

    public static currenScript playerCash;

    void Start()
    {
        playerCash = this;
    }
}
