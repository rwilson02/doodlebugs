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
        public float rate;
        public int redNum;
    }

    public GameObject[] enemy;

    public Wave[] waves;
    private int next = 0;
    private float checkCountdown = 2;
    public SpawnState state = SpawnState.waiting;
    List<int> spawnList = new List<int>();

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
            StartCoroutine( DoTheDo(waves[next]) );
        }
    }

    void SpawnEnemy(int k, bool isRed)
    {
        Debug.Log("Spawning enemy!");
        var f = Instantiate(enemy[k], transform.position, transform.rotation);
        f.GetComponent<EnemyScript>().red = isRed;
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

    IEnumerator DoTheDo(Wave wave)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < wave.count[i]; j++)
            {
                spawnList.Add(i);
            }
        }

        print(spawnList);

        state = SpawnState.spawning;


        for(int j = spawnList.Count; j > 0; j--)
        {
            yield return new WaitForSeconds(1 / wave.rate);

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
        }

        state = SpawnState.spawned;

        yield break;
    }
}