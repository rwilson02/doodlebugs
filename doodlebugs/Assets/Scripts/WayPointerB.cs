using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointerB : MonoBehaviour
{
    const int SIZE = 4;
    public static Transform[] pointsA = new Transform[4];
    public static Transform[] pointsB = new Transform[4];
    public static Transform end;

    private void Awake()
    {
        for(int i = 0; i < SIZE; i++)
        {
            pointsA[i] = this.transform.GetChild(0).GetChild(i);
        }
        for (int i = 0; i < SIZE; i++)
        {
            pointsB[i] = this.transform.GetChild(1).GetChild(i);
        }

        end = transform.Find("end");
    }
}
