using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
     public float velX;
     float velY=0;
     Rigidbody2D rigidBody;
   // [SerializeField] private float velocidad;
    [SerializeField] private float dano;
    private Vector2 direction;

     void Start(){
         rigidBody = GetComponent<Rigidbody2D>();
     }

    void Update(){
         rigidBody.velocity = new Vector2(velX,velY);
        //transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ted"))
        {
            other.GetComponent<Ted>().TomarDano(dano);
            Destroy(gameObject);
        }
    }
}
