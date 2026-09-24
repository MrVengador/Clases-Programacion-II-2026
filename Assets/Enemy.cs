using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool canBeStomped = true; // Activa el comportamiento "Goomba"

    // Lo volvemos un método privado normal. Sin "virtual" ni "protected".
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Compara las posiciones Y para saber si el jugador está por encima
            if (canBeStomped && collision.transform.position.y > transform.position.y + 0.5f)
            {
                Die();
            }
            else
            {
                DamagePlayer();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void DamagePlayer()
    {
        Debug.Log("El jugador recibió daño.");
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja un gizmo para mostrar el área de colisión del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider2D>().bounds.size);
    }
}