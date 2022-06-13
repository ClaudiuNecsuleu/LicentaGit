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
    public Stat damage =new Stat();
    [HideInInspector]
    public Stat armour = new Stat();
    float healt;
    void Start()
    {
        damage.value = 0;
        armour.value = 1;
        healt = 100;
        onItemChangeStatusCallMe.Invoke();
    }

    public delegate void OnItemChangeStatus();
    public OnItemChangeStatus onItemChangeStatusCallMe;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float dmg)
    {
        dmg -= armour.value;
        healt -= dmg;
        dmg = Mathf.Clamp(dmg, 0, 100);

        Debug.Log(transform.name + " take damage " + dmg  +"       helat "+ healt);

        if (healt <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died ");
    }
}
