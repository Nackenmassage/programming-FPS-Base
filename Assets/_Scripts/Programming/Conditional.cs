using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditional : MonoBehaviour
{
    public int score;
    public bool checkpoint;
    public Funtions otherScript;

    void Update()
    {
        if (score == 50)
        {
            if (checkpoint)
            {
                otherScript.GetComponent<Funtions>().Death();
            }
        }

        else if (score == 40 && !checkpoint)
        {
            Debug.Log("score is 40");
        }

        else
        {
            Debug.Log("score is 0");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("score is 0");
        }
    }
}
