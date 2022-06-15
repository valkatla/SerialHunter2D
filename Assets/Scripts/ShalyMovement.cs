using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShalyMovement : MonoBehaviour
{
    //public GameObject Ataque;

    private Rigidbody2D rb2D;
    public bool sePuedeMover = true;

    [Header("Movimiento")]
    private float movHorizontal = 0f;
    [Range(0,0.3f)][SerializeField] private float suavizadoDeMovimiento;
    [SerializeField] private float velocidadDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;


    [Header("SaltoRegulable")]
    [Range(0, 1)][SerializeField] private float multiplicadorCancelarSalto;
    [SerializeField] private float multiplicadorGravedad;
    private float escalaGravedad;
    private bool botonSaltoArriba = true;

    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;

    private bool salto = false;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        escalaGravedad = rb2D.gravityScale;
    }   


    void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        if (Input.GetButton("Jump"))
        {
            salto = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            BotonSaltoArriba();
        }
       
    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        //mover
        if (sePuedeMover)
        {
            Mover(movHorizontal * Time.fixedDeltaTime, salto);
        }

        salto = false;
    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        { 
            Girar();
        }
        GetComponent<Animator>().SetBool("IsRunning", true);
        if (mover == 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (enSuelo && saltar && botonSaltoArriba)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
            GetComponent<Animator>().SetBool("IsOnTheGround", false);
            salto = false;
            botonSaltoArriba = false;
        }
        if (rb2D.velocity.y < 0 && !enSuelo)
        {
            rb2D.gravityScale = escalaGravedad * multiplicadorGravedad;
        }
        else
        {
            rb2D.gravityScale = escalaGravedad;
        }
    }

    public void Rebote()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        //Vector3 escala = transform.localScale;
        //escala.x *= -1;
        //transform.localScale = escala;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    private void BotonSaltoArriba()
    {
        if (rb2D.velocity.y > 0)
        {
            rb2D.AddForce(Vector2.down * rb2D.velocity.y * (1 - multiplicadorCancelarSalto), ForceMode2D.Impulse);
        }
        botonSaltoArriba = true;
        salto = false;
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.tag == "Ground")
        {
            GetComponent<Animator>().SetBool("IsOnTheGround", true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}