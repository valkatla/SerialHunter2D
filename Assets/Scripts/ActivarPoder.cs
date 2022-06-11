using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPoder : MonoBehaviour
{

    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject ataque;



    void Update()
    {
        if (Input.GetButtonDown("Ataque"))
        {
            Disparar();
        }
    }
    private void Disparar()
    {
        Instantiate(ataque, controladorDisparo.position, controladorDisparo.rotation);
    }

}
