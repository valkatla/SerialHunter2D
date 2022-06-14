using System.Collections;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ayura;
    private bool estaEnRango;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador Entró");
            ayura.SetActive(true);
            estaEnRango = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador Salió");
            ayura.SetActive(false);
            estaEnRango = false;
        }
    }
}
