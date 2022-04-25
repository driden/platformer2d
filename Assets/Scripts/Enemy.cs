using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
