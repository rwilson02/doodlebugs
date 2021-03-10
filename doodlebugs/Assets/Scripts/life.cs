using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public int hp = 4;
    public ChangeScene sean;

    public static life playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = this;
    }

    public void DMG()
    {
        hp--;

        if(hp == 0)
        {
            sean.GoTo = "defeat";
            sean.Outie();
        }
    }
}
