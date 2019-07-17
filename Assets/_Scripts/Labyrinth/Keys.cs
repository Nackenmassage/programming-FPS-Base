using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public static int objects = 0;

    private void Awake()
    {
        objects++;
        Debug.Log(objects);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objects--;
        }

        transform.gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
        DestroySelf();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
