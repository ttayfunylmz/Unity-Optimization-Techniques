using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI controller that manages starting and stopping ball spawners via buttons.
/// Ensures only one spawner is active at a time.
/// </summary>
public class ProfilerUI : MonoBehaviour
{
    [SerializeField] private Button _startButton, _stopButton;
    [SerializeField] private BallSpawnerGoodExample _ballSpawnerGoodExample;
    [SerializeField] private BallSpawnerBadExample _ballSpawnerBadExample;

    /// <summary>
    /// Subscribes button click events to handler methods.
    /// </summary>
    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
        _stopButton.onClick.AddListener(OnStopButtonClicked);
    }

    /// <summary>
    /// Handles start button click. Starts the appropriate spawner if conditions are valid.
    /// </summary>
    private void OnStartButtonClicked()
    {
        if (_ballSpawnerGoodExample.gameObject.activeInHierarchy && _ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            Debug.LogError("Both spawners are enabled, disable one of them.");
            return;
        }
        else if (!_ballSpawnerGoodExample.gameObject.activeInHierarchy && !_ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            Debug.LogError("Both spawners are disabled, enable one of them.");
            return;
        }
        else if (_ballSpawnerGoodExample.gameObject.activeInHierarchy && !_ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            _ballSpawnerGoodExample.SetSpawnBalls(true);
        }
        else if (!_ballSpawnerGoodExample.gameObject.activeInHierarchy && _ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            _ballSpawnerBadExample.SetSpawnBalls(true);
        }
    }

    /// <summary>
    /// Handles stop button click. Stops the active spawner if conditions are valid.
    /// </summary>
    private void OnStopButtonClicked()
    {
        if (_ballSpawnerGoodExample.gameObject.activeInHierarchy && _ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            Debug.LogError("Both spawners are enabled, disable one of them.");
            return;
        }
        else if (!_ballSpawnerGoodExample.gameObject.activeInHierarchy && !_ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            Debug.LogError("Both spawners are disabled, enable one of them.");
            return;
        }
        else if (_ballSpawnerGoodExample.gameObject.activeInHierarchy && !_ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            _ballSpawnerGoodExample.SetSpawnBalls(false);
        }
        else if (!_ballSpawnerGoodExample.gameObject.activeInHierarchy && _ballSpawnerBadExample.gameObject.activeInHierarchy)
        {
            _ballSpawnerBadExample.SetSpawnBalls(false);
        }
    }
}
