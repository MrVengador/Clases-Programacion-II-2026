using NUnit.Framework;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Lee la velocidad real del Rigidbody para saber si está corriendo
        bool isMov = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 5f; // Considera que está corriendo si la velocidad es mayor a 5

        //Seteo las variables de animator Player
        anim.SetBool("isMov", isMov);
        anim.SetBool("isRun", isRunning);
    }

    public void TriggerShoot()
    {
        anim.SetTrigger("Shoot");
    }


}