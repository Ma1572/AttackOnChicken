
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
   private MoveUp _player;
#pragma warning disable 0649
   [SerializeField] private List<GameObject> _positions;
   [SerializeField] private AudioClip _sound;
#pragma warning restore 0649
   private GameObject _spawnposition;
   private GameObject _endPosition;
   private float _time = 3f;
   private bool _jumped;
   private int _position = 0;
   private float _t = 0f;
   private Transform _transform;

   private void Start()
   {
      _player = FindObjectOfType<MoveUp>();
      _transform = transform;
      _time = _player.time;
   }

   private void OnEnable()
   {
      _positions = FindObjectOfType<CheckPointsLocations>().bouncePoints;
      _jumped = false;
      _position = 0;
      _spawnposition = _positions[_position];
      _endPosition = _positions[_position+1];
      _t = 0f;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag=="Player"&&!_jumped)
      {
         _player.Jump();
         _jumped = true;
         AudioManager.PlayEffect(_sound);
      }
   }

   private void Update()
   {
      _t = _player._t;
      float Z = Mathf.Lerp(_spawnposition.transform.position.z, _endPosition.transform.position.z, _t / _time);
      var transform1 = _transform;
      var position = transform1.position;
      position = new Vector3(position.x, position.y, Z);
      transform1.position = position;
   }

   public void UpdateNext()
   {
      _position++;
      if (_position+1 >= _positions.Count)
      {
         GetComponent<RecycledObject_Dynamic>().ReturnObject(this.GetComponent<GameObject>());
         _position = 0;
      }
      _spawnposition = _positions[_position];
      _endPosition = _positions[_position+1];
        
   }
}
