using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUTING};

    [System.Serializable]
    public  class Wave
    {
        public string name;
        public Transform enemy;
        public Transform enemy2;
        public int count;
        public float rate;
    }

    public GameObject textShop;

    public EnemyDamage ed;

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUTING;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
        textShop.SetActive(false);


    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //Check if enemies are still alive
            if(!EnemyIsAlive())
            {
                //begin a new round
                WaveCompleted();
                
            }
            else
            {
                return;
            }
        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                //start spawn
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUTING;
        textShop.SetActive(true);
        waveCountDown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }

        else
        {
            
            nextWave++;
            ed.enemyHP += 0.25f;

        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Wave completed: " + _wave.name);
        state = SpawnState.SPAWNING;
        

        //Spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            SpawnEnemy(_wave.enemy2);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        textShop.SetActive(false);
        Debug.Log("Spawning enemy: " + _enemy.name);
        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length) ];
        Instantiate(_enemy, _sp.position, transform.rotation);
    }
}
