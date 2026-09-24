using UnityEngine;

public class EnemyPersecutor : MonoBehaviour
{
    public float velocidad = 1.5f;
    [HideInInspector] public Transform jugador;
    [SerializeField] private EnemyBase enemyBase;
    [SerializeField] private bool isHorizontal = true; //Si flota o no

    private void Awake()
    {
        enemyBase = GetComponent<EnemyBase>();
    }

    private void Update()
    {
        if (jugador != null)
        {
            if (isHorizontal)
            {
                // Solo se mueve en el eje X
                transform.position = Vector2.MoveTowards(
                    new Vector2(transform.position.x, transform.position.y),
                    new Vector2(jugador.position.x, transform.position.y),
                    velocidad * Time.deltaTime
                );
            }
            else
            {
                // Se mueve en ambos ejes
                transform.position = Vector2.MoveTowards(
                    transform.position, // Posición actual del enemigo
                    jugador.position, // Posición del jugador
                    velocidad * Time.deltaTime // Velocidad de persecución
                );
            }
        }
    }
    public void AsignarObjetivo(Transform nuevoObjetivo)
    {
        if (jugador == null)
        {
            jugador = nuevoObjetivo;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHorizontal) return; //Si es horizontal, no es un fantasma

        if (collision.CompareTag("Player")) //Daño al jugador como fantasma
        {
            Debug.Log("Daño al jugador " + enemyBase.damage);
        }
    }
}


