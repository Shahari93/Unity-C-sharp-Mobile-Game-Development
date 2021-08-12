using System;
using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private int energyReachrgeRate = 1;
    private static int maxEnergy = 5;
    private static int energy;

    public static int Energy 
    {
        get
        {
            return energy;
        }
        set
        {
            energy = value;
        }
    }

    public static int MaxEnergy
    {
        get
        {
            return maxEnergy;
        }
    }

    public const string EnergyKey = "Energy";
    public const string EnergyReadyKey = "EnergyReady";

    // When ever we open the game or load the scene
    private void Start()
    {
        EnergyLoadUp();
    }

    private void EnergyLoadUp()
    {
        // loading up the energy, and if there is no value, the default will be the max energy
        Energy = PlayerPrefs.GetInt(EnergyKey, MaxEnergy);


        // Checking if the energy is equal to 0
        if (Energy == 0)
        {

            // check when energy should be recharged
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyString == string.Empty) { return; }

            // convering from string to date time
            DateTime energyReady = DateTime.Parse(energyReadyString);

            // Adding one minute from now so the energy will recharge
            DateTime oneMinuteFromNow = DateTime.Now.AddMinutes(energyReachrgeRate);
            PlayerPrefs.SetString(EnergyManager.EnergyReadyKey, oneMinuteFromNow.ToString());
            // means that we are after the point in time that the energy has recharged
            if (DateTime.Now > energyReady)
            {
                Energy = MaxEnergy;
                PlayerPrefs.SetInt(EnergyKey, Energy);
            }
        }
        energyText.text = $"Energy: {Energy}";
    }
}
