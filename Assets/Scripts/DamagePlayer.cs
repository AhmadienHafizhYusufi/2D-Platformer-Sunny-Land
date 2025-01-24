using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // FindFirstObjectByType<PlayerHealthController>().DealDamage();

            PlayerHealthController.instance.DealDamage();
        }
    }
}
