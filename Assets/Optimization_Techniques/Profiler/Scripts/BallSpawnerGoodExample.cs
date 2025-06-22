using UnityEngine;

/// <summary>
/// Spawns random balls at random positions within a defined range.
/// Uses InvokeRepeating for controlled spawning at regular intervals.
/// </summary>
public class BallSpawnerGoodExample : MonoBehaviour
{
    [SerializeField] private Transform[] _ballPrefabs;
    [SerializeField] private float _spawnRange = 2f;
    [SerializeField] private int _numberOfBalls = 5;
    [SerializeField] private float _spawnInterval = 1f;

    private bool _isSpawning;

    /// <summary>
    /// Enables or disables spawning of balls at regular intervals.
    /// </summary>
    /// <param name="canSpawnBalls">True to start spawning, false to stop.</param>
    public void SetSpawnBalls(bool canSpawnBalls)
    {
        if (canSpawnBalls && !_isSpawning)
        {
            _isSpawning = true;
            InvokeRepeating(nameof(SpawnBalls), 0f, _spawnInterval);
        }
        else if (!canSpawnBalls && _isSpawning)
        {
            _isSpawning = false;
            CancelInvoke(nameof(SpawnBalls));
        }
    }

    /// <summary>
    /// Spawns the configured number of balls in a single spawn event.
    /// </summary>
    private void SpawnBalls()
    {
        for (int i = 0; i < _numberOfBalls; i++)
        {
            SpawnRandomBall();
        }
    }

    /// <summary>
    /// Spawns a single ball at a random position within the spawn range.
    /// </summary>
    private void SpawnRandomBall()
    {
        int randomIndex = Random.Range(0, _ballPrefabs.Length);
        float randomX = Random.Range(-_spawnRange, _spawnRange);
        float randomZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);

        Instantiate(_ballPrefabs[randomIndex], spawnPosition, Quaternion.identity, transform);
    }
}
