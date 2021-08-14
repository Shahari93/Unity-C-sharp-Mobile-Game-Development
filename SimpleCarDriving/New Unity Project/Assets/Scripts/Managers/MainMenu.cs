using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    // setting the high score to the text component
    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreManager.HighScoreKey, 0);
        highScoreText.text = $"High Score: {highScore}";
    }
}