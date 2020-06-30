
using UnityEngine;

public class ScorePrefs : MonoBehaviour
{
    public int GetScore() => PlayerPrefs.GetInt("Highscore", 0);
    public int GetCoins() => PlayerPrefs.GetInt("TotalCoins", 0);
    public void SaveScore(int score) => PlayerPrefs.SetInt("Highscore", score);
    public void SaveCoins(int coins) => PlayerPrefs.SetInt("TotalCoins", GetCoins() + coins);
}
