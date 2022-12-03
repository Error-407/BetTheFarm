using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassChange : MonoBehaviour
{
    public AudioSource audio;
    public Color32 Color;
    public Color32 Color2;

    public Animator animator;

    public bool TOF;
    public bool Can;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();
        animator.SetBool("Start", false);
        gameObject.GetComponent<Renderer>().material.color = Color;
        TOF = false;
    }
    public void OnMouseDown()
    {
        audio.Play();
        Can = true;
        if (TOF == true)
        {
            animator.SetBool("Start", true);
            gameObject.GetComponent<Renderer>().material.color = Color;
            TOF = false;
        } else
        {
            animator.SetBool("Start", true);
            gameObject.GetComponent<Renderer>().material.color = Color2;
            TOF = true;
        }
    }
    public float AniTime;

    public void Changed()
    {
        Can = true;
        if (TOF == true)
        {
            animator.SetBool("Start", true);
            gameObject.GetComponent<Renderer>().material.color = Color;
            TOF = false;
        }
        else
        {
            animator.SetBool("Start", true);
            gameObject.GetComponent<Renderer>().material.color = Color2;
            TOF = true;
        }
    }
    private void Update()
    {
        if (Can == true)
        {
            if (AniTime <= 0.5f)
            {
                AniTime += Time.deltaTime;
            }
            else
            {
                animator.SetBool("Start", false);
                Can = false;
                AniTime = 0;
            }
        }
    }
}
