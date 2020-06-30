using UnityEngine;


public class MoveUp : MonoBehaviour
{
    public float maxHeight = 2f;
    public float time = 3f;
    public float _t = 0f;

    public Animator anim;

    private AnimationCurve _curve;
    private GameManager _gameManager;
    private Transform _transform;
    private static readonly int IsDashDown = Animator.StringToHash("IsDashDown");

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _curve = new AnimationCurve();
        _curve.AddKey(0f, 0f);
        _curve.AddKey(0.5f, maxHeight);
        _curve.AddKey(1f, 0f);
        _transform = transform;
    }

    void Update()
    {
        if (_gameManager.GetPause()) return;
        _t += Time.deltaTime;

        if (_transform.position.y <= 0.5)
        {
            _gameManager.TogglePause();
            _gameManager.LoadGameOverScene();
            anim.gameObject.SetActive(false);
            return;
        }


        Vector3 pos = _transform.position;
        pos.y = _curve.Evaluate(_t / time);
        _transform.position = pos;

        if (_t > time / 2f)
        {
            anim.SetBool(IsDashDown, true);
        }
    }

    public void Jump()
    {
        UpdateNext();
        _t = 0;
        anim.SetBool(IsDashDown, false);
    }

    public void UpdateNext()
    {
        WorldAutoMovement[] handlers = FindObjectsOfType<WorldAutoMovement>();
        foreach (WorldAutoMovement item in handlers)
        {
            item.UpdateNext();
        }
        
        Bounce[] bounces = FindObjectsOfType<Bounce>();
        foreach (Bounce item in bounces)
        {
            item.UpdateNext();
        }
    }
}
