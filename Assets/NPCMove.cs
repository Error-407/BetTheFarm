using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public MoneySystem moneySystem;
    public Rigidbody rigidbody;
    public float Speed;
    public void Start()
    {
        S = true;
        if (gameObject.tag == "Dog")
            moneySystem = FindObjectOfType<MoneySystem>();

        if (audio2Win != null)
            audio2Win.Stop();
        if (audio != null)
            audio.Play();
        rigidbody = GetComponent<Rigidbody>();
    }
    public float TimeOff;
    public float TimeLeft;
    public int RandomNumber;
    public AudioSource audio;
    public AudioSource audio2Win;

    public int Earn;
    private void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            TimeLeft = TimeOff;
            RandomNumber = Random.Range(0, 4);
        }
        switch (RandomNumber)
        {
            case 0:
                rigidbody.velocity = Vector3.forward * Speed;
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
                break;
            case 1:
                rigidbody.velocity = Vector3.back * Speed;
                transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z);
                break;
            case 2:
                rigidbody.velocity = Vector3.left * Speed;
                transform.eulerAngles = new Vector3(0, -90, transform.eulerAngles.z);
                break;
            case 3:
                rigidbody.velocity = Vector3.right * Speed;
                transform.eulerAngles = new Vector3(0, 90, transform.eulerAngles.z);
                break;
        }
    }
    bool S;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player" && gameObject.tag == "Dog")
        {
            TimeLeft = 0;
        }
        else if (collision.gameObject.tag == "Player" && gameObject.tag == "Dog" && S == true)
        {
            S = false;
            moneySystem.ChangeMoney(Earn);
            if (audio2Win != null)
                audio2Win.Play();
            Destroy(gameObject,0.5f);
        }
    } 

}
