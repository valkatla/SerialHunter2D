using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedMuerte : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida;

    void Start()
    {
       // transform.Translate(3f * Time.deltaTime, 0f, 0f); transform.Translate(3f * Time.deltaTime, 0f, 0f);
        Destroy(gameObject, tiempoDeVida);
    }

}
