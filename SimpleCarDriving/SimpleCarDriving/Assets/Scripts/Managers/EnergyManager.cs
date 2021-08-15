using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI energyText;

    [Header("Energy amount")]
    [SerializeField] private int maxEnergy;


    [SerializeField] private Button playButton;

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
        OnApplicationFocus(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        // if closing the app
        if(!hasFocus) { return; }

        //If we have focus (open or maximize the app) cancel all invokes 
        CancelInvoke();
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
            // Now the energy will recharged even if the game is still on
            else
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged), (energyReadyDateTime - DateTime.Now).Seconds);
            }
        }
        energyText.text = $"Enrgy: {energy}";
    }

    private void EnergyRecharged()
    {
        energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        playButton.interactable = true;
        energyText.text = $"Enrgy: {energy}";
    }
}