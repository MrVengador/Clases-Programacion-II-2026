using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isRunning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetRunning(bool running) // Recibo un booleano que indica si el jugador está corriendo o no.
    {
        isRunning = running;
    }

    public void Move(float direction)
    {
        float currentSpeed = isRunning ? runSpeed : speed; // Si corre es 7, si no 5.

        rb.linearVelocity = new Vector2(direction * currentSpeed, rb.linearVelocity.y);
        FlipSprite(direction);
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void FlipSprite(float direction)
    {
        if (direction > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (direction < 0) transform.localScale = new Vector3(-1, 1, 1);
    }


}