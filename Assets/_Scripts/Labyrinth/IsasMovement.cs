using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IsasMovement : MonoBehaviour
{
    Vector3 startingPos;
    Quaternion startingRot;

    NavMeshAgent agent;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private void Start()
    {
        startingPos = gameObject.transform.position;
        startingRot = gameObject.transform.rotation;
        //Vector3 startingPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Rotate(0, rotation, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            agent.enabled = false;
            transform.position = startingPos;
            transform.rotation = startingRot;
            agent.enabled = true;
        }
    }
}
