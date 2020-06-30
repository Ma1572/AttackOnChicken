using System.Collections.Generic;
using UnityEngine;

public class WorldAutoMovement : MonoBehaviour
{
    private MoveUp _player;
#pragma warning disable 0649
    [SerializeField] private float time = 5f;
    [SerializeField] private List<GameObject> positions;
    [SerializeField] private bool Preset;
#pragma warning restore 0649
    private GameObject _spawnposition;
    private GameObject _endPosition;
    private bool _paused;
    private int _position = 0;
    private float _t = 0f;

    private void Start()
    {
        _player = FindObjectOfType<MoveUp>();
        time = _player.time;
    }
    
    private void OnEnable()
    {
        if (!Preset)
        {
            positions = FindObjectOfType<CheckPointsLocations>().checkPoints;
        }
        _position = 0;
        _spawnposition = positions[_position];
        _endPosition = positions[_position+1];
        _t = 0f;
    }
    
    private void Update()
    {
        if (!_paused)
        {
            _t = _player._t;
            transform.position =
                Vector3.Lerp(_spawnposition.transform.position, _endPosition.transform.position, _t / time);
        }
    }
    
    public void UpdateNext()
    {
        if (_paused) return;
        _position++;
        if (_position + 1 >= positions.Count)
        {
            if (GetComponent<RecycledObject_Dynamic>() != null)
            {
                GetComponent<RecycledObject_Dynamic>().ReturnObject(this.GetComponent<GameObject>());
                _position = 0;
            }
            else
            {
                _paused = true;
                return;
            }
        }
        _spawnposition = positions[_position];
        _endPosition = positions[_position + 1];
    }
    
    public void ResetPause()
    {
        _paused = false;
    }
}
