using UnityEngine;

public class CylinderController : MonoBehaviour
{

    [SerializeField]
    float damage;

    GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttackPlayer();
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
