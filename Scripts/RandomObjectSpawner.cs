using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{

    public List<GameObject> objectOptions;
    public Terrain terrain;
    public int numberOfObjects = 20;
    public float objHeight;


    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++) {
            float randomX = Random.Range(0, terrain.terrainData.size.x / 2)  + terrain.terrainData.size.x /4;
            float randomZ = Random.Range(0, terrain.terrainData.size.z / 2)  + terrain.terrainData.size.z /4;

            float height = terrain.GetComponent<Terrain>().SampleHeight(new Vector3(randomX, 0, randomZ));

            Vector3 spawnPosition = new Vector3(randomX, height + objHeight, randomZ);

            //Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            int index = Random.Range(0, objectOptions.Count);
            Instantiate(objectOptions[index], spawnPosition, Quaternion.identity);
        }
    }


    void Update()
    {
        
    }
}
