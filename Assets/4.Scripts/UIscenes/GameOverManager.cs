
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameOverManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinsText;
#pragma warning restore 0649

    private ScorePrefs _scorePrefs;
    private int _highscore=0;
    private int _score;
    private int _coins;
    public static GameOverManager _instatnce;
    private GameManager _gameManager;
    
    private void Awake()
    {
        _instatnce = this;
        _scorePrefs = GetComponent<ScorePrefs>();
        _highscore = _scorePrefs.GetScore();
    }

    public void updateScores(int score, int coins)
    {
        if (_highscore < score)
        {
            _highscore = score;
            _scorePrefs.SaveScore(score);
        }
        _score = score;
        _coins = _scorePrefs.GetCoins() + coins;
        _scorePrefs.SaveCoins(_coins);

        _highScoreText.text = _highscore.ToString("0");
        _scoreText.text = _score.ToString("0");
        _coinsText.text = _coins.ToString();
    }

    public void RetryPlay()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive).completed += _WaitForStart;
    }

    private void _WaitForStart(AsyncOperation operation)
    {
        Invoke(nameof(_StartGame), 0.2f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }

    private void _StartGame()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.StartGame();
        SceneManager.UnloadSceneAsync(3);
    }
    
    
}
