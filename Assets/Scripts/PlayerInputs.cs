using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerAttack attack;
    [SerializeField] private PlayerAnimation animScript;

    void Start()
    {
        // Conecta este script con los demás que están en el mismo objeto
        if (controller == null)
        {
            controller = GetComponent<PlayerController>();
        }
        if (attack == null)
        {
            attack = GetComponent<PlayerAttack>();
        }
        if (animScript == null)
        {
            animScript = GetComponent<PlayerAnimation>();
        }
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        controller.Move(moveInput);

        // Salto
        if (Input.GetButtonDown("Jump"))
        {
            controller.Jump();
        }

        // Disparo
        if (Input.GetMouseButtonDown(0))
        {
            //attack.Shoot();
            animScript.TriggerShoot();
        }
    }
}