using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private float detachDelayTime = 0.1f;
    [SerializeField] private float spawnNewBallDelay = 1f;
    [SerializeField] private GameObject ballPrefab = null;
    [SerializeField] private Rigidbody2D pivotPoint = null;


    private Camera mainCamera;
    private bool isDragging;
    private Rigidbody2D currentBallRigidbody;
    private SpringJoint2D currentSpringJoint;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewBall();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(currentBallRigidbody == null)
        {
            return;
        }

        if (!Touchscreen.current.press.isPressed) // checking if we're not pressing
        {
            if(isDragging) // if we draged the ball and released the finger
            {
                LaunchBall();
            }
            isDragging = false;
            
            return;
        }

        isDragging = true;
        currentBallRigidbody.isKinematic = true;
        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue(); // get the position of where the first finger is touching on the touch screen
        Vector3 worldTouchPos = mainCamera.ScreenToWorldPoint(touchPos);
        currentBallRigidbody.position = worldTouchPos;
    }

    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab,pivotPoint.position, Quaternion.identity);
        currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
        currentSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
        currentSpringJoint.connectedBody = pivotPoint; // attach the ball to the pivot
    }

    private void LaunchBall()
    {
        currentBallRigidbody.isKinematic = false;
        currentBallRigidbody = null;
        Invoke(nameof(DetachBall), detachDelayTime);
    }

    private void DetachBall()
    {
        currentSpringJoint.enabled = false;
        currentSpringJoint = null;
        Invoke(nameof(SpawnNewBall), spawnNewBallDelay);
    }
}
