using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    public float Velocidad = 5f;
    public int vida = 100; // Vida del jugador
    public int monedas = 0; // Cantidad de monedas del jugador
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeSalida; // Punto desde donde se disparará la bala
    public Transform camara; // Transform de la cámara
    public Text textoVida; // Referencia al texto de la vida
    public Text textoCoins; // Referencia al texto de las monedas

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

        SeguirJugador(); // Llama a la función para seguir al jugador
        ActualizarInterfaz(); // Llama a la función para actualizar la interfaz
    }

    private void Disparar()
    {
        if (movimiento != Vector2.zero)
        {
            // Calcula el ángulo en función de la dirección del movimiento
            float angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            Quaternion rotacionDisparo = Quaternion.Euler(new Vector3(0, 0, angulo));

            // Instancia el prefab de la bala
            GameObject bala = Instantiate(balaPrefab, puntoDeSalida.position, rotacionDisparo);
            bala.GetComponent<Rigidbody2D>().velocity = movimiento.normalized * 10f; // Ajusta la velocidad de la bala según sea necesario
        }
    }

    private void SeguirJugador()
    {
        // Ajusta la posición de la cámara para seguir al jugador
        if (camara != null)
        {
            camara.position = new Vector3(transform.position.x, transform.position.y, camara.position.z);
        }
    }

    private void ActualizarInterfaz()
    {
        // Actualiza el texto de la vida y las monedas
        textoVida.text = "Vida: " + vida;
        textoCoins.text = "Monedas: " + monedas;
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.tag == "FantasmaBlanco")
        {
            // Quita vida al jugador
            vida -= colision.gameObject.GetComponent<FantasmaBlanco>().dano;
        }

        if (colision.gameObject.tag == "Moneda")
        {
            // Incrementa la cantidad de monedas
            monedas += 1;
            Destroy(colision.gameObject); // Destruye la moneda después de recogerla
        }
    }
}
