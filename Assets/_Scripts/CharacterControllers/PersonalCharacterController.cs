using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalCharacterController : MonoBehaviour
{
    public int jumpCount = 2;
    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 12f;
        public float rotationVel = 100f;
        public float jumpVel = 25f;
        public float distToGround = 0.1f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();


    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;
    bool jumpInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    bool Grounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * moveSettings.distToGround, Color.red);
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(ray, 0.75f, moveSettings.distToGround, moveSettings.ground);
    }

    private void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }

        else
        {
            Debug.Log("No Rigidbody here");
        }

        forwardInput = turnInput = 0;
        jumpInput = false;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);//interpolated
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS);//interpolated
        //jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);//non-interpolated
        jumpInput = Input.GetKeyDown("space");
    }

    private void Update()
    {
        GetInput();
        Turn();
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
        rBody.velocity = transform.TransformDirection(velocity);

    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay)
        {
            //move
            //rBody.velocity = transform.forward * forwardInput * moveSettings.forwardVel;
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else
        {
            //zeroVelocity
            //rBody.velocity = Vector3.zero;
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSettings.rotationVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if (jumpInput && jumpCount > 0)
        {
            StartJump();
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

    private void Gravity()
    {
        velocity.y -= physSettings.downAccel;
    }

    void StartJump()
    {
        velocity.y = moveSettings.jumpVel;
        jumpCount -= 1;
    }

    private void ResetVelocity()
    {
        velocity.y = 0;
        jumpCount = 2;
    }
}
