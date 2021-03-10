using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvScript : MonoBehaviour
{
    public Text balance;

    void Update()
    {
        balance.text = currenScript.playerCash.balance.ToString("0000");
    }
}
