using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;

    [Header("Offset & Follow")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [Header("Deadzone")]
    public float verticalDeadzone = 1f; 

    void LateUpdate()
    {
        Vector3 desiredPosition = transform.position;

        desiredPosition.x = Mathf.SmoothDamp(transform.position.x, target.position.x + offset.x, ref velocity.x, smoothTime);

        float deltaY = target.position.y - transform.position.y;
        if (Mathf.Abs(deltaY) > verticalDeadzone)
        {
            float targetY = target.position.y + offset.y - Mathf.Sign(deltaY) * verticalDeadzone;
            desiredPosition.y = Mathf.SmoothDamp(transform.position.y, targetY, ref velocity.y, smoothTime);
        }

        desiredPosition.z = offset.z;

        transform.position = desiredPosition;
    }
}
