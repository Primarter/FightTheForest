using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera viewCamera;

    public float damage = 2.0f;

    public float range = 30f;

    public float forceMultiplier = 3f;

    public LayerMask shootableLayer;

    public GameObject onHitSpawn;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (Physics.Raycast(viewCamera.transform.position, viewCamera.transform.forward,
            out RaycastHit hitInfo, range, shootableLayer)) {
                if (hitInfo.rigidbody != null) {
                    hitInfo.rigidbody.AddForce(viewCamera.transform.forward * forceMultiplier, ForceMode.Impulse);
                }
                Debug.Log("Hit Something");
                Instantiate(onHitSpawn, hitInfo.point, hitInfo.transform.rotation);
            } else
                Debug.Log("Missed");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (Physics.Raycast(viewCamera.transform.position, viewCamera.transform.forward,
        out RaycastHit hitInfo, range, shootableLayer)) {
            Gizmos.DrawSphere(hitInfo.point, .5f);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawRay(viewCamera.transform.position, viewCamera.transform.forward*10);
    }
}
