using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCollider : MonoBehaviour
{
    [SerializeField] Transform childWall;

    private void Start()
    {
        childWall = gameObject.transform.GetChild(0);
        Debug.Log(childWall);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(childWall.gameObject);
        }
    }
}
