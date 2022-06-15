using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPoder : MonoBehaviour
{

    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject ataque;
    [SerializeField] private float tiempoDeCarga;
    [SerializeField] private float maximoCarga;
    [SerializeField] private float tiempoEntreDisparos;
    private float tiempoSiguienteDisparo;

    void Update()
    {
        //if (Input.GetButtonDown("Ataque"))
        //{
        //    if(tiempoDeCarga <= maximoCarga)
        //    {
        //        tiempoDeCarga += Time.deltaTime;
        //    }
        //}
        //if (Input.GetButtonUp("Ataque"))
        //{
        //    Disparar((int)tiempoDeCarga);
        //    tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        //    tiempoDeCarga = 0;
        //}
        if(Input.GetButton("Ataque") && Time.time >= tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }
    private void Disparar()
    {
        //(int tiempoCarga)
        //Vector3 crecer = new Vector3(tiempoCarga, tiempoCarga, 0);
        GameObject fantasma = Instantiate(ataque, controladorDisparo.position, controladorDisparo.rotation);
        //fantasma.GetComponent<FantasmaScript>().AumentarDano(tiempoCarga);
        //fantasma.transform.localScale += crecer;
    }

}
