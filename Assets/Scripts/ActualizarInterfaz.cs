using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarInterfaz : MonoBehaviour
{
    public Text textoVida; // Referencia al texto de la vida
    public Text textoCoins; // Referencia al texto de las monedas
    private MovimientoJugador jugador; // Referencia al script del jugador

    private void Start()
    {
        // Encuentra al objeto jugador y su script MovimientoJugador
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoJugador>();
    }

    private void Update()
    {
        // Actualiza el texto de la vida y las monedas
        textoVida.text = "Vida: " + jugador.vida;
        textoCoins.text = "Monedas: " + jugador.monedas;
    }
}
