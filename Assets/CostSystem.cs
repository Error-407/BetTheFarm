using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostSystem : MonoBehaviour
{
    public GameObject GameObject;
    public CameraMove came;
    public MoveMent moveMent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveMent.enabled = false;
            came.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameObject.SetActive(true);
        }
    }
    public EatDrink eat;
    public MoneySystem moneySystem;
    public PigSpawn pigSpawns;
    public SheepCage Sheep;
    public GameObject[] Grass;
    public bool CanGrass;
    bool C;
    public GameObject[] Chicken;
    public void Buy(int Cost)
    {
        if (moneySystem.MoneyAmount - Cost >= 0)
        {
            if(Cost == 8)
            {
                eat.Eat(1);
                moneySystem.ChangeMoney(-Cost);
            }
            if (Cost == 5)
            {
                eat.Drinking(1);
                moneySystem.ChangeMoney(-Cost);
            }
            if(Cost == 30 && CanGrass == true)
            {
                C = false;
                for (int i = 0; i < Grass.Length; i++)
                {
                    if (Grass[i].activeInHierarchy == false)
                    {
                        C = true;
                        Grass[i].SetActive(true);
                        break;
                    }
                }
                if (C == false)
                {
                    CanGrass = false;
                } else
                {
                    moneySystem.ChangeMoney(-Cost);
                }
            }
            if (Cost == 35)
            {
                for(int i = 0; i < Chicken.Length; i++)
                {
                    if (Chicken[i].activeInHierarchy == false)
                    {
                        Chicken[i].SetActive(true);
                        moneySystem.ChangeMoney(-Cost);
                        break;
                    }
                }
            }
            if (Cost == 45 && pigSpawns.NumberOfAnimsls < 50)
            {
                pigSpawns.NumberOfAnimsls++;
                moneySystem.ChangeMoney(-Cost);
            }
            if (Cost == 40 && Sheep.NumberOfAnimsls < 25)
            {
                Sheep.NumberOfAnimsls++;
                moneySystem.ChangeMoney(-Cost);
            }
        }
    }

    public void Close()
    {
        moveMent.enabled = true;
        came.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.SetActive(false);
    }
}
