using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int scoreMultipler = 4;
    private float score;

    public const string HighScoreKey = "HighScore";

    private void Update()
    {
        AddScore();
    }

    private void AddScore()
    {
        score += scoreMultipler * Time.deltaTime; // if alive for one second score will be one, alive for two seconds socre will be two...
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    // When the score system class gets destroied we check the high score.
    private void OnDestroy()
    {
        // defualt high score (if we don't find any high score, defualt will be 0)
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}