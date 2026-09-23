using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    EnemyHealth health;
    NavMeshAgent agent;
    Transform player;
    PlayerHealth pHealth;

    float updateTimer = 0.1f;
    float updateClock = 1;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
        pHealth = player.GetComponent<PlayerHealth>();
    }

    void Update ()
    {
        if (updateClock > updateTimer)
        {
            if (health.currentHealth > 0 && pHealth.currentHealth > 0)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.enabled = false;
            }

            updateClock = 0;
        }
        else updateClock += Time.deltaTime;
    }
}
