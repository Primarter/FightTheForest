using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetShot : MonoBehaviour
{

    public int life;
    public LayerMask layer;
    public GameObject self;
    public NavMeshAgent agent;

    void Start() {
        agent = self.GetComponent<NavMeshAgent>();
    }

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
                agent.speed = 0;
            }
        }
    }

    void Update()
    {
        Hit();
        Die();
    }

    void FixedUpdate() {
        if (agent.speed < 5) {
            agent.speed += 0.1f;
        }
        if (agent.speed > 5) {
            agent.speed = 5;
        }
    }
}
