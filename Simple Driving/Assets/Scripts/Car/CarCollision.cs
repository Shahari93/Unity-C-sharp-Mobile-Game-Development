using UnityEngine;

public class CarCollision : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) 
   {
        if(other.CompareTag("Obstacle"))
        {
            SceneMenege.LoadMenuScene();
        }
   }
}