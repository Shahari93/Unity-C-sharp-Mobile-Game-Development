using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int scoreMultipler = 4;
    private float score;

    private void Update()
    {
        score += scoreMultipler * Time.deltaTime; // if alive for one second score will be one, alive for two seconds socre will be two...
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
}
