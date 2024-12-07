using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static Vector2 Movimiento;
    public static bool Disparar;
    private InputAction AccionMovmiento;
    private InputAction AccionDisparar;
    private PlayerInput InputJugador;

    private void Awake()
    {
        InputJugador = GetComponent<PlayerInput>();
        AccionMovmiento = InputJugador.actions["Mover"];
        AccionDisparar = InputJugador.actions["Disparar"];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento = AccionMovmiento.ReadValue<Vector2>();
        Disparar = AccionDisparar.WasPressedThisFrame();
    }
}
