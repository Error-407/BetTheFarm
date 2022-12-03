using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public AudioSource DieS;
    public Animator animator;
    public GameObject[] Sounds;
    public GameObject DeathScene;
    public Sleep sleep;
    public DayCount day;
    public void Frame(Slider slider)
    {
        if (slider.value <= 0)
        {
            day.Stop();
            sleep.work = false;
            Time.timeScale = 1;
            DieS.Play();
            animator.SetBool("Start", true);
            Can = true;
        }
    }
    public float Die;
    bool Can;
    private void Update()
    {
        if (Can == true)
        {
            Die -= Time.deltaTime;
            if (Die <= 0)
            {
                for (int i = 0; i < Sounds.Length; i++)
                {
                    Sounds[i].SetActive(false);
                }
                DeathScene.SetActive(true);
                Can = false;
            }
        }
    }
}