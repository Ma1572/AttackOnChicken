
using System;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    private float _xvalue;
#pragma warning disable 0649
    [SerializeField] private float _scrollSpeed;
#pragma warning restore 0649
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        Vector2 xvalue = Nokobot.TouchController.GetSwipe();
        UpdateValue(xvalue.x*0.05f);
    }
    public void UpdateValue(float value)
    {
        float _xvalue = Mathf.Clamp(_transform.position.x, -22f, 22f);
        _xvalue += value*Time.deltaTime*_scrollSpeed;
        var position = _transform.position;
        position = new Vector3(_xvalue,position.y,position.z);
        _transform.position = position;
    }

    
    
    
}
