using UnityEngine;

public class GetSide : MonoBehaviour
{
    public Camera Camera;
    public string Side;

    void Start()
    {
        float cameraH = Camera.orthographicSize * 2;
        float cameraW = cameraH * Camera.aspect;

        if(Side == "Up")
        {
            Vector3 newPos = new Vector3(Camera.transform.position.x , Camera.transform.position.y + cameraH/2, 0);
            transform.position = newPos;
        }
        if (Side == "Left")
        {
            Vector3 newPos = new Vector3(Camera.transform.position.x - cameraW / 2, Camera.transform.position.y, 0);
            transform.position = newPos;
        }
        if (Side == "Right")
        {
            Vector3 newPos = new Vector3(Camera.transform.position.x + cameraW / 2, Camera.transform.position.y, 0);
            transform.position = newPos;

        }
        if (Side == "Down")
        {
            Vector3 newPos = new Vector3(Camera.transform.position.x, Camera.transform.position.y - cameraH / 2, 0);
            transform.position = newPos;

        }
    }
}
