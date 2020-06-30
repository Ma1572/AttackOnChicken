
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Dynamic : MonoBehaviour
{
#pragma warning disable 0649
   [SerializeField] private List<GameObject> _prefabs;
   [SerializeField] private GameObject _parent;
#pragma warning restore 0649
   
   private List<GameObject> _freeObject;
   private int _initialPoolSize;
   private GameManager _gameManager;
   private void Awake()
   {
      _gameManager = FindObjectOfType<GameManager>();
      _freeObject = new List<GameObject>();
      _initialPoolSize = _gameManager.initialPoolSize;
      for (int i = 0; i < _initialPoolSize; i++)
      {
         AddNewObject();
      }
   }

   public GameObject UseObject(Vector3 position, Quaternion rotation)
   {
      if (_freeObject.Count < 1)
      {
         AddNewObject();
      }
      GameObject objectToTuse;
      int index = Random.Range(0, _freeObject.Count);
      objectToTuse = _freeObject[index];
      _freeObject.RemoveAt(index);
      Transform objectTransform = objectToTuse.transform;
      objectTransform.position = position;
      objectTransform.rotation = rotation;
      objectTransform.SetParent(_parent.transform);
      objectToTuse.SetActive(true);
      return objectToTuse;
   }
   
   private void AddNewObject()
   {
      int poolIndex = Random.Range(0, _prefabs.Count);
      GameObject newObject;
      newObject = Instantiate(_prefabs[poolIndex], transform);
      RecycledObject_Dynamic recycledObject = newObject.GetComponent<RecycledObject_Dynamic>();
      recycledObject.Setup(this);
      newObject.SetActive(false);
      _freeObject.Add(newObject);
   }

   public void AddToPool(GameObject ObjectToReturn)
   {
      ObjectToReturn.SetActive(false);
      _freeObject.Add(ObjectToReturn);
   }
  
   
}
