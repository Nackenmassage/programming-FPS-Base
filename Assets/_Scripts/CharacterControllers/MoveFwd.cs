using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFwd : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * 12f;
    }
}
