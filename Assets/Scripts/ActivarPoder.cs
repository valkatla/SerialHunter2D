using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPoder : MonoBehaviour
{
    public GameObject poder;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }    
    }

    void fire()
    {
        Instantiate(poder, transform.position, Quaternion.identity);
    }
}
