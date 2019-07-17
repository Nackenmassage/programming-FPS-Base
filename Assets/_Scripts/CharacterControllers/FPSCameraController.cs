using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject character;

    [Header("Camera Settings")]
    public float sensitivity = 3f;
    public float smoothing = 2f;
    private float maxRot = 90;
    private float minRot = -90;

    private void Start()
    {
        character = this.transform.parent.gameObject;
    }

    private void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook += md;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Debug.DrawRay(character.transform.position, character.transform.up * 7f);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        LimitRotation();
    }

    private void LimitRotation()
    {
        if (mouseLook.y > maxRot)
        {
            mouseLook.y = maxRot;
        }
        else if (mouseLook.y < minRot)
        {
            mouseLook.y = minRot;
        }
    }

    public void CameraShake()
    {
        // go up and down when shot
    }
}
