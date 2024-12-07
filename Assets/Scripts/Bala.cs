using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;

    private void Start()
    {
        // La bala se mover� hacia adelante en la direcci�n que apunta
        GetComponent<Rigidbody2D>().velocity = transform.right * velocidad;
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
