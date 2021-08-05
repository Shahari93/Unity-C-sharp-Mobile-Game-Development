using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] private float changeSpeedOverTime = 0.1f;
    [SerializeField] private float turnSpeed = 200f;
    private int turnValue;

    private void Update() {
        carSpeed+=changeSpeedOverTime * Time.deltaTime; // change the car speed each second (frame independent)
        transform.Rotate(0f,turnValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }

    public void Steer(int value)
    {
        turnValue = value;
    }
}