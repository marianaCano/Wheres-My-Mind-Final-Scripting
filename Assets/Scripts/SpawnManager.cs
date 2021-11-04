using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject motivation;
    [SerializeField] GameObject[] distraction;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] spawnDistractions;
    Vector2 vectorTemp;


    void Start()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        player.transform.position = new Vector2(spawnPoints[spawnPointIndex].position.x, spawnPoints[spawnPointIndex].position.y);

        vectorTemp = player.transform.position;
        motivation.transform.position = vectorTemp * -1;

        for (int i = 0; i < distraction.Length; i++)
        {
            int randomSpawn = Random.Range(0, spawnDistractions.Length);
            distraction[i].transform.position = new Vector2(spawnDistractions[randomSpawn].position.x, spawnDistractions[randomSpawn].position.y);
        }
    }
}
