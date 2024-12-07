using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    public float Velocidad = 5f;
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
    }
}
