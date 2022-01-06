using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public float AngularSpeed = 100f;
    [SerializeField] public float lockDistance = 10f;
    [SerializeField] public float range = 2;
    [SerializeField] public GameObject target;
    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    private bool isFollowing;
    private Animator animator;

    void OnTriggerEnter(Collider info)
    {
        if (info.CompareTag("Player")) {
            this.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        // animator = GetComponent<Animator>();
        // this.target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        if (target) {
            if (range <= 4  && (target.transform.position - transform.position).magnitude <= 7) {
                // animator.SetTrigger("Attack");
                // target.GetComponent<HealthManager>().TakeDamage(1);
            } else if ((target.transform.position - transform.position).magnitude <= range) {
                // animator.SetBool("isFiring", true);
                // target.GetComponent<HealthManager>().TakeDamage(1);
            } else if (range > 4) {
                    // animator.SetBool("isFiring", false);
            }
            if ((target.transform.position - transform.position).magnitude > lockDistance) {
                this.GetComponent<MoveToDest>().unsetMoveTarget();
                if (range > 4) {
                    // animator.SetBool("isFiring", false);
                }
            } else {
                this.GetComponent<MoveToDest>().setMoveTarget(target.transform.position);
            }
        }
    }

    void FixedUpdate()
    {
        if (target) {
            Vector3 targetDirection = target.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = AngularSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lockDistance);
    }
}