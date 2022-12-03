using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCage : MonoBehaviour
{
    public Transform Max;
    public Transform Min;

    public GameObject Animal;

    public int NumberOfAnimsls;
    public Vector3 vector;
    public void Work()
    {
        int Rand = Random.Range(0, NumberOfAnimsls);
        for (int i = 0; i < NumberOfAnimsls; i++)
        {
            GameObject Animals = Instantiate(Animal);
            vector = new Vector3(
                Random.Range(Min.transform.position.x, Max.transform.position.x),
                Random.Range(Min.transform.position.y, Max.transform.position.y),
                Random.Range(Min.transform.position.z, Max.transform.position.z)
                );
            Animals.transform.position = vector;
            Animals.tag = "Sheep";
            if (i == Rand)
            {
                Animals.GetComponent<Sheep>().Danger=true;
                Animals.tag = "Wolf";
            }
        }
    }
}
