using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class How2Play : MonoBehaviour
{
    public GameObject H2P;
    bool seen = false; 
    public AudioSource slide;
    float t;

    public void click()
    {
        if (seen)
        {
            seen = !seen;
        }
        else seen = true;

        H2P.SetActive(seen);
    }
}
