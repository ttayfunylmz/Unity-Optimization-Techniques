using UnityEngine;

/// <summary>
/// Example class that spawns random balls at random positions within a defined range.
/// Spawns are controlled by a flag and happen every frame when enabled (inefficient example).
/// </summary>
public class BallSpawnerBadExample : MonoBehaviour
{
    [SerializeField] private Transform[] _ballPrefabs;
    [SerializeField] private float _spawnRange = 2f;
    [SerializeField] private int _numberOfBalls = 5;

    private bool _canSpawnBalls;
    private int _ballCount;

    /// <summary>
    /// Called every frame. Spawns balls if spawning is enabled.
    /// </summary>
    private void Update()
    {
        if (!_canSpawnBalls) { return; }

        for (int i = 0; i < _numberOfBalls; i++)
        {
            SpawnRandomBall();
        }
    }

    /// <summary>
    /// Spawns a single random ball at a random position within the spawn range.
    /// </summary>
    private void SpawnRandomBall()
    {
        int randomIndex = Random.Range(0, _ballPrefabs.Length);
        float randomX = Random.Range(-_spawnRange, _spawnRange);
        float randomZ = Random.Range(-_spawnRange, _spawnRange);

        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);
        Instantiate(_ballPrefabs[randomIndex], spawnPosition, Quaternion.identity, transform);

        _ballCount++;
        Debug.Log("Random Ball Spawned: " + _ballCount);
    }

    /// <summary>
    /// Enables or disables ball spawning.
    /// </summary>
    /// <param name="canSpawnBalls">True to start spawning, false to stop.</param>
    public void SetSpawnBalls(bool canSpawnBalls)
    {
        _canSpawnBalls = canSpawnBalls;
    }
}
