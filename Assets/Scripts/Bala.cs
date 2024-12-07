using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 2f; // Tiempo en segundos antes de que la bala se destruya

    private void Start()
    {
        // La bala se moverá hacia adelante en la dirección que apunta
        GetComponent<Rigidbody2D>().velocity = transform.right * velocidad;

        // Destruye la bala después de 'tiempoVida' segundos
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        // Destruye la bala al impactar con un objeto
        if (colision.gameObject.tag != "Jugador")
        {
            Destroy(gameObject);
        }
    }
}
