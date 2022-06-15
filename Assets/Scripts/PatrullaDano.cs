using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaDano : MonoBehaviour
{
   [SerializeField] private float velocidad;
   [SerializeField] private Transform controladorsuelo;
   [SerializeField] private float distancia;
   [SerializeField] private bool moviendoDerecha;
    [SerializeField] private int dano;
    //[SerializeField] private float tiempoEntreDano;
    private float tiempoSiguienteDano;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        RaycastHit2D informacionSuelo=Physics2D.Raycast(controladorsuelo.position, Vector2.down,distancia);
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if (informacionSuelo == false)
        {
            Girar();
        }
    }
    private void Girar(){
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+180,0);
        velocidad*= -1;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorsuelo.transform.position, controladorsuelo.transform.position+Vector3.down*distancia);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            tiempoSiguienteDano -= Time.deltaTime;
            if (tiempoSiguienteDano <= 0)
            {
                collision.collider.GetComponent<Combate>().TomarDano(dano);
                //tiempoSiguienteDano = tiempoEntreDano;
            }
        }
    }
}
