using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("¡Moneda recolectada!");

            PlayerStats player = collision.GetComponent<PlayerStats>();

            if (player != null)
            {
                player.AddCoins(1);
            }

            Destroy(gameObject);
        }
    }
}
