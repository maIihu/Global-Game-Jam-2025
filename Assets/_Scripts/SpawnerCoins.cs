using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnBubble : MonoBehaviour
{
    [FormerlySerializedAs("obstacle")] [SerializeField] private GameObject bubble;

    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform midPoint;
    [SerializeField] private Transform rightPoint;
    
    [SerializeField] private float timeSpawn;
    private float _spawnTime = 5;

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
        
        int numberOfPointsToSpawn = 1;
        
        Shuffle(points);
        
        for (int i = 0; i < numberOfPointsToSpawn; i++)
        {
            Spawn(points[i]);
        }
    }

    private void Spawn(Transform point)
    {
        Vector3 pos = point.position;
        GameObject tmp = Instantiate(bubble, new Vector3(pos.x, pos.y - 2, 0), quaternion.identity);
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