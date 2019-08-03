using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;


    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);

        if (distanceToHorizon < 120)
        {
            SpawnTriangles();
        }

    }

    private void SpawnTriangles()
    {
        int randomTriangle = UnityEngine.Random.Range(0, trianglePrefabs.Length);
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 30);
        Instantiate(trianglePrefabs[randomTriangle], spawnObstaclePosition, Quaternion.identity);
    }
}
