using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { waiting, spawning, spawned };

    [System.Serializable]
    public class Wave
    {
        public int[] count;
        public GameObject[] enemy;
        public float rate;
        public int redNum;
    }

    public Wave[] waves;
    private int next = 0;
    private float checkCountdown = 2;
    private SpawnState state = SpawnState.waiting;
    public List<GameObject> spawnList;
    private float timer;

    private void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            SpawnWave();
        }

        if (state == SpawnState.spawned)
        {
            if (Deadality())
            {
                WaveComplete();
            }
        }

        timer -= Time.deltaTime;
        print(timer);
    }

    bool Deadality()
    {
        checkCountdown -= Time.deltaTime;
        if (checkCountdown <= 0)
        {
            checkCountdown = 2;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return true;
            }
        }
        
        return false;
    }

    public void SpawnWave()
    {
        if (state == SpawnState.waiting)
        {
            Debug.Log("Booding it up");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < waves[next].count[i]; j++)
                {
                    GameObject f = Instantiate(waves[next].enemy[i], 
                        transform.position, transform.rotation);
                    print(f);
                    spawnList.Add(f);
                }
            }

            StartWave(waves[next]);
        }
    }

    private void StartWave(Wave wave)
    {
        int j = spawnList.Count;

        do
        {
            if (timer <= 0) 
            {
                int h = Random.Range(0, j);
                bool red = false;

                if (wave.redNum < h)
                {
                    if (Random.value > 0.7)
                    {
                        red = true;
                    }
                }
                else red = true;

                SpawnEnemy(spawnList[h], red);
                spawnList.RemoveAt(h);
                j--;
                timer = 1 / wave.rate;
            }
        } while (j > 0);
    }

    void SpawnEnemy(GameObject enemy, bool isRed)
    {
        Debug.Log("Spawning enemy:" + enemy.name);
        enemy.GetComponent<EnemyScript>().red = isRed;
    }

    void WaveComplete()
    {
        Debug.Log("Nice one!");
        state = SpawnState.waiting;
        currenScript.playerCash.balance += (75 + (25 * (next + 1))); 


        if (next + 1 > waves.Length - 1)
        {
            next = 0; // until there's a results screen
            Debug.Log("you win");
        }
        else next++;
    }
}