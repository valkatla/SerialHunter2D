using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dano;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ted"))
        {
            collision.GetComponent<Ted>().TomarDano(dano);
            Destroy(gameObject);
        }
    }
}
