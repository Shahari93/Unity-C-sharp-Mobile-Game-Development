using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Rigidbody2D currentBallRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (!Touchscreen.current.press.isPressed) // checking if we're not pressing
        {
            currentBallRigidbody.isKinematic = false;
            return;
        }
        currentBallRigidbody.isKinematic = true;
        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue(); // get the position of where the first finger is touching on the touch screen
        Vector3 worldTouchPos = mainCamera.ScreenToWorldPoint(touchPos);
        currentBallRigidbody.position = worldTouchPos;
    }
}
