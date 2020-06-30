
using UnityEngine;

public class RecycledObject_Dynamic : MonoBehaviour
{
    public ObjectPool_Dynamic pool;


    public void Setup(ObjectPool_Dynamic pool)
    {
        this.pool = pool;
    }

    public void ReturnObject(GameObject objectToReturn)
    {
        pool.AddToPool(gameObject); 
    }
    
}
