using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouse = new Vector2(
            Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime,
            Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime
        );
        xRotation -= mouse.y;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouse.x);
    }
}
