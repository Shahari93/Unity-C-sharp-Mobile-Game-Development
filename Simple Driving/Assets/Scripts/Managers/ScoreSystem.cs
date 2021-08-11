using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public const string HighScoreString = "HighScore";
    private float score;
    [SerializeField] private int scoreMultiply;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() 
    {
        score += Time.deltaTime * scoreMultiply;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    // When ever the game object is destroied
    private void OnDestroy() 
    {
        int highScore = PlayerPrefs.GetInt(HighScoreString, 0); // if there is no high score, set the high score as 0

        // if the current score is higher then the high score
        if(score > highScore)
        {
            PlayerPrefs.SetInt(HighScoreString, Mathf.FloorToInt(score));
        }
    }
}
