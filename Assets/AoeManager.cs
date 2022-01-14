using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeManager : MonoBehaviour
{
    public LayerMask layerMask;

    void Update()
    {
        Object[] hitpoints = GameObject.FindGameObjectsWithTag("Hit Point");
        if (hitpoints == null) return;

        foreach (GameObject hp in hitpoints) {
            Collider[] hitColliders = Physics.OverlapSphere(hp.transform.position, 0.5f, layerMask);
            if (hitColliders == null) return;

            foreach (var hitCollider in hitColliders) {
                hitCollider.SendMessage("Hit", 10);
            }
            hp.SendMessage("Die");
        }
    }
}
