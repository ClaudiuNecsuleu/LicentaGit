using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDesign : MonoBehaviour
{
    public Image healthImg;
    float lastTime;
    void Start()
    {
        CharacterStats.Instance.onHealthChangeStatusCallMe += ChangeHealth;
    }

    void Update()
    {
            if ((Time.time - lastTime) > 5)
            { 
            this.gameObject.SetActive(false);
            }
        
    }

    public void ChangeHealth() {
        Debug.Log("health UI change");
        this.gameObject.SetActive(true);
        healthImg.fillAmount = CharacterStats.Instance.health/ CharacterStats.Instance.maxHealth;
        lastTime = Time.time;
        
    }
}
