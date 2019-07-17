using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Keys.objects <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need to collect all 3 Keys!");
        }
    }
}
