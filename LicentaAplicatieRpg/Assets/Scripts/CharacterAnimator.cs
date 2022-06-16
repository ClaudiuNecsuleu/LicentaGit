using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;

    const float locomitionAnimationSmoot = .1f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float speedPercent = 0;
        if (!agent.isStopped)
        {
            speedPercent = agent.velocity.magnitude / agent.speed;
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                speedPercent = 0.75f;
            }
        }
        animator.SetFloat("speed", speedPercent, locomitionAnimationSmoot, Time.deltaTime);
    }
}
