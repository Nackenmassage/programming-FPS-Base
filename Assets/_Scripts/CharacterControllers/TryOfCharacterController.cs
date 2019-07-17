using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryOfCharacterController : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 20f;
        public float turnVel = 100f;
        public float jumpVel = 5f;
        public float distToGround = 0.1f;
        public LayerMask ground;
        //public float fallMultiplier = 2.5f;
        //public float lowJumpMultiplier = 2f;
    }
    [System.Serializable]
    public class InputSettings
    {
        public string FORWARD_AXIS = "Vertical";
        public string SPRINT_AXIS = "Sprint";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
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
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, sprintInput;
    bool jumpInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    bool Grounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * moveSettings.distToGround, Color.green);
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(ray, 1.25f, moveSettings.distToGround, moveSettings.ground);
    }

    private void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }

        forwardInput = turnInput = sprintInput = 0;
        jumpInput = false;
    }

    private void Update()
    {
        GetInput();
        Turn();
        //JumpModifier();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        rBody.velocity = transform.TransformDirection(velocity);
    }

    private void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
        sprintInput = Input.GetAxis(inputSettings.SPRINT_AXIS);
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
        //jumpInput = Input.GetAxis(inputSettings.JUMP_AXIS);
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

    private void Move()
    {
        if (Mathf.Abs(sprintInput) > 0)
        {
            moveSettings.forwardVel = 40f;
        }
        else
        {
            moveSettings.forwardVel = 20f;
        }

        if (Mathf.Abs(forwardInput) > 0)
        {
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else
        {
            velocity.z = 0;
        }
    }

    private void Turn()
    {
        if (Mathf.Abs(turnInput) > 0)
        {
            targetRotation *= Quaternion.AngleAxis(moveSettings.turnVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    private void Jump()
    {
            //rBody.AddForce(0, moveSettings.jumpVel, 0, ForceMode.Impulse);
        if (jumpInput == true)
        {
            StartJump();
            Debug.Log("Jumping");
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

    private void StartJump()
    {
        velocity.y = moveSettings.jumpVel;
    }

    private void ResetVelocity()
    {
        velocity.y = 0;
    }

    private void Gravity()
    {
        velocity.y -= physSettings.downAccel;
    }

    //private void JumpModifier()
    //{
    //    if (rBody.velocity.y < 0)
    //    {
    //        rBody.velocity += Vector3.up * Physics.gravity.y * (moveSettings.fallMultiplier - 1) * Time.deltaTime;
    //    }
    //    else if (rBody.velocity.y > 0 && jumpInput <= 0)
    //    {
    //        rBody.velocity += Vector3.up * Physics.gravity.y * (moveSettings.lowJumpMultiplier - 1) * Time.deltaTime;
    //    }
    //}
}
