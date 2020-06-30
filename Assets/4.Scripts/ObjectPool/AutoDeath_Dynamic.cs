using UnityEngine;


public class AutoDeath_Dynamic : MonoBehaviour
{
    private RecycledObject_Dynamic _recycledObject;
    private void Start()
    {
        _recycledObject = GetComponent<RecycledObject_Dynamic>();
    }
    public void ReturnObject()
    {
        _recycledObject.ReturnObject(gameObject);
    
    }
}
