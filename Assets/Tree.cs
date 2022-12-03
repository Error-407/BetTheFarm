using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public MoneySystem moneySystem;
    public AudioSource audio;
    private void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio.Play();
            moneySystem.ChangeMoney(50);
            Destroy(gameObject, 1);    
        }
    }
}
