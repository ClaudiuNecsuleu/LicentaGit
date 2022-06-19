using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Singleton
    public static CharacterStats Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one stats");
            return;
        }
        Instance = this;
    }
    #endregion

    [HideInInspector]
    public Stat damage = new Stat();
    [HideInInspector]
    public Stat armour = new Stat();
    [HideInInspector]
    public float health;
    [HideInInspector]
    public float maxHealth = 100;
    public Transform respawn;
    void Start()
    {
        damage.value = 0;
        armour.value = 0;
        health = maxHealth;
        onItemChangeStatusCallMe.Invoke();
    }

    public delegate void OnItemChangeStatus();
    public OnItemChangeStatus onItemChangeStatusCallMe;

    public delegate void OnHealthChangeStatus();
    public OnItemChangeStatus onHealthChangeStatusCallMe;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            //  TakeDamage(10);
        }
    }

    public void TakeDamage(float dmg)
    {
        dmg -= armour.value;
        dmg = Mathf.Clamp(dmg, 0, maxHealth);
        health -= dmg;
        
        //Debug.Log(transform.name + " take damage " + dmg  +"       helat "+ health);

        onHealthChangeStatusCallMe.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died ");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position=respawn.position;
        health = 10;
        onHealthChangeStatusCallMe.Invoke();
    }
}
