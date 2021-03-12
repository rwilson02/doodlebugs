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
    private int next = 0, cacheBalance;
    private float checkCountdown = 2;
    public SpawnState state = SpawnState.waiting;
    List<int> spawnList = new List<int>();
    List<GameObject> cacheTowers = new List<GameObject>();
    public bool isWave = false;
    public ChangeScene sean;

    public static WaveSpawner WaveTime;

    private void Start()
    {
        WaveTime = this;
    }

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
        print(isRed);
    }

    void WaveComplete()
    {
        isWave = false;
        Debug.Log("Nice one!");
        state = SpawnState.waiting;
        currenScript.playerCash.balance += (75 + (25 * (next + 1))); 


        if (next + 1 > waves.Length - 1)
        {
            next = 0; // until there's a results screen
            Debug.Log("you win");
            sean.GoTo = "victory";
            sean.Outie();
        }
        else next++;
    }

    IEnumerator DoTheDo(Wave wave)
    {
        cacheBalance = currenScript.playerCash.balance;
        foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
        {
            cacheTowers.Add(tower);
        }

        int reds = wave.redNum;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < wave.count[i]; j++)
            {
                spawnList.Add(i);
            }
        }

        print(spawnList);

        state = SpawnState.spawning;
        isWave = true;


        for(int j = spawnList.Count; j > 0; j--)
        {
            yield return new WaitForSeconds(1 / wave.rate);

            int h = Random.Range(0, j);
            bool red;

            print(reds);
            if(reds < spawnList.Count)
            {
                if (Random.value > 0.7)
                {
                    red = true;
                    reds--;
                }
                else red = false;
            } 
            else
            {
                red = true;
                reds--;
            }

            SpawnEnemy(spawnList[h], red);
            spawnList.RemoveAt(h);
        }

        state = SpawnState.spawned;

        yield break;
    }

    public void RestartWave()
    {
        state = SpawnState.waiting;
        isWave = false;
        currenScript.playerCash.balance = cacheBalance;

        GameObject[] die = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in die)
        {
            Destroy(enemy);
        }

        GameObject[] fly = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in fly)
        {
            Destroy(bullet);
        }

        GameObject[] bye = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < bye.Length; i++)
        {
            if (!cacheTowers.Contains(bye[i]))
            {
                Destroy(bye[i]);
            }
        }
    }
}