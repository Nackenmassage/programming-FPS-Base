using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrientationChange : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings
    {
        public float smallAngle = 90f;
        public float bigAngle = 180f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public KeyCode GRAVITY_LEFT = KeyCode.LeftArrow;
        public KeyCode GRAVITY_RIGHT = KeyCode.RightArrow;
        public KeyCode GRAVITY_UP = KeyCode.UpArrow;
    }

    public InputSettings inputSettings = new InputSettings();
    public MoveSettings moveSettings = new MoveSettings();

    private void FixedUpdate()
    {
        ChangeGravity();
    }

    private void ChangeGravity()
    {
        if (Input.GetKeyDown(inputSettings.GRAVITY_LEFT))
        {
            transform.Rotate(0, 0, moveSettings.smallAngle);
        }
        else if (Input.GetKeyDown(inputSettings.GRAVITY_RIGHT))
        {
            transform.Rotate(0, 0, -moveSettings.smallAngle);
        }
        else if (Input.GetKeyDown(inputSettings.GRAVITY_UP))
        {
            transform.Rotate(0, 0, moveSettings.bigAngle);
        }
    }
}
