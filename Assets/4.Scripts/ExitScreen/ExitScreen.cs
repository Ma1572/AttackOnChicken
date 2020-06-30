using UnityEngine;

public class ExitScreen : MonoBehaviour
{
    public float time;
    private float _t;
    private Vector3 _startPos;
    private Transform _transform;
    private Transform _outOfScreen;
    
    private void Start()
    {
        _transform = transform;
        _t = 0;
        _startPos = _transform.position;
    }
    
    public void Update()
    {
        _t += Time.deltaTime;
        _transform.position = Vector3.Lerp(_startPos, _outOfScreen.position, _t / time);
        if (_t >= time)
        {
            Destroy(gameObject);
        }
    }
    
    public void Setup(Transform target)
    {
        _outOfScreen = target;
    }
}
