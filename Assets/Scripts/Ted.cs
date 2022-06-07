using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ted : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject efectoMuerte;
    public float tiempoMuerte;
   
    public void TomarDano (float dano)
    {
        vida -= dano;
        if (vida <=0)
        {
           Muerte();
        }
    }
    private void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        //GetComponent<Animator>().SetBool("IsAlive", false);
        Destroy(gameObject, tiempoMuerte);
    }
}
