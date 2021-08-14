using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private AndroidNotificationHandler androidNotification;

    // setting the high score to the text component
    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreManager.HighScoreKey, 0);
        highScoreText.text = $"High Score: {highScore}";
    }

    public void StartGameplayScene(int sceneIndex)
    {
        // Checking if energy is above 1, if not we can't play
        if (EnergyManager.Energy < 1)
        {
            return;
        }

        // reducing one energy every time we play, and setting the energy anount to player prefs
        EnergyManager.Energy--;
        PlayerPrefs.SetInt(EnergyManager.EnergyKey, EnergyManager.Energy);

        // If energy equals 0 we set the time to when the enrgy will recharge
        if (EnergyManager.Energy == 0)
        {
            DateTime energyReadyTime = DateTime.Now.AddMinutes(EnergyManager.EnergyRechargeRate);
            PlayerPrefs.SetString(EnergyManager.EnergyReadyKey, energyReadyTime.ToString());
#if UNITY_ANDROID
            androidNotification.ScheduleNotification(energyReadyTime);
#endif
        }

        SceneManager.LoadScene(sceneIndex);
    }
}