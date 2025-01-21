using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the target camera will follow
    public Transform target;
    // Reference to backgrounds
    public Transform farBackground, middleBackground;

    // Variables to set the minimum and maximum height of the camera
    public float minHeight, maxHeight;

    // Variable to store the last x position of the target
    // private float lastXPos;

    private Vector2 lastPos;

    void Start()
    {
        // lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    void Update()
    {
        // Set the camera's position to the target's position
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Clamp the camera's y position
        // float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        // Set the camera's position to the clamped y position
        // transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        
        // Set the camera's position to the target's x position and clamped y position
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        // Calculate the amount to move the backgrounds
        //float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        // Move the backgrounds
        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;

        // Update the last x position
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }
}
