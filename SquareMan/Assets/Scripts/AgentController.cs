using UnityEngine;
using UnityEngine.AI;
public class AgentController : MonoBehaviour
{
    [SerializeField]
    float minDistance;

    [SerializeField]
    float damage;

    [SerializeField]
    float attackCooldown;

    float lastAttackTime;
    NavMeshAgent navAgent;
    GameObject target;


    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        lastAttackTime = -attackCooldown;
    }

    private void Update()
    {
        if (target != null)
        {
            navAgent.SetDestination(target.transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= minDistance && Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    public void AttackPlayer()
    {
        HealthPlayerController playerHealth = target.GetComponent<HealthPlayerController>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
