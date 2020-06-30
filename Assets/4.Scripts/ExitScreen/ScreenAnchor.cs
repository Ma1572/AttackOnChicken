using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ScreenAnchor : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private bool _runInEditor = false;
#endif

    private Transform _transform;
    private Camera _camera;

    public enum UpdateType
    {
        Start,
        Update
    }

    public enum AnchorType
    {
        None,
        Center,
        Top,
        Bottom,
        Left,
        Right,
        TopRight,
        TopLeft,
        BottomRight,
        BottomLeft
    }
    
    [SerializeField] private float _distance = 10f;
    [SerializeField] private UpdateType _updateType = UpdateType.Start;
    [SerializeField] private AnchorType _anchorType = AnchorType.None;
    
    private void Awake()
    {
        _Setup();
    }

    private void Start()
    {
        if (_anchorType == AnchorType.None)
            return;

        _PositionUpdate();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying && !_runInEditor)
            return;
#endif
        if (_updateType != UpdateType.Update)
            return;
        if (_camera == null || _transform == null)
        {
            _Setup();
        }

        _PositionUpdate();
    }

    private void _PositionUpdate()
    {

        Vector3 position = Vector3.zero;

        switch (_anchorType)
        {
            case AnchorType.None:
                return;
            case AnchorType.Center:
                position = new Vector3(0.5f, 0.5f, 0f);
                break;
            case AnchorType.Top:
                position = new Vector3(0.5f, 1f, 0f);
                break;
            case AnchorType.Bottom:
                position = new Vector3(0.5f, 0f, 0f);
                break;
            case AnchorType.Left:
                position = new Vector3(0f, 0.5f, 0f);
                break;
            case AnchorType.Right:
                position = new Vector3(1f, 0.5f, 0f);
                break;
            case AnchorType.TopRight:
                position = new Vector3(1f, 1f, 0f);
                break;
            case AnchorType.TopLeft:
                position = new Vector3(0f, 1f, 0f);
                break;
            case AnchorType.BottomRight:
                position = new Vector3(1f, 0f, 0f);
                break;
            case AnchorType.BottomLeft:
                position = new Vector3(0f, 0f, 0f);
                break;
        }

        Ray ray = _camera.ViewportPointToRay(position);
        position = ray.GetPoint(_distance);

        _transform.position = position;
    }

    private void _Setup()
    {
        _transform = transform;
        _camera = Camera.main;
        if (_camera == null)
            _camera = FindObjectOfType<Camera>();
        if (_camera == null)
            enabled = false;
    }
}
