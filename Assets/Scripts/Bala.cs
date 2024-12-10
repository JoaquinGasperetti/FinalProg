using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 2f; // Tiempo en segundos antes de que la bala se destruya

    private void Start()
    {
        // La bala se mover� hacia adelante en la direcci�n que apunta
        GetComponent<Rigidbody2D>().velocity = transform.right * velocidad;

        // Destruye la bala despu�s de 'tiempoVida' segundos
        Destroy(gameObject, tiempoVida);
    }
}
