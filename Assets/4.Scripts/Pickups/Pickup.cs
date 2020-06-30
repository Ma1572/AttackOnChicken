using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameManager gameManager;
#pragma warning disable 0649
    [SerializeField] private GameObject _exitObject;
    [SerializeField] private GameObject _parent;
    [SerializeField] private AudioClip _effect;
#pragma warning restore 0649

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _parent = gameManager.GetPickUpParent();
    }
    
    private void OnEnable()
    {
        GetComponentInChildren<Renderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Addcoin();
            GameObject item = Instantiate(_exitObject, _parent.transform);
            item.GetComponent<ExitScreen>().Setup(gameManager.GetOutOfScreen());
            item.transform.position = transform.position;
            item.SetActive(true);
            GetComponentInChildren<Renderer>().enabled = false;
            AudioManager.PlayEffect(_effect);
        }
    }
    
    private void Addcoin()
    {
        gameManager.AddCoin();
    }
  
}
