using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float Velocidad = 5f;
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeSalida; // Punto desde donde se disparar� la bala
    public Transform camara; // Transform de la c�mara

    private Vector2 movimiento;
    private Rigidbody2D rb;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimiento.Set(InputManager.Movimiento.x, InputManager.Movimiento.y);

        rb.velocity = movimiento * Velocidad;

        animator.SetFloat(horizontal, movimiento.x);
        animator.SetFloat(vertical, movimiento.y);

        if (InputManager.Disparar)
        {
            Disparar();
        }

        SeguirJugador(); // Llama a la funci�n para seguir al jugador
    }

    private void Disparar()
    {
        if (movimiento != Vector2.zero)
        {
            // Calcula el �ngulo en funci�n de la direcci�n del movimiento
            float angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            Quaternion rotacionDisparo = Quaternion.Euler(new Vector3(0, 0, angulo));

            // Instancia el prefab de la bala
            GameObject bala = Instantiate(balaPrefab, puntoDeSalida.position, rotacionDisparo);
            bala.GetComponent<Rigidbody2D>().velocity = movimiento.normalized * 10f; // Ajusta la velocidad de la bala
        }
    }

    private void SeguirJugador()
    {
        // Ajusta la posici�n de la c�mara para seguir al jugador
        if (camara != null)
        {
            camara.position = new Vector3(transform.position.x, transform.position.y, camara.position.z);
        }
    }
}
