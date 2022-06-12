using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDano : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDano;
    private float tiempoSiguienteDano;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiempoSiguienteDano -= Time.deltaTime;
            if (tiempoSiguienteDano <= 0)
            {
                collision.GetComponent<Combate>().TomarDano(5);
                tiempoSiguienteDano = tiempoEntreDano;
            }
        }
    }
}
