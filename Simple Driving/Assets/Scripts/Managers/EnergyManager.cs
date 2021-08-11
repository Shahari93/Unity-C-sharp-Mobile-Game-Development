using System;
using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeRateInMinutes;
    [SerializeField] private TextMeshProUGUI energyText;
    private int energy;
    public int Energy { get; set; }

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    // When ever we open the game or load the scene
    private void Start()
    {
        EnergyLoadUp();
    }

    private void EnergyLoadUp()
    {
        // loading up the energy, and if there is no value, the default will be the max energy
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);


        // Checking if the energy is equal to 0
        if (energy == 0)
        {
            // check when energy should be recharged
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyString == string.Empty) { return; }

            // convering from string to date time
            DateTime energyReady = DateTime.Parse(energyReadyString);


            // means that we are after the point in time that the energy has recharged
            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }

        }
        energyText.text = $"Energy: {energy}";
    }
}
