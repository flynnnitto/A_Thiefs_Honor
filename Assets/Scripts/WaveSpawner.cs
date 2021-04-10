using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {Spawning,Waiting,Counting};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;


    public float timebtwWaves = 5f;
    public float waveCountdown;

    private float searchCountDown = 1f;
    private SpawnState state = SpawnState.Counting;
    private void Start()
    {
        waveCountdown = timebtwWaves;
        


    }
    private void Update()
    {
        if(state == SpawnState.Waiting)
        {
            if(!EnemyisAlive())
            {
                Debug.Log("WaveCompleted");
                return;
            }
            else
            {
                return;
            }

        }



        if(waveCountdown<=0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave( waves[nextWave] ));
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }


        }

    }

    bool EnemyisAlive()
    {
        searchCountDown -= Time.deltaTime;
        if(searchCountDown<=0 )
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;


            }

            
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave "+ _wave.name);
        state = SpawnState.Spawning;

        for (int i=0; i<_wave.count; i++)
        {

            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);

        }
        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawing enemy" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
       
    }

}
