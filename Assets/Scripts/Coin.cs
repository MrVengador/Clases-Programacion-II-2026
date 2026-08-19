using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("¡Moneda recolectada!");
            
            PlayerController player = collision.GetComponent<PlayerController>();

            if(player!=null)
            {
                player.AddCoin(1);
            }
         
            Destroy(gameObject);
        }
    }
}
