using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShot : MonoBehaviour
{

    public int life;
    public LayerMask layer;
    public GameObject self;

    private void Die() {
        if (life <= 0) {
            Destroy(self);
        }
    }

    private void Hit() {
        Object[] hitpoints = GameObject.FindGameObjectsWithTag("Hit Point");
        if (hitpoints == null) return;

        foreach (GameObject hp in hitpoints) {
            if (Physics.CheckSphere(hp.transform.position, 0.5f, layer)) {
                Destroy(hp);
                life -= 10;
            }
        }
    }

    void Update()
    {
        Hit();
        Die();
    }
}
