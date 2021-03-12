using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvScript : MonoBehaviour
{
    public Text balance, menuButton;
    bool show = true, paused = false;
    public RectTransform menu, pause;
    public KeyCode menuKey, pauseKey;
    float t = 0, b = 0;
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

        if (Input.GetKeyDown(pauseKey))
        {
            paused = !paused;

            if (paused)
            {
                slide.pitch = 1;
            }
            else
            {
                slide.pitch = .75f;
            }

            slide.Play();
            //print(show);
        }

        menu.position = new Vector2( 960 + Mathf.Lerp(0,400,t) , menu.position.y);
        pause.position = new Vector2(Mathf.Lerp(-400, 350, b), pause.position.y);
        //print(t);

        if (show)
        {
            t -= 2.5f * Time.deltaTime;
        }
        else t += 2.5f * Time.deltaTime;

        if (paused)
        {
            Time.timeScale = 0;
            b += 2.5f * Time.unscaledDeltaTime;
        }
        else
        {
            Time.timeScale = 1; 
            b -= 2.5f * Time.unscaledDeltaTime;
        }

        t = Mathf.Clamp01(t);
        b = Mathf.Clamp01(b);
    }
}
