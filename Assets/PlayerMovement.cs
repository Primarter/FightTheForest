using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public float groundRadiusCheck = 0.4f;
    public LayerMask groundMask;
    public float speed = 12f;
    public float gravity = -27f;
    public float jumpHeight = 3.5f;
    public float dashDuration = .5f;
    public float dashSpeed = 100f;
    public int maxDashes = 2;
    public float dashCooldown = 1f;
    public AnimationCurve dashCurve = new AnimationCurve();

    Vector3 velocity;
    bool isGrounded = false;
    float dashInc = 1.0f;
    Vector3 dashDirection;
    int nbDashes = 1;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    void Start()
    {
        sw.Start();
        nbDashes = maxDashes;
    }

    void Update()
    {
        if ((float)(sw.ElapsedMilliseconds) / 1000 >= dashCooldown) {
            nbDashes = maxDashes;
            sw.Restart();
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadiusCheck, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;

        if ((Input.GetButtonDown("Dash") || Input.GetButtonDown("Fire2")) && nbDashes > 0) {
            if (nbDashes == maxDashes) sw.Restart();
            nbDashes--;
            dashInc = 0f;
            dashDirection = x != 0 || z != 0 ? direction : transform.forward;
        }

        if (dashInc < 1) {
            dashInc += Time.deltaTime / dashDuration;
            controller.Move(dashCurve.Evaluate(dashInc) * dashDirection * dashSpeed);
        } else
            controller.Move(direction * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundRadiusCheck);
    }
}
