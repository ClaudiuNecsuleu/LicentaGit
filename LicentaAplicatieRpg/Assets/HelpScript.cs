using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public GameObject ui;
    bool wasShow = false;
    bool wasShowSecond = false;
    Transform trans;
    Transform transMY;
    float timeLast = 0;

    void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transMY=GetComponent<Transform>();
    }
    void Update()
    {
        if (!wasShow)
        {
            if (Vector3.Distance(transMY.position, trans.position) < 5)
            {
                ui.SetActive(true);
                wasShow = true;
                timeLast = Time.time;
            }
        }
        else if(Time.time > timeLast+3 && !wasShowSecond) {
            ui.SetActive(false);
            wasShowSecond = true;
        }
    }

}
