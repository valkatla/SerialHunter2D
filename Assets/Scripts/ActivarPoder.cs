using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPoder : MonoBehaviour
{

    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject ataque;
    [SerializeField] private float tiempoDeCarga;
    [SerializeField] private float maximoCarga;


    void Update()
    {
        if (Input.GetButton("Ataque"))
        {
            if(tiempoDeCarga <= maximoCarga)
            {
                tiempoDeCarga += Time.deltaTime;
            }
        }
        if (Input.GetButtonUp("Ataque"))
        {
            Disparar((int)tiempoDeCarga);
            tiempoDeCarga = 0;
        }
    }
    private void Disparar(int tiempoCarga)
    {
        Vector3 crecer = new Vector3(tiempoCarga, tiempoCarga, 0);
        GameObject fantasma = Instantiate(ataque, controladorDisparo.position, controladorDisparo.rotation);
        fantasma.GetComponent<FantasmaScript>().AumentarDano(tiempoCarga);
        fantasma.transform.localScale += crecer;
    }

}
