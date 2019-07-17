using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventGameObject : MonoBehaviour
{
    public GameObject cubeObject;

    private GameObject cubeObject2;

    void Start()
    {
        cubeObject2 = GameObject.FindGameObjectWithTag("Cube");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the GameObject active
            cubeObject.SetActive(false);
            cubeObject2.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
