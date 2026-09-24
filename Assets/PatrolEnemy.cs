using UnityEngine;

// Volvemos a heredar de MonoBehaviour. Un script totalmente independiente.
public class PatrolEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 3f;

    [SerializeField] private Rigidbody2D rb;
    private bool movingRight = true;
    private Vector2 startPosition;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        startPosition = transform.position;
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(movingRight ? speed : -speed, rb.linearVelocity.y);

        // Voltea si llega al límite derecho
        if (movingRight && transform.position.x >= startPosition.x + patrolDistance)
        {
            Flip();
        }
        // Voltea si llega al límite izquierdo
        else if (!movingRight && transform.position.x <= startPosition.x - patrolDistance)
        {
            Flip();
        }
    }

    // Un OnCollisionEnter2D privado y normal. Sin "override" ni "base".
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con una pared (impacto horizontal), se voltea
        if (collision.contacts.Length > 0 && Mathf.Abs(collision.contacts[0].normal.x) > 0.5f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}