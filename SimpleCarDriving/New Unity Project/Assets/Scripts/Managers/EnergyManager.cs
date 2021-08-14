using System;
using TMPro;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI energyText;

    [Header("Energy amount")]
    [SerializeField] private int maxEnergy;

    #region energyRechageRate
    private static int energyRechargeRate = 1; // In minutes
    public static int EnergyRechargeRate
    {
        get
        {
            return energyRechargeRate;
        }
    }
    #endregion

    #region energyAmount
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

    #endregion

    public const string EnergyKey = "Energy";
    public const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        EnergyCheck();
    }


    private void EnergyCheck()
    {
        // every time we load the main menu. Defualt value will be the max energy
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            // Only if there is an error when loading the string
            if (energyReadyString == string.Empty)
            {
                return;
            }

            // converting from string to date time
            DateTime energyReadyDateTime = DateTime.Parse(energyReadyString);

            // When we are after the point in time when the enrgy was ready
            if (DateTime.Now > energyReadyDateTime)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }

        }
        energyText.text = $"Enrgy: {energy}";
    }
}