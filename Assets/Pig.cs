using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public bool Can;
    public MoveMent moneySystem;
    public GameObject Wings1;
    public GameObject Wings2;
    public NPCMove nPC;
    public AudioSource audio;
    Rigidbody body;
    public Vector3 vector;
    private void Start()
    {
        Rand = Random.Range(0f, 3f);
        audio.Stop();
        nPC = GetComponent<NPCMove>();
        moneySystem = FindObjectOfType<MoveMent>();
        body = GetComponent<Rigidbody>();
        system = FindObjectOfType<MoneySystem>();
    }
    public bool F;
    public float Timer;
    public float Rand;
    private void Update()
    {
        if (Can == false)
        {
            if (Timer >= Rand && F == false)
            {
                Timer = Rand;
                Rand = Random.Range(-3f, 0f);
                F = true;
            }
            if (Timer <= Rand && F == true)
            {
                Timer = Rand;
                Rand = Random.Range(0f, 3f);
                F = false;
            }
            if (F == false)
            {
                Timer += Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
            }
            if (F == true)
            {
                Timer -= Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
            }
        }
    }
    public MoneySystem system;
    public void OnMouseDown()
    {
        if (moneySystem.Shoot == true && Can == false)
        {
            system.ChangeMoney(20);
            audio.Play();
            Destroy(Wings1);
            Destroy(Wings2);
            body.useGravity = true;
            body.constraints &= ~RigidbodyConstraints.FreezePositionY;
            Can = true;
        }
    }
}
