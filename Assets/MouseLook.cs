using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float yRotation = 0f;
    private Vector2 mouse = new Vector2();

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // mouse = context.ReadValue();
        Debug.Log(context);

    }

    void Update()
    {
        // Vector2 mouse = new Vector2(
        //     Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime,
        //     Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime
        // );
        yRotation -= mouse.y;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouse.x);
    }
}
