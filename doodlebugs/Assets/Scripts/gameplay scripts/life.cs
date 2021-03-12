using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
{
    public int hp = 4;
    public ChangeScene sean;

    public static life playerHP;
    public Image[] doodles;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = this;
        doodles = GetComponentsInChildren<Image>();

        foreach(Image image in doodles)
        {
            image.enabled = false;
        }
    }

    public void DMG()
    {
        hp--;

        if (!doodles[hp].enabled)
        {
            doodles[hp].enabled = true;
        }

        if(hp == 0)
        {
            sean.GoTo = "defeat";
            sean.Outie();
        }
    }
}
