using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip clip;
    AudioSource audiosource;
    AudioClip oldClip=null;
    Animator animator;
    void Start()
    {
        audiosource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();

    }
    void Update()
    {
        if (animator.GetBool("attack"))
        {
            audiosource.Stop();
            oldClip = audiosource.clip;
            audiosource.clip = clip;
            audiosource.Play();
        }
        else
        {
            if (oldClip != null)
            {
                audiosource.Stop();
                audiosource.clip = oldClip;
                audiosource.Play();
                oldClip = null;
            }
        }
    }
}
