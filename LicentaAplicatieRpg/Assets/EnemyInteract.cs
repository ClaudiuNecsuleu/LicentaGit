using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    float TimeLast;
    public static float health =50;
    Animator animatorPlayer;
    Animator animatorEnemy;
    EnemyHealthDesign enemyHealthDesign;
   void Start()
    {
        animatorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        animatorEnemy = GetComponent<Animator>();
        enemyHealthDesign = GetComponentInChildren<EnemyHealthDesign>();
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
        if (health < 0) {
            Debug.Log("Death");
        }
    }

    public void Attack() {
        animatorPlayer.SetBool("attack",true);
        animatorEnemy.SetBool("isAttacked", true);
        TimeLast = Time.time;
        CharacterStats.Instance.TakeDamage(10);
        health-=CharacterStats.Instance.damage.CalculateValue();
        enemyHealthDesign.ChangeHealth();


    }
}
