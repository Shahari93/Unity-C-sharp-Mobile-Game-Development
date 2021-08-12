using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            EnergyManager.Energy -= 1;
            PlayerPrefs.SetInt(EnergyManager.EnergyKey, EnergyManager.Energy);
            SceneMenege.LoadMenuScene();
        }
    }
}