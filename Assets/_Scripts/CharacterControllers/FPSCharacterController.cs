using System;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings
    {
        public float speed = 10f;
        public float jumpHeight = 3000f;
        public int jumpCount = 1;
        public float distToGround = 1.1f;
        public float distToWall = 1.1f;
        public LayerMask ground;
        public LayerMask wall;
    }
    [System.Serializable]
    public class InputSettings
    {
        public string FORWARD_AXIS = "Vertical";
        public string SIDE_AXIS = "Horizontal";
        public KeyCode JUMP_AXIS = KeyCode.Space;
        public KeyCode SPRINT_AXIS = KeyCode.LeftShift;
        public KeyCode ESCAPE_BUTTON = KeyCode.Escape;
    }
    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.5f;
    }

    public MoveSettings moveSettings = new MoveSettings();
    public InputSettings inputSettings = new InputSettings();
    public PhysSettings physSettings = new PhysSettings();

    Vector3 velocity = Vector3.zero;
    bool jumpInput, sprintInput;

    Rigidbody rBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        jumpInput =  sprintInput = false;

        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.Log("Needs Rigidbody");
        }
    }

    bool Grounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * moveSettings.distToGround, Color.red);
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(ray, 0.75f, moveSettings.distToGround, moveSettings.ground);
        //return Physics.Raycast(transform.position, Vector3.down * moveSettings.distToGround, moveSettings.ground);
    }

    bool WallHugging()
    {
        Debug.DrawRay(transform.position, Vector3.left * moveSettings.distToWall * 100, Color.green);
        Ray ray = new Ray(transform.position, Vector3.left);
        return Physics.SphereCast(ray, 0.5f, moveSettings.distToWall, moveSettings.wall);
    }

    void Update()
    {
        float translation = Input.GetAxis(inputSettings.FORWARD_AXIS) * moveSettings.speed;
        float strafe = Input.GetAxis(inputSettings.SIDE_AXIS) * moveSettings.speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown(inputSettings.ESCAPE_BUTTON))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Sprint();
        jumpInput = Input.GetKeyDown(inputSettings.JUMP_AXIS);
    }

    private void Sprint()
    {
        if (Input.GetKey(inputSettings.SPRINT_AXIS))
        {
            moveSettings.speed = 17f;
        }
        else
        {
            moveSettings.speed = 10f;
        }
    }

    void FixedUpdate()
    {
        Jump();
        //rBody.velocity = velocity;
        transform.Translate(velocity);
    }

    void Jump()
    {
        //if (Input.GetKeyDown(inputSettings.JUMP_AXIS) && moveSettings.jumpCount > 0)
        //{
        //    rBody.AddForce(Vector3.up * moveSettings.jumpHeight);
        //    moveSettings.jumpCount -= 1;
        //}
        if (jumpInput && moveSettings.jumpCount > 0)
        {
            StartJump();
        }
        else if(!Grounded() && WallHugging())
        {
            ResetVelocity();
            //WallRunning();
        }
        else if (!jumpInput && Grounded())
        {
            ResetVelocity();
        }
        else
        {
            Gravity();
        }
    }

    void StartJump()
    {
        velocity.y = moveSettings.jumpHeight;
        moveSettings.jumpCount -= 1;
    }

    void Gravity()
    {
        velocity.y -= physSettings.downAccel;
    }

    void ResetVelocity()
    {
        velocity.y = 0f;
        moveSettings.jumpCount = 1;
    }

//    void WallRunning()
//    {

//    }
}
