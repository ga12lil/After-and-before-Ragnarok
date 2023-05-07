using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cycle cycle;
    public GameObject enemyPrefab;
    public bool switchTime = true;
    
    void Update()
    {
        if(cycle.time > cycle.dayLong  && switchTime)
        {
            var pos = new Vector3(transform.position.x + Random.Range(2, 5), transform.position.y + Random.Range(2, 5), transform.position.z);
            Instantiate(enemyPrefab, pos, new Quaternion());
            //pos = new Vector3(transform.position.x + Random.Range(2, 5), transform.position.y + Random.Range(2, 5), transform.position.z);
            //Instantiate(enemyPrefab, pos, new Quaternion());
            switchTime = false;
        }
    }
}
