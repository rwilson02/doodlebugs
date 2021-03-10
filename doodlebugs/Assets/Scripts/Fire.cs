using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject tip, bullet;
    public float rate;
    float timer;
    bool timed;
    public static WaveSpawner wav;
    public bool stat;
    public float range;
    public bool good = false;

    private void Start()
    {
        wav = GameObject.Find("Spawnpoint").GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wav.state != WaveSpawner.SpawnState.waiting)
        {
            timed = true;
        }
        else timed = false;

        while (good && timed)
        {
            timer -= Time.deltaTime;
        }

        if(good && timer <= 0)
        {
            if (!stat)
            {
                Shoot();
                timer = 1/rate;
            } 
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(tip.transform.position, Vector2.right * range);
                Debug.DrawRay(tip.transform.position, tip.transform.right * range, Color.red);

                if (hit.collider != null)
                {
                    var hitObj = hit.collider;

                    if (hitObj.isTrigger && hitObj.CompareTag("Enemy"))
                    {
                        Shoot();
                        timer = 1/rate;
                    }
                }
            }
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(bullet, tip.transform.position, tip.transform.rotation);
    }
}
