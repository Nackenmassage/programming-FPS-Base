using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyTypes : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("TestButton"))
        {
            Debug.Log("Do something here");
        }

        if (Input.GetButtonDown("AnotherButton"))
        {
            Debug.Log("Do something else");
        }
    }
}
