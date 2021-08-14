using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ManageScenes : MonoBehaviour
{
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
        }

        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadMainMenuScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}