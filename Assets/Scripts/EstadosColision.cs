using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosColision : MonoBehaviour
{
    private float tiempo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador Entro");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            tiempo += Time.deltaTime;
            Debug.Log("Jugador en bloque");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador Salio: " + tiempo);
            tiempo = 0;
        }
    }
}
