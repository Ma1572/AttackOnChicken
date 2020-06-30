using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;
    [SerializeField] private float _scoreFactor;
#pragma warning restore 0649
    private float _score;
    private int _coin = 0;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _scoreText.text = _score.ToString("0");
        _coinText.text = _coin.ToString();
    }

    private void Update()
    {
        if (!_gameManager.GetPause())
        {
            _score += Time.deltaTime * _scoreFactor;
            _scoreText.text = _score.ToString("0");
        }
    }

    public void AddCoin()
    {
        _coin++;
        _coinText.text = _coin.ToString();
    }

    public int GetScore() => Mathf.RoundToInt(_score);

    public int GetCoins() => _coin;

    public void ResetScene()
    {
        _score = 0;
        _coin = 0;
        _gameManager = FindObjectOfType<GameManager>();
        _scoreText.text = _score.ToString("0");
        _coinText.text = _coin.ToString();
    }

    public void Pause()
    {
        _gameManager.TogglePause();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
