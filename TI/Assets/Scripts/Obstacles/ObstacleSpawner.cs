using UnityEngine;
using System;

public class ObstacleSpawner : MonoBehaviour 
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 1.5f;
    [SerializeField] private GameObject[] _spawnCoinsOrPower;
    //Obstaculos
    [SerializeField] private GameObject[] _obstacle;

    private float _timer;
    System.Random rnd = new();

    void Start()
    {
        rnd = new System.Random();
    }

    private void Update() 
    {
        System.Random random = new();
        int _randomNumber = random.Next(2, 5);

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
        
        int _randomSpawn = rnd.Next(4);
        int _randomSpawnCoinOrPower = rnd.Next(_spawnCoinsOrPower.Length);

        GameObject obstacle = null;

        switch (_randomSpawn) 
        {
            case 0:
                obstacle = Instantiate(_obstacle[_randomSpawn], new Vector3(16.89f, 3.874193f, 1.610812f), Quaternion.identity);
                Destroy(obstacle, 13f);
                Debug.Log("Obstaculo 1");
                
            break;
            case 1:
                obstacle = Instantiate(_obstacle[_randomSpawn], spawnPos, Quaternion.identity);
                Destroy(obstacle, 13f);
                Debug.Log("Obstaculo 2");
            break;
            case 2:
                obstacle = Instantiate(_obstacle[_randomSpawn], _spawnCoinsOrPower[_randomSpawnCoinOrPower].transform.position, Quaternion.identity);
                Destroy(obstacle, 13f);
                Debug.Log("Moeda");  
            break;
            case 3:
                obstacle = Instantiate(_obstacle[_randomSpawn], _spawnCoinsOrPower[_randomSpawnCoinOrPower].transform.position, Quaternion.identity);
                Destroy(obstacle, 13f);
                Debug.Log("PowerUP");
                break;
        }
    }
}