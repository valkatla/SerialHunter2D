using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] int maximoVida;
    [SerializeField] BarraDeVida barraDeVida;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }
    public  void TomarDano(int dano)
    {
        vida -= dano;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
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
    }
}
