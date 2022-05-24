using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementScript : MonoBehaviour
{
    public float speedCharacter = 1;
    public float speedRotation = 20;
    public Transform myPlayerTransform;

    [SerializeField] float smoothTime;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Vector3 targetToGo;
    Transform myObjectTransform;
    NavMeshAgent agent;
    Camera myCamera;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myObjectTransform = GetComponent<Transform>();
        myCamera = Camera.main;
    }

    void Update()
    {
        if (targetToGo != Vector3.zero)
        {
            if (Vector3.Distance(targetToGo, myObjectTransform.transform.position) <= 1)
            {
                //   Debug.Log("AGENT, STOP IT NOW");
                agent.isStopped = true;

                targetToGo = Vector3.zero;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            agent.isStopped = true;

            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"), 0).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? 2 * speedCharacter : speedCharacter), ref smoothMoveVelocity, 0);
            myObjectTransform.position = myObjectTransform.position + myPlayerTransform.TransformDirection(moveAmount) * Time.deltaTime;
        }

        if (Input.GetMouseButton(1))
        {
            myCamera.transform.RotateAround(myPlayerTransform.position, Vector3.up, Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime);
            myPlayerTransform.transform.Rotate(0, 0, Input.GetAxisRaw("Mouse X") * speedRotation * Time.deltaTime);
        }
    }


    public void MovePlayerToDestination(Vector3 point)
    {
        if (agent.isStopped == true)
            agent.isStopped = false;
        agent.SetDestination(point);
        targetToGo = point;
    }
}
