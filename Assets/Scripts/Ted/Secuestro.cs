using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secuestro : MonoBehaviour
{
    private Animator animator;
    private AIAudioScript soundManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Secuestro");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            soundManager = FindObjectOfType<AIAudioScript>();
            soundManager.SeleccionAudio(0, 0.5f);
        }
    }
}
