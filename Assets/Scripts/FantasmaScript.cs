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
    public void AumentarDano(int danoExtra)
    {
        dano += danoExtra * dano;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ted"))
        {
            collision.GetComponent<TedCombate>().TomarDano(dano);
            Debug.Log("Daño: " + dano);
            Destroy(gameObject);
        }
    }
}
