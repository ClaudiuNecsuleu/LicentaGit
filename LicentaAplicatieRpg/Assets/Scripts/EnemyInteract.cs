using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    float TimeLast;
    public static float health = 50;
    Animator animatorPlayer;
    Animator animatorEnemy;
    EnemyHealthDesign enemyHealthDesign;
    AudioSource audioSource;
    [HideInInspector]
    public Transform target;
    void Start()
    {
        animatorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
        animatorEnemy = GetComponent<Animator>();
        enemyHealthDesign = GetComponentInChildren<EnemyHealthDesign>();
        target = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponentInChildren<Transform>();
    }

    public delegate void OnHealthChangeStatus();
    public OnHealthChangeStatus OnHealthChangeStatus2;

    void Update()
    {
        if (Time.time >= TimeLast + 2)
        {
            GetComponent<Animator>().SetBool("isAttacked", false);
            animatorPlayer.SetBool("attack", false);
        }
        if (health < 0)
        {
            Debug.Log("Death");
            animatorPlayer.SetBool("attack", false);
            animatorEnemy.SetTrigger("Die");
            Destroy(gameObject, 4);
        }
        if (Vector3.Distance(target.position, transform.position) <= 6)
        {
            FaceToTarget();
        }
    }

    public void Attack()
    {
        animatorPlayer.SetBool("attack", true);
        animatorEnemy.SetBool("isAttacked", true);
        TimeLast = Time.time;
        CharacterStats.Instance.TakeDamage(10);
        health -= CharacterStats.Instance.damage.CalculateValue();
        enemyHealthDesign.ChangeHealth();
    }

    public void FaceToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 1f);
    }
}
