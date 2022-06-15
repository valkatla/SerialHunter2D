using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoDano : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                if(collision.GetContact(0).normal.y<= -0.9)
                {
                animator.SetTrigger("Golpe");
                collision.gameObject.GetComponent<ShalyMovement>().Rebote();
                }
        }
    }
    public void Golpe()
    {
        Instantiate(efecto, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
