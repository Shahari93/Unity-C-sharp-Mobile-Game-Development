using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    public void LoadGamePlayScene(int sceneIndex) 
    {
        SceneManager.LoadScene(sceneIndex);
    }
}