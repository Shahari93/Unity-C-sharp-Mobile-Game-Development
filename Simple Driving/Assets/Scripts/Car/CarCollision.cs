using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Removing 1 energy every collision with an obstacle
            EnergyManager.Energy -= 1;

            // setting the new energy value (after hitting an obstacle) to player prefs
            PlayerPrefs.SetInt(EnergyManager.EnergyKey, EnergyManager.Energy);
            SceneMenege.LoadMenuScene();
        }
    }
}