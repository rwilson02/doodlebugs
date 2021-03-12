using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvScript : MonoBehaviour
{
    public Text balance;
    bool show = true;
    public RectTransform menu;
    public KeyCode menuKey;
    float t = 0;


    void Update()
    {
        balance.text = currenScript.playerCash.balance.ToString("0000");

        ToggleMenu();
    }

    public void ToggleMenu()
    {
        if (Input.GetKeyDown(menuKey))
        {
            show = !show;
            //print(show);
        }
     
        menu.position = new Vector2( 960 + Mathf.Lerp(0,400,t) , menu.position.y);
        //print(t);

        if (show)
        {
            t -= Time.deltaTime;
        }
        else t += Time.deltaTime;

        t = Mathf.Clamp01(t);
    }
}
