using UnityEngine;

public class EnemigoBulletBill : MonoBehaviour
{
    public float velocidad = 5f;
    public int direccionHorizontal = -1; // -1 = Izquierda, 1 = Derecha
    public float tiempoDeVida = 8f; // Se destruye automáticamente tras X segundos

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Se autodestruye tras unos segundos para no llenar la memoria si no choca con nada
        Destroy(gameObject, tiempoDeVida);
        ActualizarOrientacion();
    }

    private void Update()
    {
        // Movimiento rectilíneo constante
        transform.Translate(Vector2.right * (direccionHorizontal * velocidad * Time.deltaTime));
    }
    // Permite a la torreta cambiar la dirección de la bala al instanciarla
    public void SetDireccion(int nuevaDireccion)
    {
        direccionHorizontal = nuevaDireccion;
        ActualizarOrientacion();
    }

    private void ActualizarOrientacion()
    {
        if (spriteRenderer != null)
        {
            // Asumiendo que el gráfico original mira a la izquierda:
            spriteRenderer.flipX = (direccionHorizontal == 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Evita destruirse si toca a la misma torreta que lo disparó
        if (collision.gameObject.CompareTag("Torreta")) return;

        Debug.Log("Bullet Bill chocó contra: " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
