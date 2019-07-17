using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTry : MonoBehaviour
{
    private IEnumerator coroutine;

    private void Start()
    {
        StartCoroutine(WaitAndRotate());
    }

    private IEnumerator WaitAndRotate()
    {
        this.transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);

        yield return new WaitForSeconds(5);

        this.transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);

    }

    //private bool rotDirRight = true;

    //private void Update()
    //{
    //    if(rotDirRight == true)
    //    {
    //        this.transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    //        rotDirRight = false;
    //    }
    //    else
    //    {
    //        this.transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
    //        rotDirRight = true;
    //    }
    //}
}
