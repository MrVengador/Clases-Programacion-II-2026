using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private int currentCoins = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        Debug.Log("Monedas actuales: " + currentCoins);
    }
}