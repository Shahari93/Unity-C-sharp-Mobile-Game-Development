using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] private float speedGain = 0.5f;
    [SerializeField] private float rotateSpeed = 200f;

    // 0 - no steer, 1 - right steer, -1 - left steer
    private int steerValue = 0;

    private void Update()
    {
        CarForwardMovement();
        CarRotation();
    }

    private void CarForwardMovement()
    {
        carSpeed += speedGain * Time.deltaTime;
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }

    private void CarRotation()
    {
        transform.Rotate(0, rotateSpeed * steerValue * Time.deltaTime, 0f);
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
