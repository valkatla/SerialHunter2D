using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] int puntosCuracion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Combate>().Curar(puntosCuracion);
            Destroy(gameObject);
        }
    }
}
