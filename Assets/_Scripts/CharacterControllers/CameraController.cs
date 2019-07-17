using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0f, 6f, -8f);
    public float xTilt = 10f;

    Vector3 destination = Vector3.zero;
    PersonalCharacterController charController;
    float rotateVel = 0;

    void Start()
    {
        SetCameraTarget(target);
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if(target != null)
        {
            if (target.GetComponent<PersonalCharacterController>())
            {
                charController = target.GetComponent<PersonalCharacterController>();
            }

            else
            {
                Debug.Log("The Camera´s Target needs a CharacterController");
            }
        }

        else
        {
            Debug.Log("Add CameraTarget");
        }
    }

    void LateUpdate()
    {
        //moving
        MoveToTarget();
        //rotating
        LookAtTarget();
    }

    void MoveToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }
}
    