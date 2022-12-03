using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public int Amount;
    public CountChickens chickens;
    public GameObject game;
    public CountChickens count;
    public bool Can;
    public float Timer;

    public void Update()
    {
        if(Can == true)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                for (int i = 0; i < Amount; i++)
                {
                    Instantiate(game, new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y, transform.position.z + Random.Range(-1, 1)), transform.rotation);
                }
                GetComponent<MeshRenderer>().enabled = false;
                Can = false;
            }
        }
    }

    public void Work()
    {
        GetComponent<MeshRenderer>().enabled = true;
        Amount = Random.Range(1, 4);
        Timer = Random.Range(1, 8) * 15;
        count.Egges += Amount;
        Can = true;
    }
}
