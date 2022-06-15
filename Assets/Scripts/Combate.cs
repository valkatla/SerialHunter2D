using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combate : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;
    private ShalyMovement movimientoJugador;
    [SerializeField] private GameObject gameOver;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
        movimientoJugador = GetComponent<ShalyMovement>();
        animator = GetComponent<Animator>();
    }
    public  void TomarDano(int dano)
    {
        vida -= dano;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
            //Reiniciar();
            gameOver.SetActive(true);
        }
    }

    public void Curar(int curacion)
    {
        if ((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }
        barraDeVida.CambiarVidaActual(vida);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
