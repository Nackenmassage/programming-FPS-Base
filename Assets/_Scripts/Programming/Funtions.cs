using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funtions : MonoBehaviour
{
    public int health;

    void Update()
    {

    }

    public void Death()
    {
        Debug.Log("I am here");
    }

    void GodMode()
    {
        Death();
    }
}
