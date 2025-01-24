using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    
    public static PlayerHealthController instance;

    public int maxHealth, currentHealth;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {

    }

    public void DealDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
