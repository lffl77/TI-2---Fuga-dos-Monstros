using UnityEngine;

public class ObstacleSpawner : MonoBehaviour 
{
    [SerializeField] private float _maxTime = 1.5f;
    private float _heightRange = 2f;
    [SerializeField] private GameObject[] _spawnCoinsOrPower;
    [SerializeField] private GameObject[] _obstacle;
    [SerializeField] private Transform coinSpawnPoint1;
    [SerializeField] private Transform coinSpawnPoint2;

    private float _timer;
    private System.Random rnd;

    void Start()
    {
        rnd = new System.Random();
    }

    private void Update() 
    {
        if (_timer >= _maxTime)
        {
            Spawner();
            _timer = 0f;
            _maxTime = rnd.Next(2, 5);
        }

        _timer += Time.deltaTime;
    }

    private void Spawner()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        
        int _randomSpawn = rnd.Next(_obstacle.Length);
        int _randomSpawnCoinOrPower = rnd.Next(_spawnCoinsOrPower.Length);

        GameObject spawnedObject = Instantiate(_obstacle[_randomSpawn], spawnPos, Quaternion.identity);
        Debug.Log($"Obstacle {_randomSpawn + 1}");

        if (rnd.Next(4) == 0) // 25% de chance
        {
            Transform selectedSpawnPoint = (rnd.Next(2) == 0) ? coinSpawnPoint1 : coinSpawnPoint2;
            spawnPos = selectedSpawnPoint.position;
            spawnedObject = Instantiate(_spawnCoinsOrPower[_randomSpawnCoinOrPower], spawnPos, Quaternion.identity);
            Debug.Log($"Spawned: {_spawnCoinsOrPower[_randomSpawnCoinOrPower].name} at {spawnPos}");
        }

        if (spawnedObject != null)
        {
            Destroy(spawnedObject, 13f);
        }
    }
}
