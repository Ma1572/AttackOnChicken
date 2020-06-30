
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    
#pragma warning disable 0649
    [SerializeField] private float _timer;
    [SerializeField] private float _moveTime;
#pragma warning restore 0649

    private Transform _transform;

    private GameManager _gameManager;

    private void OnEnable()
    {
        _transform = transform;
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        _timer = _gameManager.spawnTimer;
    }
    
    private void Update()
    {
        _timer -= Time.deltaTime*_moveTime;
        _transform.position = new Vector3(_transform.position.x,_transform.position.y,_timer);
    }
}
