
using UnityEngine;

public class AutoSpawn_Dynamic : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnRate = 0.5f;
#pragma warning restore 0649
    private float _spawnIncrease = 0f;
    private float _maxSpawnRate;
    private float _spawnDelay;
    private ObjectPool_Dynamic _pool;
    private float _timer = 0f;

    private GameManager _gameManager;
    private void Awake()
    {
        _pool = GetComponent<ObjectPool_Dynamic>();
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _gameManager = FindObjectOfType<GameManager>();
        _spawnIncrease = _gameManager.spawnRateIncrease;
        _maxSpawnRate = _gameManager.maxSpawnRate;
        _spawnDelay = _gameManager.spawnDelay;
    }

    void Update()
    {
        if (_gameManager.GetPause()) return;
        if (_spawnDelay > 0)
        {
            _spawnDelay -= Time.deltaTime;
        }
        else
        {
            _timer -= Time.deltaTime;
            if (_timer < 0f)
            {
                UseObject();
                _timer = _spawnRate;
            }
        }

        if (_spawnRate > _maxSpawnRate)
        {
            _spawnRate -= Time.deltaTime * _spawnIncrease;
        }
    }

    public void UseObject()
    {
        int spawnPointToUse = Random.Range(0, _spawnPoints.Length);
        GameObject newObject = _pool.UseObject(_spawnPoints[spawnPointToUse].transform.position,
            transform.parent.rotation);
        newObject.transform.rotation = Quaternion.identity;
        newObject.transform.localRotation =
            Quaternion.Euler(0, 0, newObject.transform.localRotation.eulerAngles.z);
        
    }
}
