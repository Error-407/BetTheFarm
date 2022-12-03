using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio1_2;
    public AudioSource audio2_2;

    void Start()
    {
        Money = FindObjectOfType<MoneySystem>();
        ment = FindObjectOfType<MoveMent>();
        Rand = Random.Range(0f, 10f);
        audio1.Stop();
        audio2.Stop();
        audio1_2.Stop();
        audio2_2.Stop();
    }
    float Rand;
    float time;
    public bool Danger;
    public void Update()
    {
        time += Time.deltaTime;
        if (time >= Rand)
        {
            if (Danger == false)
            {
                audio1.Play();
            } else
            {
                audio2.Play();
            }
            Rand = Random.Range(0f, 10f);
            time = 0f;
        }
    }
    public MoveMent ment;
    public GameObject[] All;
    private void OnMouseDown()
    {
        if (ment.Shoot == true)
        {
            if (Danger == false)
            {
                audio1_2.Play();
            } else
            {
                All = GameObject.FindGameObjectsWithTag("Sheep");
                Money.ChangeMoney(10 * All.Length);
                for (int i = 0; i < All.Length; i++)
                {
                    Destroy(All[i]);
                }
                All = null;
                audio2_2.Play();
            }
            Destroy(gameObject,1);
        }
    }
    MoneySystem Money;
}
