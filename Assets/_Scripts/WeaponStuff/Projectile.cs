using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionEffect;

    private float timer = 2f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject effectIns = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}
