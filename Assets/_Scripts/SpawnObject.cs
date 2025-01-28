using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    
    protected float _spawnRate;

    [SerializeField] private float spawnTime = 0.5f;
    private float _nextTimeSpawn;

    protected virtual void Start()
    {
        
    }

    private void Update()
    {
        if (Time.time > _nextTimeSpawn && _spawnRate >= Random.Range(0, 1f))
        {
            Spawn();
            _nextTimeSpawn = spawnTime + Time.time;
        }
    }

    protected virtual void Spawn()
    {
        Instantiate(gameObj, transform.position, transform.rotation);
    }
}
