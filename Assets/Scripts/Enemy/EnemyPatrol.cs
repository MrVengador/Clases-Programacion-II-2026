using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidad = 2f;
    public float distance = 5f;

    private Vector2 initialPos;
    private int direccion = -1; // -1 = Izquierda, 1 = Derecha

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        // Movimiento en el eje X
        transform.Translate(Vector2.right * (direccion * velocidad * Time.deltaTime));

        // Control de límites desde la posición inicial para evitar el fallo de parpadeo
        if (direccion == -1 && transform.position.x <= initialPos.x - distance)
        {
            direccion = 1;
        }
        else if (direccion == 1 && transform.position.x >= initialPos.x + distance)
        {
            direccion = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) //Si choco con algo que no sea el jugador, cambio de dirección.
        {
            direccion *= -1; // Cambio de dirección
        }
    }
}
