using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;
    Rigidbody rb;
    Transform lastPosition;

    const float locomitionAnimationSmoot = .1f;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        lastPosition = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = 0;
        if (!agent.isStopped)
        {
            speedPercent = agent.velocity.magnitude / agent.speed;

        }
        else {
            var vel = rb.velocity;      //to get a Vector3 representation of the velocity
            float speed = vel.magnitude;
          //  float speed = Vector3.Distance(lastPosition.position,rb.transform.position ) *100;
            lastPosition = rb.transform;
            speedPercent =1f;
            Debug.Log("speed " + speed+"    "+ rb.transform.position+"      " + lastPosition.position);
        }
        animator.SetFloat("speed", speedPercent, locomitionAnimationSmoot, Time.deltaTime);
    }
}
