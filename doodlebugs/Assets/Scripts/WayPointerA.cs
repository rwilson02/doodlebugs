using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointerA : MonoBehaviour
{
    public static Transform[] waypts;

    private void Awake()
    {
        waypts = new Transform[transform.childCount];

        for (int i = 0; i < waypts.Length; i++)
        {
            waypts[i] = transform.GetChild(i);
        }
    }
}
