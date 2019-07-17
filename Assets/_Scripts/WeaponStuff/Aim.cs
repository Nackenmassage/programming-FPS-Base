using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector3 aimDownSight;
    public Vector3 hipFire;

    public float aimSpeed = 10f;
    float max = 120f;
    float min = 20f;

    private float m_FieldOfView;

    private void Start()
    {
        m_FieldOfView = 60f;
    }

    private void Update()
    {
        Aiming();
        //m_FieldOfView = Camera.main.fieldOfView;
    }

    private void Aiming()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSight, aimSpeed * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = hipFire;
        }
    }

    private void OnGUI()
    {

        if (Input.GetMouseButton(1))
        {

        }
        else if (Input.GetMouseButtonUp(1))
        {

        }
    }
}
