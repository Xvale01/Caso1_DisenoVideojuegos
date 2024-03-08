using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthPlayerController : MonoBehaviour
{
    [SerializeField]
    Image lifeBar;

    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        lifeBar.fillAmount = _currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= Mathf.Abs(damage);

        if (_currentHealth <= 0.0F)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
