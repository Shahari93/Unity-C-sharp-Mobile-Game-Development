using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SceneMenege : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI highScoreText;


    private void Start()
    {
        int score = PlayerPrefs.GetInt(ScoreSystem.HighScoreString, 0);
        highScoreText.text = $"High Score: {score}";
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGamePlayScene(int sceneIndex)
    {
        if (EnergyManager.Energy < 1)
        {
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}