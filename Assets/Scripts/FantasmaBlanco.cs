using UnityEngine;

public class FantasmaBlanco : MonoBehaviour
{
    public float velocidad = 3f; // Velocidad de movimiento del fantasma
    public int dano = 10; // Cantidad de vida que quita al jugador
    public GameObject coinPrefab; // Prefab de la moneda

    private Transform jugador; // Referencia al transform del jugador
    private MovimientoJugador scriptJugador; // Referencia al script de MovimientoJugador

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        scriptJugador = jugador.GetComponent<MovimientoJugador>();
    }

    private void Update()
    {
        PerseguirJugador();
    }

    private void PerseguirJugador()
    {
        // Movimiento del fantasma hacia el jugador
        Vector2 direccion = (jugador.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.tag == "Jugador")
        {
            // Quita vida al jugador
            scriptJugador.vida -= dano;
            Destroy(gameObject); // Destruye el fantasma después de golpear al jugador
        }

        if (colision.gameObject.tag == "Bala")
        {
            // Instancia una moneda en la posición del fantasma y destruye el fantasma
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
