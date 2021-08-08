using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private float score;
    [SerializeField] private int scoreMultiply;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() 
    {
        score += Time.deltaTime * scoreMultiply;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
}
