using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShot : MonoBehaviour
{

    public LayerMask layer;

    void Update()
    {
        GameObject[] hitpoints = GameObject.FindGameObjectsWithTag("Hit Point");
        if (hitpoints == null) return;
        foreach (GameObject hp in hitpoints) {
            if (Physics.CheckSphere(hp.transform.position, 0.5f, layer)) {
                Destroy(hp);
            }
        }
    }
}
