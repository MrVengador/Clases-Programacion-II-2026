using UnityEngine;

public class EnemyTorreta : MonoBehaviour
{
    [Header("Configuración del Disparo")]
    public GameObject bulletBillPrefab; // Arrastra el Prefab del Bullet Bill aquí
    public Transform puntoDeDisparo;    // Objeto vacío (Hijo) desde donde sale la bala
    public float cadenciaDisparo = 2.5f; // Tiempo en segundos entre cada disparo
    public int direccionDisparo = -1;    // -1 = Izquierda, 1 = Derecha

    [Header("Detección de Jugador (Opcional)")]
    public bool soloDispararSiJugadorCerca = true;
    public float rangoDeteccion = 10f;
    public LayerMask capaJugador;

    public Animator anim; //animator para disparar

    private void Awake()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (soloDispararSiJugadorCerca && !JugadorEstaEnRango())
        {
            return; // No hay jugador cerca, no disparamos
        }
        if (soloDispararSiJugadorCerca)
        {
            anim.SetTrigger("Shoot");
        }
        else
        {
            anim.SetTrigger("Shoot");
        }
    }
    private void Disparar()
    {
        if (bulletBillPrefab == null)
        {
            Debug.LogWarning("¡Falta asignar el Prefab del Bullet Bill en la torreta!");
            return;
        }

        // Si no asignaste un punto de disparo, usa la posición de la torreta
        Vector3 posicionSpawn = puntoDeDisparo != null ? puntoDeDisparo.position : transform.position;

        // Instancia la bala
        GameObject bala = Instantiate(bulletBillPrefab, posicionSpawn, Quaternion.identity);

        // Configura la dirección en el script de la bala instanciada
        EnemigoBulletBill bulletScript = bala.GetComponent<EnemigoBulletBill>();
        if (bulletScript != null)
        {
            bulletScript.SetDireccion(direccionDisparo);
        }
    }

    private bool JugadorEstaEnRango()
    {
        // Detecta si hay un collider del Jugador dentro del rango de visión
        Collider2D jugador = Physics2D.OverlapCircle(transform.position, rangoDeteccion, capaJugador);
        return jugador != null;
    }

    // Dibuja el radio de detección en el Editor para facilitar la vista
    private void OnDrawGizmosSelected()
    {
        if (soloDispararSiJugadorCerca)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        }
    }
}
