using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SceneMenege : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI highScoreText;


    private void Start()
    {
        // If there is no high score, set it as zero
        int score = PlayerPrefs.GetInt(ScoreSystem.HighScoreString, 0);
        highScoreText.text = $"High Score: {score}";
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGamePlayScene(int sceneIndex)
    {
        // Checking if we have enough energy to start the game
        if (EnergyManager.Energy < 1)
        {
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}