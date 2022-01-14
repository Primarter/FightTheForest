using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetShot : MonoBehaviour
{

    public int life = 100;
    public float maxSpeed = 5;
    public LayerMask layer;
    private NavMeshAgent agent;

    void Start() {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Die() {
        if (life <= 0) {
            Destroy(gameObject);
        }
    }

    private void Hit(int damage) {
        life -= damage;
        agent.speed = 0;
    }

    void Update()
    {
        Die();
    }

    void FixedUpdate() {
        if (agent.speed < maxSpeed) {
            agent.speed += 0.1f;
        }
        if (agent.speed > maxSpeed) {
            agent.speed = maxSpeed;
        }
    }
}
