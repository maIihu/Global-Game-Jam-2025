using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform midPoint;
    [SerializeField] private Transform rightPoint;
    
    [SerializeField] private float timeSpawn;
    private float _spawnTime = 0;

    public Transform parentGO;
    
    private void Update()
    {
        if (Time.time > _spawnTime)
        {
            _spawnTime = timeSpawn + Time.time;
            SpawnObstaclesAtRandomPoints();
        }
    }

    private void SpawnObstaclesAtRandomPoints()
    {
        List<Transform> points = new List<Transform> { leftPoint, midPoint, rightPoint };
        
        int numberOfPointsToSpawn = Random.Range(1, 3);
        
        Shuffle(points);
        
        for (int i = 0; i < numberOfPointsToSpawn; i++)
        {
            Spawn(points[i]);
        }
    }

    private void Spawn(Transform point)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 180);
        GameObject tmp = Instantiate(obstacle, point.position, rotation);
        tmp.transform.SetParent(parentGO);
    }
    
    private void Shuffle(List<Transform> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}