using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public TowerPlacement place;
    public AudioSource buy;

    public void Buychase1()
    {
        if (currenScript.playerCash.Buy(100))
        {
            place.PlaceTower(0);
            buy.Play();
        }
    }

    public void Buychase2()
    {
        if (currenScript.playerCash.Buy(200))
        {
            place.PlaceTower(1);
            buy.Play();
        }
    }
}
