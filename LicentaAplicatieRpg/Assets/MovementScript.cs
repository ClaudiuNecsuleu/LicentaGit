using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour
{
    public float speedCharacter = 1;
    public float speedRotation = 20;

    float verticalLookRotation;

    Transform targetToGo;
    Transform myPlayerTransform;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myPlayerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (targetToGo != null)
        {
            agent.SetDestination(targetToGo.position);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") !=0)
        {
            myPlayerTransform.transform.position=new Vector3(myPlayerTransform.transform.position.x+Input.GetAxisRaw("Horizontal")*speedCharacter, myPlayerTransform.transform.position.y, myPlayerTransform.transform.position.z+ Input.GetAxisRaw("Vertical") * speedCharacter);
        }

        if (Input.GetMouseButton(1))
        {
             myPlayerTransform.Rotate(new Vector3(Input.GetAxis("Mouse Y"),  Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speedRotation);
             myPlayerTransform.transform.LookAt(myPlayerTransform.transform.position + new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
        }
    }

    public void MovePlayerToDestination(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
