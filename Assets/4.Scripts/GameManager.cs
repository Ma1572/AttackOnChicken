using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    [Header("--- Object Pooling Parameters ---")]
    
    [Tooltip("Set the objects origin line on the Z axis")]
    public float spawnTimer;
    [Tooltip("Set the initial objectpool size")]
    public int initialPoolSize;
    [Tooltip("Set the spawn interval between objects")]
    public float spawnRate;
    [Tooltip("Set an increasing spawnrate Interval")]
    public float spawnRateIncrease;
    [Tooltip("Set a boundary for the spawnrate increase")]
    public float maxSpawnRate;
    [Tooltip("Delay the object spawning at the beginning of the game")]
    public float spawnDelay;
    
    [Header("--- Jump Parameters ---")]
    [Tooltip("Set the jump timer")]
    public float JumpTime;
    [Tooltip("Set the jump height")]
    public float JumpHeight;

    [Space]
#pragma warning disable 0649   
    [SerializeField] private bool _isPaused;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private GameObject _particle;
    [SerializeField] private AudioClip _music;
    [SerializeField] private AudioClip _startSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private WorldAutoMovement startPlatform;
    [SerializeField] private Transform _outOfScreen;
    [SerializeField] private GameObject _pickUpParent;
#pragma warning restore 0649
    private UIManager _uiManager;
    private void Start()
    {

        AudioManager.SetBackground(_music);
    }
    
    public bool GetPause() => _isPaused;

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        
    }
    public void AddCoin()
    {
        _uiManager.AddCoin(); 
    }

    public Transform GetOutOfScreen() => _outOfScreen;

    public GameObject GetPickUpParent() => _pickUpParent;

    public void LoadGameOverScene()
    {
        AudioManager.PlayEffect(_winSound);
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive).completed += _SetGameOverScores;
    }

    private void _SetGameOverScores(AsyncOperation operation)
    {
        GameOverManager._instatnce.updateScores(_uiManager.GetScore(),_uiManager.GetCoins());
    }

    public async void StartGame()
    {
        _camera.Priority = 11;
        await Task.Delay(2500);
        TogglePause();
        startPlatform.ResetPause();
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive).completed += operation =>
            {
                _uiManager = FindObjectOfType<UIManager>();
                _uiManager.ResetScene(); 
            };
        _particle.SetActive(true);
        AudioManager.PlayEffect(_startSound);
    }
}
