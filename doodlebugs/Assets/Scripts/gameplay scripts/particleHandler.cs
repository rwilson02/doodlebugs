﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleHandler : MonoBehaviour
{
    float timer = 0.5f;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
