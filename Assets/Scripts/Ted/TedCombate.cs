using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedCombate : MonoBehaviour
{
    private Animator animator;
    private AIAudioScript soundManager;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;
    public float tiempoMuerte;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private int danoAtaque;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }
    public void TomarDano(float dano)
    {
        vida -= dano;
        soundManager = FindObjectOfType<AIAudioScript>();
        soundManager.SeleccionAudio(1, 1f);
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Muerte();
        }
    }
    private void Muerte()
    {
            animator.SetTrigger("Muerte");
        soundManager = FindObjectOfType<AIAudioScript>();
        soundManager.SeleccionAudio(2, 1f);
        Destroy(gameObject, tiempoMuerte);
    }
    public void MirarJugador()
    {
        if((jugador.position.x>transform.position.x&& !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D collision in objetos)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Combate>().TomarDano(danoAtaque);
                soundManager = FindObjectOfType<AIAudioScript>();
                soundManager.SeleccionAudio(0, 1f);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
