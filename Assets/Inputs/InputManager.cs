using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static Vector2 Movimiento;
    private InputAction AccionMovmiento;
    private PlayerInput InputJugador;


    private void Awake()
    {
        InputJugador = GetComponent<PlayerInput>();
        AccionMovmiento = InputJugador.actions["Mover"];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento = AccionMovmiento.ReadValue<Vector2>();
    }
}
