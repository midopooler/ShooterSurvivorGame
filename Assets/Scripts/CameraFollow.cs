using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // The player's transform to follow
    public float smoothSpeed = 0.125f; // The speed at which the camera will smooth towards the target
    public Vector3 offset; // Offset of the camera from the player

    private void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}