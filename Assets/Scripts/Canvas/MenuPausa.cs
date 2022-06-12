using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public void Pausa()
    {
        Time.timeScale =0f;
        menuPausa.SetActive(true);
        botonPausa.SetActive(false);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
    }
}
