using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private float damage;

    void Start()
    {
        //healthManager = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<HealthManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthManager.health -= damage;
            //healthManager.UpdateHealth();
        }
    }
}
