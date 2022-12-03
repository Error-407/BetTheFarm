using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    public AudioSource audio;
    public Animator animator;
    public bool work;
    public Slider slider;
    public DayCount count;
    public void SleepPoint()
    {
        work = true;
    }
    private void Start()
    {
        audio.Stop();
    }

    private void Update()
    {
        if (work == true)
        {
            Time.timeScale = 100;
            if (slider.value == 100)
            {
                animator.SetBool("Awake", true);
                audio.Play();
                Time.timeScale = 1;
                count.CanSleep = true;
                work = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Awake", false);
            work = true;
            count.CanSleep = false;
        }
    }
}
