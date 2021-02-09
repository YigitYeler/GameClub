using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    //float randY;
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
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            //randY = Random.Range(-4f, 4f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Destroy(Instantiate(enemy, whereToSpawn, Quaternion.identity), 2f);
        }
    }
}
