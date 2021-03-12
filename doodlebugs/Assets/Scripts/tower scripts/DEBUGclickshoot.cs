using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGclickshoot : MonoBehaviour
{
    public GameObject tip, bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(bullet, tip.transform.position, tip.transform.rotation);
    }
}
