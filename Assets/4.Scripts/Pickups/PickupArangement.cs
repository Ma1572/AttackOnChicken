using UnityEngine;

public class PickupArangement : MonoBehaviour
{
    public AnimationCurve curve;
    public float maxHeight;
    public float length;

    private Transform[] _children;

    private void Awake()
    {
        maxHeight = FindObjectOfType<MoveUp>().maxHeight;
        length = FindObjectOfType<CheckPointsLocations>().gap;
        Transform trans = transform;
        int count = trans.childCount;
        _children = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            _children[i] = trans.GetChild(i);
        }
    }

    private void Start()
    {
        _Setup();
    }

    private void _Setup()
    {
        foreach (Transform child in _children)
        {
            Vector3 position = child.localPosition;
            float pos = position.z;
            float t = curve.Evaluate(pos / length);
            position.y = Mathf.Lerp(0, maxHeight, t);
            child.localPosition = position;
        }
    }
}

