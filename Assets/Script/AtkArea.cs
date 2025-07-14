using UnityEngine;

public class AtkArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            // other.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }
}
