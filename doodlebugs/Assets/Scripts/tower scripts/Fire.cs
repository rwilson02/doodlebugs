using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject tip, bullet;
    public float rate;
    float timer;
    bool timed;
    public bool stat;
    public float range;
    public bool good = false;
    public bool wave = false;

    // Update is called once per frame
    void Update()
    {
        wave = WaveSpawner.WaveTime.isWave;

        if (wave)
        {
            timed = true;
        }
        else timed = false;

        timer -= Time.deltaTime;
        print(timer);
        if (timer <= 0)
        {
            if (good && timed)
            {
                print("shoot");
                Shoot();
                timer = 1 / rate;
            }
        }

    }

    void Shoot()
    {
        GameObject clone = Instantiate(bullet, tip.transform.position, tip.transform.rotation);
        clone.GetComponent<bulletScript>().life = range;
        print("shot");
    }
}
