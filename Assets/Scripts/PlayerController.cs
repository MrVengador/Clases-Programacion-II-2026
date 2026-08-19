using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidad = 8f;
    [SerializeField] private float fuerzaSalto = 12f;

    [Header("Detección de Suelo")]
    [SerializeField] private Transform detectorSuelo;
    [SerializeField] private float radioDeteccion = 0.2f;
    [SerializeField] private LayerMask capaSuelo;

    [Header("Detección de Suelo")]
    [SerializeField] private Animator controladorAnimaciones;

    // Componentes y variables privadas
    private Rigidbody2D rb;
    private float movimientoHorizontal;
    private bool enElSuelo;
    private bool mirandoDerecha = true;

    [SerializeField] private int currentCoins=0;

    private void Awake()
    {
        //Asigno el Rigidbody del objeto, recordarlo.
        rb = GetComponent<Rigidbody2D>();
        controladorAnimaciones = GetComponent<Animator>();
    }

    private void Update()
    {
        //1 Obtener entrada del jugador
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        //2 Verificar si está tocando el suelo
        enElSuelo = Physics2D.OverlapCircle(detectorSuelo.position, radioDeteccion, capaSuelo);

        //3 Detectar botón de salto
        if (Input.GetButtonDown("Jump") && enElSuelo)
        {
            Salto();
        }

        //4 Voltear el personaje según la dirección
        GirarPersonaje();

        //5 Funcion para animación
        ControlarAnimaciones();

        if(currentCoins>=10)
        {
            Debug.Log("GAME OVER");
        }
    }

    private void FixedUpdate()
    {
        // Mover al personaje usando físicas
        Movimiento();
    }

    // --- FUNCIONES PRINCIPALES ---

    private void Movimiento()
    {
        // Mantiene la velocidad actual en Y para que la gravedad actúe con normalidad
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
    }

    private void Salto()
    {
        // Aplica una fuerza vertical instantánea
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }

//Función para poder girar el sprite hacia donde se mueve
    private void GirarPersonaje() 
    {
        // Si el jugador se mueve hacia la izquierda y mira a la derecha (o viceversa), voltear escala en X
        if ((movimientoHorizontal > 0 && !mirandoDerecha) || (movimientoHorizontal < 0 && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }

    public void AddCoin(int cantidad)
    {
        currentCoins+=cantidad;
        Debug.Log($"El jugador ahora tiene {currentCoins} monedas en su poder.");
    }


    private void ControlarAnimaciones()
    {
        if(movimientoHorizontal!=0) //Se mueve, entonces aniumacion de caminar
        {
            controladorAnimaciones.SetBool("Mov",true);
        }
        else // Si no se mueve, normal
        {
            controladorAnimaciones.SetBool("Mov",false);
        }
    }

    // Visualizar el rango de detección del suelo en el editor, no en el juego.
    private void OnDrawGizmosSelected()
    {
        if (detectorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectorSuelo.position, radioDeteccion);
        }
    }
}