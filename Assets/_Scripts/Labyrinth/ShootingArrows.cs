using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArrows : MonoBehaviour
{
    public Rigidbody arrows;
    private float timer = 1f;
    public float speed = 10f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Rigidbody clone;

            clone = Instantiate(arrows, transform.position, transform.rotation);

            clone.velocity = transform.TransformDirection(Vector3.forward * speed);

            timer = 1f;
        }
    }
}
