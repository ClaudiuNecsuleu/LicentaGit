using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDesign : MonoBehaviour
{
    public Image healthImg;
    float lastTime;
    void Update()
    {
        if ((Time.time - lastTime) > 5)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void ChangeHealth()
    {
        Debug.Log("health UI enemy change");
        this.gameObject.SetActive(true);
        healthImg.fillAmount = EnemyInteract.health / 50;
        lastTime = Time.time;
    }
}
