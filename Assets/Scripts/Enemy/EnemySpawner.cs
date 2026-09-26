using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Vector3 _spawnAreaMin;
    [SerializeField] private Vector3 _spawnAreaMax;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        _spawnAreaMin.z = _player.transform.position.z + 6;
        _spawnAreaMax.z = _player.transform.position.z + 15;
        if (_spawnAreaMax.z > 100)
        {
            _spawnAreaMax.x = 100;
        }
        int index = Random.Range(0, _enemyPrefabs.Length);
        GameObject prefab = _enemyPrefabs[index];

        Vector3 spawnPos = new Vector3(
            Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),
            _spawnAreaMin.y,
            Random.Range(_spawnAreaMin.z, _spawnAreaMax.z)
        );
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
