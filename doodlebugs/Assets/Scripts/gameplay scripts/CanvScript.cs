using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvScript : MonoBehaviour
{
    public Text balance, menuButton;
    bool show = true;
    public RectTransform menu;
    public KeyCode menuKey;
    float t = 0;
    public AudioSource slide;


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

            if (!show)
            {
                slide.pitch = .75f;
                menuButton.text = "Show Menu";
            }
            else { 
                slide.pitch = 1;
                menuButton.text = "Hide Menu";
            }

            slide.Play();
            //print(show);
        }
     
        menu.position = new Vector2( 960 + Mathf.Lerp(0,400,t) , menu.position.y);
        //print(t);

        if (show)
        {
            t -= 2.5f * Time.deltaTime;
        }
        else t += 2.5f * Time.deltaTime;

        t = Mathf.Clamp01(t);
    }
}
