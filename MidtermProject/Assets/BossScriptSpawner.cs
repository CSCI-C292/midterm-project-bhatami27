using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScriptSpawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScript.scoreValue > 1){
            if(Time.time> nextSpawn)
            {
                nextSpawn = Time.time+spawnRate;
                randX = 60f;
                randY = -17f;
                whereToSpawn = new Vector2(randX, randY);
                Instantiate(enemy,whereToSpawn, Quaternion.identity);
            }
        }
    }
}