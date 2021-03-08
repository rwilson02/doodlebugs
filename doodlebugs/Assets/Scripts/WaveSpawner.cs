using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { waiting, spawning, spawned };

    [System.Serializable]
    public class Wave
    {
        public int[] count;
        public Transform[] enemy;
        public float rate;
    }

    public Wave[] waves;
    private int next = 0;
    private float checkCountdown = 2;
    private SpawnState state = SpawnState.waiting;

    private void Update()
    {
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

    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("Spawning enemy:" + enemy.name);
        Instantiate(enemy, transform.position, transform.rotation);
    }

    void WaveComplete()
    {
        Debug.Log("Nice one!");
        state = SpawnState.waiting;

        if (next + 1 > waves.Length - 1)
        {
            next = 0; // until there's a results screen
            Debug.Log("you win");
        }
        else next++;
    }

    IEnumerator DoTheDo(Wave wave)
    {
        state = SpawnState.spawning;

        

        state = SpawnState.spawned;

        yield break;
    }
}