using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    int numberofenemies = 3;
    public GameObject enemy;


    private void Start()
    {
        for (int i = 0; i < numberofenemies; i++)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }



}
