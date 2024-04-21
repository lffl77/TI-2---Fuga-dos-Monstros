using UnityEngine;
using System;

public class ObstacleSpawner : MonoBehaviour 
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 3f;

    //Obstaculos
    [SerializeField] private GameObject[] _obstacle;

    private float _timer;

    private void Update() 
    {
        System.Random random = new();
        int _randomNumber = random.Next(2, 8);

        if(_timer > _maxTime)
        {
            Spawner();
            _timer = 0f;
            _maxTime = _randomNumber;
        }

        _timer += Time.deltaTime;
    }

    private void Spawner()
    {   
        Vector3 spawnPos = transform.position + new Vector3(0, UnityEngine.Random.Range(-_heightRange, _heightRange));
        System.Random rnd = new();

        int _randomSpawn = rnd.Next(0 , 3);

        if(_randomSpawn == 0)
        {
            
            GameObject obstacle = Instantiate(_obstacle[_randomSpawn], new Vector3(16.89f, -1.1f, 1.610812f), Quaternion.identity);
            Destroy(obstacle, 10f);
        } 
        else if (_randomSpawn == 1)
        {
            
            GameObject obstacle = Instantiate(_obstacle[_randomSpawn], spawnPos, Quaternion.identity);
            Destroy(obstacle, 10f);  
        }
        else if (_randomSpawn == 2)
        {
            
            GameObject obstacle = Instantiate(_obstacle[_randomSpawn], spawnPos, Quaternion.identity);
            Destroy(obstacle, 10f);  
        }
    }
}