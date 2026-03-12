using System.Timers;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float spawnInterval = 2f;
   

    public float minY = -1f;
    public float maxY = 3f;
    
    private float timer = 0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        
        
        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        //spawns object at random between certain cords
        float randomY = Random.Range(minY, maxY); 
        Vector2 spawnPosition = new Vector2(15f, randomY);  
        Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}
